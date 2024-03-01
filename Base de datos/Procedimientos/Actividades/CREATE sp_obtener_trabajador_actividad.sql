IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_trabajador_actividad')
	DROP PROCEDURE sp_obtener_trabajador_actividad
GO

CREATE PROCEDURE sp_obtener_trabajador_actividad(
	@p_id_acti INT
)
AS
BEGIN
	SELECT 
		t.id_trab				AS IdTrabajador
		,t.descripcion_trab		AS DescripcionTrabajador
		,t.cantidad_trab		AS CantidadTrabajador
		,t.costoUnitario_trab	AS CostoUnitario
		,t.costoTotal_trab		AS CostoTotal
		,t.id_tipoTrab			AS IdTipoTrabajador
		,tt.descripcion_tipoTrab AS DescripcionTipoTrabajador
	FROM TRABAJADOR t
	INNER JOIN TIPO_TRABAJADOR tt on tt.id_tipoTrab = t.id_tipoTrab
	WHERE t.id_acti = @p_id_acti
END
