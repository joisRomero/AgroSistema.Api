IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_listar_actividades_paginado')
	DROP PROCEDURE sp_listar_actividades_paginado
GO

CREATE PROCEDURE sp_listar_actividades_paginado(
	@p_id_camp		INT
	,@p_fecha_acti	DATETIME	= NULL
	,@p_nombre_tipoActi	VARCHAR(100)
	,@pageSize		INT = 5		--Tamaño de la Página
	,@pageNumber	INT = 1		--Número de Página
)
AS
BEGIN
	
	IF OBJECT_ID('tempdb..#temp_TablaListaActividadPaginado') IS NOT NULL
		DROP TABLE #temp_TablaListaActividadPaginado

	DECLARE @offset INT
	DECLARE @RecordCont INT
	DECLARE @s_CantidadReg INT	

	SELECT 
		@RecordCont = COUNT(*)
	FROM ACTIVIDAD a
	LEFT JOIN TIPO_ACTIVIDAD ta on a.id_tipoActi = ta.id_tipoActi
	WHERE (a.id_camp = @p_id_camp)
	AND (a.fecha_acti = @p_fecha_acti OR ISNULL(@p_fecha_acti,'') = '')
	AND	(ta.nombre_tipoActi = @p_nombre_tipoActi OR ISNULL(@p_nombre_tipoActi,'') = '')
	AND estado_acti = 1

	SET @s_CantidadReg = @RecordCont
	SET @offset = (@pageSize * (@pageNumber -1))

	SELECT 
		a.id_acti 
		,a.fecha_acti
		,a.descripcion_acti
		,ta.nombre_tipoActi
	INTO #temp_TablaListaActividadPaginado
	FROM ACTIVIDAD a
	INNER JOIN TIPO_ACTIVIDAD ta on ta.id_tipoActi = a.id_tipoActi
	WHERE (a.id_camp = @p_id_camp)
	AND (a.fecha_acti = @p_fecha_acti OR ISNULL(@p_fecha_acti,'') = '')
	AND	((ta.nombre_tipoActi LIKE '%'+ @p_nombre_tipoActi +'%') OR ISNULL(@p_nombre_tipoActi,'') = '')
	AND a.estado_acti = 1
	ORDER BY a.fecha_acti asc

	;WITH TotalCostoTrabajador 
	AS (
		SELECT 
			a.id_acti,
			CONVERT(DECIMAL(18,2),SUM(t.costoTotal_trab)) AS totalCosto_GastoTrabajador
		FROM TRABAJADOR t
		LEFT JOIN #temp_TablaListaActividadPaginado a ON a.id_acti = t.id_acti 
		WHERE t.estado_trab = 1
		GROUP BY a.id_acti
	),
	TotalCostoGastoDetalle 
	AS (
		SELECT 
			a.id_acti,
			CONVERT(DECIMAL(18,2),SUM(gd.costoTotal_gastoDet)) AS total_costo_GastoDetalle
		FROM GASTO_DETALLE gd
		LEFT JOIN #temp_TablaListaActividadPaginado a ON a.id_acti = gd.id_acti
		WHERE gd.estado_gastoDet = 1
		GROUP BY a.id_acti
	),
	TotalesGastos AS 
	(
		SELECT 
			tct.id_acti
			,tct.totalCosto_GastoTrabajador
			,cgd.total_costo_GastoDetalle
		FROM TotalCostoTrabajador tct
		LEFT JOIN TotalCostoGastoDetalle cgd on cgd.id_acti = tct.id_acti
	),
	tablaFiltrada
	AS(
		SELECT 
			ROW_NUMBER() OVER( ORDER BY tap.id_acti DESC) AS Correlativo
			,tap.id_acti 
			,tap.fecha_acti
			,tap.descripcion_acti
			,tap.nombre_tipoActi
			,CONVERT(DECIMAL(18,2),(tg.total_costo_GastoDetalle+tg.totalCosto_GastoTrabajador)) AS TotalGasto
		FROM #temp_TablaListaActividadPaginado tap
		LEFT JOIN TotalesGastos tg on tg.id_acti = tap.id_acti
	)
	SELECT TOP(@pageSize)
		Correlativo
		,id_acti as IdActividad
		,fecha_acti as FechaActividad
		,descripcion_acti AS DescripcionActividad
		,nombre_tipoActi AS NombreTipoActividad
		,ISNULL(TotalGasto,0) AS TotalGasto
		,@s_CantidadReg AS TotalRows
	FROM tablaFiltrada
	WHERE Correlativo > @offset
END