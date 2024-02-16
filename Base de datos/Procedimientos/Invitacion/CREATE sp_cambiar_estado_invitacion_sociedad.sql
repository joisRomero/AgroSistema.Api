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
	IF(@p_accion = 'A')
	BEGIN
		UPDATE INVITACION_SOCIEDAD
		SET estadoInvitacion_inviSoc = 1
			,usuarioModifica_inviSoc = @p_usuarioModifica_inviSoc
			,fechaModifica_inviSoc = GETDATE()
		WHERE id_inviSoc = @p_id_inviSoc
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