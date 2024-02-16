IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_registrar_invitacion_sociedad')
	DROP PROCEDURE sp_registrar_invitacion_sociedad
GO

CREATE PROCEDURE sp_registrar_invitacion_sociedad(
	@p_idEmisor_usu				INT
	,@p_idReceptor_usu			INT
	,@p_id_inviSoc				INT
	,@p_usuarioInserta_inviSoc	VARCHAR(50)
)
AS
BEGIN
	INSERT INTO INVITACION_SOCIEDAD(
		idEmisor_usu
		,idReceptor_usu
		,id_soc
		,estadoInvitacion_inviSoc
		,estadoEliminado_inviSoc
		,usuarioInserta_inviSoc
		,fechaInserta_inviSoc
	)
	VALUES(
		@p_idEmisor_usu
		,@p_idReceptor_usu
		,@p_id_inviSoc
		,0
		,0
		,@p_usuarioInserta_inviSoc
		,GETDATE()
	)
END