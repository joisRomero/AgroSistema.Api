USE [agro_sistema_bd]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_AgregarNotificacion')
	DROP PROCEDURE sp_AgregarNotificacion
GO

CREATE PROCEDURE sp_AgregarNotificacion (
	@idUsuario INT,
	@descripcion VARCHAR(150)
)
AS
BEGIN
	
	INSERT INTO NOTIFICACION_USUARIO
	(
		id_usu,
		descripcion_not,
		fechaCreacion_not
	)
	VALUES
	(
		@idUsuario,
		@descripcion,
		GETDATE()
	)

END