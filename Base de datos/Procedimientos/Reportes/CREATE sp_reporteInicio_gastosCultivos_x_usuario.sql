IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_reporteInicio_gastosCultivos_x_usuario')
	DROP PROCEDURE sp_reporteInicio_gastosCultivos_x_usuario
GO

CREATE PROCEDURE sp_reporteInicio_gastosCultivos_x_usuario(
	@p_id_usu INT
)
AS
BEGIN
	IF OBJECT_ID('tempdb..#temp_TablaListaActividadCampania') IS NOT NULL
		DROP TABLE #temp_TablaListaActividadCampania

	SELECT
		c.id_camp
		,a.id_acti
	INTO #temp_TablaListaActividadCampania
	FROM CAMPANIA c
	LEFT JOIN ACTIVIDAD a on a.id_camp = c.id_camp
	LEFT JOIN SOCIEDAD s on s.id_soc = c.id_soc
	LEFT JOIN USUARIO_SOCIEDAD u on u.id_soc = s.id_soc
	WHERE u.id_usu = @p_id_usu OR c.id_usu = @p_id_usu
	AND c.estado_camp = 1
	AND a.estado_acti = 1

	;WITH 
	TablaActividadesCampania
	AS (
		SELECT
			id_camp
			,id_acti
		FROM #temp_TablaListaActividadCampania
		WHERE id_acti IS NOT NULL
	),
	TotalesCampaniaUsuario
	AS
	(
		SELECT 
			DISTINCT (id_camp)
		FROM #temp_TablaListaActividadCampania
	),
	TotalCostoTrabajador 
	AS (
		SELECT 
			a.id_acti,
			CONVERT(DECIMAL(18,2),SUM(t.costoTotal_trab)) AS totalCosto_GastoTrabajador
		FROM TablaActividadesCampania a 
		LEFT JOIN TRABAJADOR t ON t.id_acti = a.id_acti
		WHERE t.estado_trab = 1
		GROUP BY a.id_acti
	),
	TotalCostoGastoDetalle 
	AS (
		SELECT 
			a.id_acti,
			CONVERT(DECIMAL(18,2),SUM(gd.costoTotal_gastoDet)) AS total_costo_GastoDetalle
		FROM TablaActividadesCampania a 
		LEFT JOIN GASTO_DETALLE gd ON gd.id_acti = a.id_acti
		WHERE gd.estado_gastoDet = 1
		GROUP BY a.id_acti
	),
	DatosGastosActividad AS 
	(
		SELECT 
			tac.id_acti
			,tct.totalCosto_GastoTrabajador
			,cgd.total_costo_GastoDetalle
		FROM TablaActividadesCampania tac
		LEFT JOIN TotalCostoTrabajador tct on tct.id_acti = tac.id_acti 
		LEFT JOIN TotalCostoGastoDetalle cgd on cgd.id_acti = tct.id_acti
	),
	TotalesGastosActividad AS
	(
		SELECT 
			id_acti
			,CONVERT(DECIMAL(18,2),(ISNULL(totalCosto_GastoTrabajador,0) + ISNULL(total_costo_GastoDetalle,0))) AS TotalGasto
		FROM DatosGastosActividad
	),
	TotalGastosCampaniaActividades
	AS
	(
		SELECT 
			tla.id_camp
			,SUM(tga.TotalGasto) AS TotalGastoCampaniasActividades
		FROM #temp_TablaListaActividadCampania tla 
		LEFT JOIN TotalesGastosActividad tga on tga.id_acti = tla.id_acti
		GROUP BY tla.id_camp
	),
	TotalGastosDetalleCampania
	AS
	(
		SELECT 
			tcu.id_camp
			,SUM(gd.costoTotal_gastoDet) AS GastosCampania
		FROM TotalesCampaniaUsuario tcu
		LEFT JOIN GASTO_DETALLE gd on gd.id_camp = tcu.id_camp
		WHERE gd.estado_gastoDet = 1
		GROUP BY tcu.id_camp
	),
	TotalGastosCampania
	AS
	(
		SELECT 
			tcu.id_camp
			,CONVERT(DECIMAL(18,2),ISNULL(gca.TotalGastoCampaniasActividades,0)) AS TotalGastoCampaniasActividades
			,CONVERT(DECIMAL(18,2),ISNULL(gdc.GastosCampania,0)) AS TotalGastosDetalleCampania
		FROM  TotalesCampaniaUsuario tcu
		LEFT JOIN TotalGastosDetalleCampania gdc on tcu.id_camp = gdc.id_camp
		LEFT JOIN TotalGastosCampaniaActividades gca on tcu.id_camp = gca.id_camp
	),
	TotalGastosCultivos
	AS
	(
		SELECT
			tgc.id_camp
			,c.id_culti
			,cu.nombre_culti
			,CONVERT(DECIMAL(18,2),(tgc.TotalGastoCampaniasActividades + tgc.TotalGastosDetalleCampania)) AS TotalGasto
		FROM TotalGastosCampania tgc
		LEFT JOIN CAMPANIA c on c.id_camp= tgc.id_camp
		INNER JOIN CULTIVO cu on cu.id_culti = c.id_culti
	),
	TotalGastosCultivosUnicos
	AS
	(
		SELECT 	
			nombre_culti AS NombreCultivo
			,SUM(TotalGasto) AS TotalGasto
		FROM TotalGastosCultivos
		GROUP BY nombre_culti
	)
	SELECT 
		NombreCultivo
		,CONVERT(DECIMAL(18,2),TotalGasto) AS TotalGasto
	FROM TotalGastosCultivosUnicos
END