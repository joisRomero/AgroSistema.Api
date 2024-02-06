IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_AgregarSociedad')
	DROP PROCEDURE sp_AgregarSociedad
GO

CREATE PROCEDURE sp_AgregarSociedad
(
	@nombreSociedad varchar(100)
	,@idUsuario int
	,@usuarioInserta varchar(50)
)
AS
BEGIN

	DECLARE @idNewSociedad int;

	INSERT INTO SOCIEDAD 
	(
		nombre_soc
		,fechaCreacion_soc
		,estado_soc
		,usuarioInserta_soc
		,fechaInserta_soc
	)
	VALUES(
		@nombreSociedad
		,GETDATE()
		,1
		,@usuarioInserta
		,GETDATE()
	)

	select @idNewSociedad = scope_identity()

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
		1,
		1,
		@idNewSociedad,
		@idUsuario,
		@usuarioInserta,
		GETDATE()
	)

END