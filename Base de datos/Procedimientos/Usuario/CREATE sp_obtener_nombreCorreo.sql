IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_nombreCorreo')
	DROP PROCEDURE sp_obtener_nombreCorreo
GO

CREATE PROCEDURE sp_obtener_nombreCorreo(
	@p_correo_usu	VARCHAR(250)
)
AS
BEGIN
	DECLARE @p_NombreCompleto VARCHAR(200)
	SET @p_NombreCompleto = NULL
	
	IF EXISTS (SELECT id_usu FROM USUARIO WHERE correo_usu = @p_correo_usu)
	BEGIN
		SET @p_NombreCompleto = (SELECT CONCAT(nombre_usu,' ',apellidoPaterno_usu,' ',apellidoMaterno_usu) FROM USUARIO WHERE correo_usu = @p_correo_usu)
	END

	SELECT @p_NombreCompleto AS NombreCompleto
END