USE [agro_sistema_bd]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EliminarTipoGasto')
	DROP PROCEDURE sp_EliminarTipoGasto
GO

CREATE PROCEDURE sp_EliminarTipoGasto
(
	@idTipoGasto int
	,@usuarioElimina varchar(50)
)
AS
BEGIN
	
	UPDATE TIPO_GASTO
		SET estado_tipoGasto = 0,
			usuarioElimina_tipoGasto = @usuarioElimina,
			fechaElimina_tipoGasto = GETDATE()
		WHERE
			id_tipoGasto = @idTipoGasto

END