IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_guardar_token_recuperacion')
	DROP PROCEDURE sp_guardar_token_recuperacion
GO

CREATE PROCEDURE sp_guardar_token_recuperacion(
	@p_correo_usu			VARCHAR(250)
	,@p_TokenRecoveryPsw	VARCHAR(6)
)
AS
BEGIN
	DECLARE @s_id_usu INT

	SET @s_id_usu = (SELECT id_usu FROM USUARIO WHERE correo_usu = @p_correo_usu)

	IF(@s_id_usu != NULL OR @s_id_usu !=0)
	BEGIN
		UPDATE USUARIO
			SET TokenRecoveryPsw		= @p_TokenRecoveryPsw
				,ValdtTokenRecoveryPsw	= 0
		WHERE id_usu = @s_id_usu
	END
END