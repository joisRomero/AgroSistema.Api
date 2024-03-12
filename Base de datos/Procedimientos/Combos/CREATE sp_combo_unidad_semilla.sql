IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_combo_unidad_semilla')
	DROP PROCEDURE sp_combo_unidad_semilla
GO

CREATE PROCEDURE sp_combo_unidad_semilla
AS
BEGIN
	SELECT 
		id_datoComun AS CodigoUnidadSemilla
		,descripcionLarga AS DescripcionLarga
	FROM DATO_COMUN
	WHERE codigoTabla= 7 
	AND codigoFila !=0
	AND estado = 1

END