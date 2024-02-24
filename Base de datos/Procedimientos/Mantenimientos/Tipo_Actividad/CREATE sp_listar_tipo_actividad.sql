IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_listar_tipo_actividad')
	DROP PROCEDURE sp_listar_tipo_actividad
GO

CREATE PROCEDURE sp_listar_tipo_actividad(
	@p_nombre_tipoActi			VARCHAR(100) =''
	,@p_realizadaPor_tipoActi	CHAR(1)	= ''
	,@p_id_usu					INT
	,@p_PageSize	INT = 5		--Tamaño de la Página
	,@p_PageNumber	INT = 1		--Número de Página
)
AS
BEGIN
	DECLARE @offset				INT
	DECLARE @RecordCont			INT
	DECLARE @s_nombre_tipoActi	VARCHAR(100)
	DECLARE @s_CantidadReg		INT

	SET @s_nombre_tipoActi = RTRIM(LTRIM(@p_nombre_tipoActi))

	

	SELECT 
		@RecordCont = COUNT(*)
	FROM TIPO_ACTIVIDAD
	WHERE
	(nombre_tipoActi LIKE '%'+@s_nombre_tipoActi +'%' or @s_nombre_tipoActi = '')
	AND (realizadaPor_tipoActi = @p_realizadaPor_tipoActi OR @p_realizadaPor_tipoActi = '')
	AND id_usu = @p_id_usu
	AND estado_tipoActi = 1

	SET @s_CantidadReg = @RecordCont
	SET @offset = (@p_PageSize * (@p_PageNumber -1))

	;WITH
	tablaFiltrada AS(
		SELECT
			ROW_NUMBER() OVER( ORDER BY id_tipoActi DESC) AS Correlativo
			,id_tipoActi
			,nombre_tipoActi
			,realizadaPor_tipoActi
			,descripcion_tipoActi
		FROM TIPO_ACTIVIDAD
		WHERE
		(nombre_tipoActi LIKE '%'+@s_nombre_tipoActi +'%' or @s_nombre_tipoActi = '')
		AND (realizadaPor_tipoActi = @p_realizadaPor_tipoActi OR @p_realizadaPor_tipoActi = '')
		AND id_usu = @p_id_usu
		AND estado_tipoActi = 1
	)
	SELECT TOP(@p_PageSize) Correlativo
			,id_tipoActi		AS IdTipoActividad
			,nombre_tipoActi	AS NombreTipoActividad
			,realizadaPor_tipoActi	AS RealizadaPorTipoActividad
			,descripcion_tipoActi	AS DescripcionTipoActividad
			,@s_CantidadReg AS TotalRows
	FROM tablaFiltrada WHERE Correlativo > @offset 
	ORDER BY id_tipoActi



END