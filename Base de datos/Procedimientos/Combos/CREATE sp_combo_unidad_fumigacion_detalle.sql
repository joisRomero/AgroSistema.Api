IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_combo_unidad_fumigacion_detalle')
	DROP PROCEDURE sp_combo_unidad_fumigacion_detalle
GO

CREATE PROCEDURE sp_combo_unidad_fumigacion_detalle
AS
BEGIN
	SELECT
		id_datoComun AS CodigoUnidadFumigacionDetalle
		,descripcionLarga AS DescripcionLarga
	FROM DATO_COMUN
	WHERE codigoTabla = 6
	AND codigoFila != 0
	AND estado = 1
END