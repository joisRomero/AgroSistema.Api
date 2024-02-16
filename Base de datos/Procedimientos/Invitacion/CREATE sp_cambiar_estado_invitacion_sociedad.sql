IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_cambiar_estado_invitacion_sociedad')
	DROP PROCEDURE sp_cambiar_estado_invitacion_sociedad
GO

CREATE PROCEDURE sp_cambiar_estado_invitacion_sociedad(
	@p_id_inviSoc				INT
	,@p_accion					CHAR(1)
	,@p_usuarioModifica_inviSoc VARCHAR(50)
)
AS
BEGIN
	DECLARE @s_id_soc			INT
			,@s_idReceptor_usu	INT

	IF(@p_accion = 'A')
	BEGIN
		UPDATE INVITACION_SOCIEDAD
		SET estadoInvitacion_inviSoc = 1
			,usuarioModifica_inviSoc = @p_usuarioModifica_inviSoc
			,fechaModifica_inviSoc = GETDATE()
		WHERE id_inviSoc = @p_id_inviSoc

		SELECT 
			@s_id_soc = id_soc
			,@s_idReceptor_usu = idReceptor_usu
		FROM INVITACION_SOCIEDAD WHERE id_inviSoc = @p_id_inviSoc
		
		INSERT INTO USUARIO_SOCIEDAD
		(
		esAdministrador_usuSoc,
		estado_usuSoc,
		id_soc,
		id_usu,
		usuarioInserta_usuSoc,
		fechaInserta_usuSoc
		)
		VALUES (
			0,
			1,
			@s_id_soc,
			@s_idReceptor_usu,
			@p_usuarioModifica_inviSoc,
			GETDATE()
		)
	END
	ELSE IF(@p_accion = 'R')
	BEGIN
		UPDATE INVITACION_SOCIEDAD
		SET estadoInvitacion_inviSoc = 2
			,usuarioModifica_inviSoc = @p_usuarioModifica_inviSoc
			,fechaModifica_inviSoc = GETDATE()
		WHERE id_inviSoc = @p_id_inviSoc
	END
END