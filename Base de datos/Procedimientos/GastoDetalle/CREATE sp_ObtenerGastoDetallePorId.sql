USE agro_sistema_bd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerGastoDetallePorId')
	DROP PROCEDURE sp_ObtenerGastoDetallePorId
GO

CREATE PROCEDURE sp_ObtenerGastoDetallePorId
(
	@idGastoDetalle int
)
AS
BEGIN

	SELECT 
		id_gastoDet AS IdGastoDetalle,
		id_tipoGasto AS IdTipoGasto,
		fecha_gastoDet AS FechaGasto,
		cantidad_gastoDet AS Cantidad,
		costoUnitario_gastoDet AS CostoUnitario,
		costoTotal_gastoDet AS CostoTotal,
		descripcion_gastoDet AS Descripcion
	FROM 
		GASTO_DETALLE
	WHERE 
		id_gastoDet = @idGastoDetalle

END