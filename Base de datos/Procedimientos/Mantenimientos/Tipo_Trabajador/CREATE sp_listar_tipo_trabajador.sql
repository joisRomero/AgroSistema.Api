IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_listar_tipo_trabajador')
	DROP PROCEDURE sp_listar_tipo_trabajador
GO

CREATE PROCEDURE sp_listar_tipo_trabajador(
	@p_nombre_tipoTrab varchar(100) = ''
	,@p_id_usu		INT
	,@p_PageSize	INT = 5		--Tamaño de la Página
	,@p_PageNumber	INT = 1		--Número de Página
)
AS

BEGIN
	DECLARE @offset				INT
	DECLARE @RecordCont			INT
	DECLARE @s_nombre_tipoTrab	VARCHAR(100)
	DECLARE @s_CantidadReg		INT

	SET @s_nombre_tipoTrab = RTRIM(LTRIM(@p_nombre_tipoTrab))

	

	SELECT 
		@RecordCont = COUNT(*)
	FROM TIPO_TRABAJADOR
	WHERE
	(nombre_tipoTrab LIKE '%'+@s_nombre_tipoTrab +'%' or @s_nombre_tipoTrab = '')
	AND id_usu = @p_id_usu
	AND estado_tipoTrab = 1

	SET @s_CantidadReg = @RecordCont
	SET @offset = (@p_PageSize * (@p_PageNumber -1))
	
	--SELECT @s_CantidadReg
	
	;WITH
	tablaFiltrada
	AS(
		SELECT 
			ROW_NUMBER() OVER( ORDER BY tt.id_tipoTrab DESC) AS Correlativo
			,tt.id_tipoTrab		AS id_tipoTrab
			,tt.nombre_tipoTrab AS nombre_tipoTrab
			,tt.descripcion_tipoTrab AS descripcion_tipoTrab
		FROM TIPO_TRABAJADOR tt with(nolock)
		WHERE 
		(tt.nombre_tipoTrab LIKE '%'+@s_nombre_tipoTrab +'%' or @s_nombre_tipoTrab = '')
		AND id_usu = @p_id_usu
		AND tt.estado_tipoTrab = 1
	)
	SELECT TOP(@p_PageSize) Correlativo
		,id_tipoTrab AS IdTipoTrabajador
		,nombre_tipoTrab AS NombreTipoTrabajador
		,descripcion_tipoTrab AS DescripcionTipoTrabajador
		,@s_CantidadReg AS TotalRows 
	FROM tablaFiltrada WHERE Correlativo > @offset 
	ORDER BY id_tipoTrab
END