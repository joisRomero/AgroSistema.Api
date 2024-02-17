USE agro_sistema_bd
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_CambioClaveUsuarioRecuperacion') 
	BEGIN
		DROP PROCEDURE sp_CambioClaveUsuarioRecuperacion;
	END
GO

CREATE PROCEDURE dbo.sp_CambioClaveUsuarioRecuperacion
	@nuevaClave VARCHAR(MAX),
	@correo VARCHAR(100)
AS
BEGIN

	DECLARE @nombreUsuario VARCHAR(50)

	UPDATE USUARIO
	SET clave_usu = @nuevaClave
	WHERE correo_usu = @correo

	SELECT TOP 1 @nombreUsuario = nombreUsuario_usu FROM USUARIO WHERE correo_usu = @correo

	SELECT @nombreUsuario as NombreUsuario;

END