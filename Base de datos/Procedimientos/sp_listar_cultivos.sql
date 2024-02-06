IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_listar_cultivos')
	DROP PROCEDURE sp_listar_cultivos
GO

CREATE PROCEDURE sp_listar_cultivos(
	@p_nombre_culti varchar(100) = ''
	,@p_id_usu		INT = NULL
	,@p_PageSize	INT = 5		--Tamaño de la Página
	,@p_PageNumber	INT = 1		--Número de Página

)
AS

BEGIN
	DECLARE @offset INT
	DECLARE @RecordCont INT
	DECLARE @s_nombre_culti varchar(100)
	DECLARE @s_CantidadReg INT

	SET @s_nombre_culti = RTRIM(LTRIM(@p_nombre_culti))

	

	SELECT 
		@RecordCont = COUNT(*)
	FROM CULTIVO
	WHERE
	(nombre_culti LIKE '%'+@p_nombre_culti +'%' or @p_nombre_culti = '')
	AND (id_usu = @p_id_usu OR @p_id_usu IS NULL)
	AND estado_culti = 1

	SET @s_CantidadReg = @RecordCont
	SET @offset = (@p_PageSize * (@p_PageNumber -1))
	
	--SELECT @s_CantidadReg
	
	;WITH
	tablaFiltrada
	AS(
		SELECT 
			ROW_NUMBER() OVER( ORDER BY c.id_culti DESC) AS Correlativo
			,c.id_culti AS IdCultivo
			,c.nombre_culti AS NombreCultivo
			,CASE WHEN c.estado_culti = 1 THEN 'Activo'
				WHEN c.estado_culti = 0 THEN 'Inactivo'
			 END AS Estado
			 ,CONCAT(u.nombre_usu, ' ', u.apellidoPaterno_usu, ' ', u.apellidoMaterno_usu) AS NombreUsuario
			 ,@s_CantidadReg AS CantidadRegistros
		FROM CULTIVO c with(nolock)
		LEFT JOIN USUARIO u on u.id_usu = c.id_usu
		WHERE 
		(c.nombre_culti LIKE '%'+@p_nombre_culti +'%' or @p_nombre_culti = '')
		AND (c.id_usu = @p_id_usu OR @p_id_usu IS NULL)
		AND c.estado_culti = 1
	)
	SELECT TOP(@p_PageSize) * FROM tablaFiltrada WHERE Correlativo > @offset
		


	
END