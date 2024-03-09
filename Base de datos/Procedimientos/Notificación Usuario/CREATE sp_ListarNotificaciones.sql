USE [agro_sistema_bd]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ListarNotificaciones')
	DROP PROCEDURE sp_ListarNotificaciones
GO

CREATE PROCEDURE sp_ListarNotificaciones (
	@idUsuario INT,
	@idCaso INT
)
AS
BEGIN
	
	IF(@idCaso = 1) -- Listar Notificaciones Menú
	BEGIN

		SELECT TOP 10
			id_not AS IdNotificacion,
			id_usu AS IdUsuario,
			descripcion_not AS Descripcion,
			fechaCreacion_not AS FechaCreacion
		FROM
			NOTIFICACION_USUARIO
		WHERE
			id_usu = @idUsuario
		ORDER BY
			fechaCreacion_not DESC

	END
	ELSE IF (@idCaso = 2) -- Listar Notificaciones Ver Todo
	BEGIN

		SELECT
			id_not AS IdNotificacion,
			id_usu AS IdUsuario,
			descripcion_not AS Descripcion,
			fechaCreacion_not AS FechaCreacion
		FROM
			NOTIFICACION_USUARIO
		WHERE
			id_usu = @idUsuario
		ORDER BY
			fechaCreacion_not DESC

	END

END