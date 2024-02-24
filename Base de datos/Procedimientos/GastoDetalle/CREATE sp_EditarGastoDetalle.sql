USE [agro_sistema_bd]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EditarGastoDetalle')
	DROP PROCEDURE sp_EditarGastoDetalle
GO

CREATE PROCEDURE sp_EditarGastoDetalle
(
	@idGastoDetalle int
	,@idTipoGasto int
	,@fechaGasto datetime
	,@cantidad int
	,@costoUnitario decimal(18,2)
	,@costoTotal decimal(18,2)
	,@descripcion varchar(200)
	,@usuarioModifica varchar(50)
)
AS
BEGIN

	UPDATE GASTO_DETALLE
	SET 
		id_tipoGasto = @idTipoGasto
		,fecha_gastoDet = @fechaGasto
		,cantidad_gastoDet = @cantidad
		,costoUnitario_gastoDet = @costoUnitario
		,costoTotal_gastoDet = @costoTotal
		,descripcion_gastoDet = @descripcion
		,usuarioModifica_gastoDet = @usuarioModifica
		,fechaModifica_gastoDet = GETDATE()
	WHERE id_gastoDet = @idGastoDetalle

END