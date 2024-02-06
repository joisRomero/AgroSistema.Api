IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ListarSociedades')
	DROP PROCEDURE sp_ListarSociedades
GO

CREATE PROCEDURE sp_ListarSociedades(
	@nombreSociedad varchar(100) = ''
	,@idUsuario		INT = NULL
	,@pageSize	INT = 5		--Tamaño de la Página
	,@pageNumber	INT = 1		--Número de Página

)
AS

BEGIN
	DECLARE @offset INT
	DECLARE @RecordCont INT
	DECLARE @sNombreSociedad varchar(100)
	DECLARE @s_CantidadReg INT

	SET @sNombreSociedad = RTRIM(LTRIM(@nombreSociedad))

	

	SELECT 
		@RecordCont = COUNT(*)
	FROM SOCIEDAD s
	INNER JOIN USUARIO_SOCIEDAD us ON s.id_soc = us.id_soc 
	WHERE
	(s.nombre_soc LIKE '%'+@nombreSociedad +'%' or @nombreSociedad = '')
	AND (us.id_usu = @idUsuario OR @idUsuario IS NULL)
	AND s.estado_soc = 1

	SET @s_CantidadReg = @RecordCont
	SET @offset = (@pageSize * (@pageNumber -1))
	
	--SELECT @s_CantidadReg
	
	;WITH
	tablaFiltrada
	AS(
		SELECT 
			ROW_NUMBER() OVER( ORDER BY s.id_soc DESC) AS Correlativo
			,s.id_soc AS IdSociedad
			,s.nombre_soc AS NombreSociedad
			,CASE WHEN s.estado_soc = 1 THEN 'Activo'
				WHEN s.estado_soc = 0 THEN 'Inactivo'
			 END AS Estado
			 ,CONCAT(u.nombre_usu, ' ', u.apellidoPaterno_usu, ' ', u.apellidoMaterno_usu) AS NombreUsuario
			 ,@s_CantidadReg AS CantidadRegistros
		FROM SOCIEDAD s with(nolock)
		INNER JOIN USUARIO_SOCIEDAD us ON s.id_soc = us.id_soc 
		LEFT JOIN USUARIO u on u.id_usu = us.id_usu
		WHERE 
		(s.nombre_soc LIKE '%'+@nombreSociedad +'%' or @nombreSociedad = '')
		AND (us.id_usu = @idUsuario OR @idUsuario IS NULL)
		AND s.estado_soc = 1
	)
	SELECT TOP(@pageSize) * FROM tablaFiltrada WHERE Correlativo > @offset
			
END