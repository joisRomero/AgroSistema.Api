IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_validate_exits_correo')
	DROP PROCEDURE sp_validate_exits_correo
GO

CREATE PROCEDURE sp_validate_exits_correo(
	@p_correo_usu	VARCHAR(250)
)
AS
BEGIN
	DECLARE @p_ValidateExistCorreo INT
	SET @p_ValidateExistCorreo = 0
	
	IF EXISTS (SELECT id_usu FROM USUARIO WHERE correo_usu = @p_correo_usu)
	BEGIN
		SET @p_ValidateExistCorreo = 1
	END

	SELECT @p_ValidateExistCorreo AS ValidateExistCorreo
END