IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EliminarCosechaDetalle')
	DROP PROCEDURE sp_EliminarCosechaDetalle
GO

CREATE PROCEDURE sp_EliminarCosechaDetalle
(
	@idCosechaDetalle int
	,@usuarioElimina varchar(50)
)
AS
BEGIN
	
	UPDATE COSECHA_DETALLE
		SET estado_coseDet = 0,
			usuarioElimina_coseDet = @usuarioElimina,
			fechaElimina_coseDet = GETDATE()
		WHERE
			id_coseDet = @idCosechaDetalle

END