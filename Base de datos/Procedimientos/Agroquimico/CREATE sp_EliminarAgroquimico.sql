USE [agro_sistema_bd]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EliminarAgroquimico')
	DROP PROCEDURE sp_EliminarAgroquimico
GO

CREATE PROCEDURE sp_EliminarAgroquimico
(
	@idAgroquimico int
	,@usuarioElimina varchar(50)
)
AS
BEGIN
	
	UPDATE AGROQUIMICO
		SET estado_agrpqui = 0,
			usuarioElimina_agrpqui = @usuarioElimina,
			fechaElimina_agrpqui = GETDATE()
		WHERE
			id_agroqui = @idAgroquimico

END