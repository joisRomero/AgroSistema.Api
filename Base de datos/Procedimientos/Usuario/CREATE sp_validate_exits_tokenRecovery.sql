IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_validate_exists_tokenRecovery')
	DROP PROCEDURE sp_validate_exists_tokenRecovery
GO

CREATE PROCEDURE sp_validate_exists_tokenRecovery(
	@p_correo_usu			VARCHAR(250)
	,@p_TokenRecoveryPsw	VARCHAR(6)
)
AS
BEGIN
	DECLARE @p_ValidateExistTokenRecovery INT
	SET @p_ValidateExistTokenRecovery = 0
	
	IF EXISTS (SELECT id_usu FROM USUARIO WHERE correo_usu = @p_correo_usu AND TokenRecoveryPsw=@p_TokenRecoveryPsw)
	BEGIN
		UPDATE USUARIO
			SET ValdtTokenRecoveryPsw			= 1
				,@p_ValidateExistTokenRecovery	= 1
		WHERE correo_usu = @p_correo_usu
	END

	SELECT @p_ValidateExistTokenRecovery AS ValidateExistTokenRecovery
END