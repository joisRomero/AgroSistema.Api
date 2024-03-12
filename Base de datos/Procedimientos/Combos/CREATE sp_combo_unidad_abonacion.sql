IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_combo_unidad_abonacion')
	DROP PROCEDURE sp_combo_unidad_abonacion
GO	

CREATE PROCEDURE sp_combo_unidad_abonacion
AS
BEGIN
	SELECT 
		id_datoComun AS CodigoUnidadAbonacion
		,descripcionLarga AS DescripcionLarga
	FROM DATO_COMUN
	WHERE codigoTabla = 4
	AND codigoFila != 0
	AND estado = 1
END	