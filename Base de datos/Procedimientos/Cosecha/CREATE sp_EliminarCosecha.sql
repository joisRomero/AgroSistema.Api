IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EliminarCosecha')
	DROP PROCEDURE sp_EliminarCosecha
GO

CREATE PROCEDURE sp_EliminarCosecha
(
	@idCosecha int
	,@usuarioElimina varchar(50)
)
AS
BEGIN
	
	UPDATE COSECHA
		SET estado_cose = 0,
			usuarioElimina_cose = @usuarioElimina,
			fechaElimina_cose = GETDATE()
		WHERE
			id_cose = @idCosecha

	UPDATE COSECHA_DETALLE
		SET estado_coseDet = 0,
			usuarioElimina_coseDet = @usuarioElimina,
			fechaElimina_coseDet = GETDATE()
		WHERE
			id_cose = @idCosecha

END