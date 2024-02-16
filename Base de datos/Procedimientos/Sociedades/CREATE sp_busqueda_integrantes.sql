IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_busqueda_integrantes')
	DROP PROCEDURE sp_busqueda_integrantes
GO

CREATE PROCEDURE sp_busqueda_integrantes(
	 @p_nombreUsuario varchar(150)
	 ,@p_idUsuario	int
)
AS
BEGIN
	SELECT 
		CONCAT(u.nombre_usu,' ',u.apellidoPaterno_usu,' ',u.apellidoMaterno_usu) AS NombreCompleto
		,u.id_usu AS IdUsuario
		,u.nombreUsuario_usu AS NombreUsuario
	FROM USUARIO u 
	WHERE 
	NOT u.id_usu = @p_idUsuario 
	AND CONCAT(u.nombre_usu,' ',u.apellidoPaterno_usu,' ',u.apellidoMaterno_usu) LIKE '%'+@p_nombreUsuario+'%'
	OR u.nombreUsuario_usu LIKE '%'+@p_nombreUsuario+'%'
END


