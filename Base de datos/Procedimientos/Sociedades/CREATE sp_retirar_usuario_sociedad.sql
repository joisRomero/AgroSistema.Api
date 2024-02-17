IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_retirar_usuario_sociedad')
	DROP PROCEDURE sp_retirar_usuario_sociedad
GO

CREATE PROCEDURE sp_retirar_usuario_sociedad(
	@p_id_usu	INT
	,@p_id_soc	INT
	,@p_usuarioModifica_usuSoc VARCHAR(50)
)
AS
BEGIN
	UPDATE USUARIO_SOCIEDAD
	SET estado_usuSoc = 0
		,esAdministrador_usuSoc = 0
		,usuarioModifica_usuSoc = @p_usuarioModifica_usuSoc
		,fechaModifica_usuSoc = GETDATE()
	WHERE 
	id_usu = @p_id_usu 
	AND id_soc = @p_id_soc
END