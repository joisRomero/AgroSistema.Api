IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_gastos_actividad')
	DROP PROCEDURE sp_obtener_gastos_actividad
GO

CREATE PROCEDURE sp_obtener_gastos_actividad (
	@p_id_acti INT
)
AS
BEGIN
	SELECT
		gd.id_gastoDet				AS IdGastoDetalle
		,gd.descripcion_gastoDet	AS DescripcionGastoDetalle
		,gd.cantidad_gastoDet		AS CantidadGastoDetalle
		,gd.costoUnitario_gastoDet	AS CostoUnitarioGastoDetalle
		,gd.costoTotal_gastoDet		AS CostoTotalGastoDetalle
		,gd.fecha_gastoDet			AS FechaGastoDetalle
		,gd.id_tipoGasto			AS IdTipoGasto
		,tg.nombre_tipoGasto		AS NombreTipoGasto
	FROM GASTO_DETALLE gd
	INNER JOIN TIPO_GASTO tg on tg.id_tipoGasto = gd.id_tipoGasto
	WHERE gd.id_acti = @p_id_acti and gd.estado_gastoDet = 1
END