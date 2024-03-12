
IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EliminarAbono')
	DROP PROCEDURE sp_EliminarAbono
GO

CREATE PROCEDURE sp_EliminarAbono
(
	@idAbono int
	,@usuarioElimina varchar(50)
)
AS
BEGIN
	
	UPDATE ABONO
		SET estado_abono = 0,
			usuarioElimina_abono = @usuarioElimina,
			fechaElimina_abono = GETDATE()
		WHERE
			id_abono = @idAbono

END