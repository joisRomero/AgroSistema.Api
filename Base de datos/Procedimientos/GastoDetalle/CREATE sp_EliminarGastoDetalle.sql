USE [agro_sistema_bd]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EliminarGastoDetalle')
	DROP PROCEDURE sp_EliminarGastoDetalle
GO

CREATE PROCEDURE sp_EliminarGastoDetalle
(
	@idGastoDetalle int
	,@usuarioElimina varchar(50)
)
AS
BEGIN
	
	UPDATE GASTO_DETALLE
		SET estado_gastoDet = 0,
			usuarioElimina_gastoDet = @usuarioElimina,
			fechaElimina_gastoDet = GETDATE()
		WHERE
			id_gastoDet = @idGastoDetalle

END