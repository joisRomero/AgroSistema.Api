IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_combo_unidad_fumigacion')
	DROP PROCEDURE sp_combo_unidad_fumigacion
GO	

CREATE PROCEDURE sp_combo_unidad_fumigacion
AS
BEGIN
	SELECT 
		id_datoComun AS CodigoUnidadFumigacion
		,descripcionLarga AS DescripcionLarga
	FROM DATO_COMUN
	WHERE codigoTabla = 5
	AND codigoFila != 0
	AND estado = 1
END