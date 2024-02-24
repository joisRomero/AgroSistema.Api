USE [agro_sistema_bd]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EditarTipoGasto')
	DROP PROCEDURE sp_EditarTipoGasto
GO

CREATE PROCEDURE sp_EditarTipoGasto
(
	@idTipoGasto int
	,@nombreTipoGasto varchar(100)
	,@descripcion varchar(200)
	,@usuarioModifica varchar(50)
)
AS
BEGIN

	UPDATE TIPO_GASTO
	SET 
		nombre_tipoGasto = @nombreTipoGasto
		,descripcion_tipoGasto = @descripcion
		,usuarioModifica_tipoGasto = @usuarioModifica
		,fechaModifica_tipoGasto = GETDATE()
	WHERE id_tipoGasto=@idTipoGasto

END