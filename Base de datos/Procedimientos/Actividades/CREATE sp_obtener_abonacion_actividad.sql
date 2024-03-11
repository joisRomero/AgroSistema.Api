IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_abonacion_actividad')
	DROP PROCEDURE sp_obtener_abonacion_actividad
GO

CREATE PROCEDURE sp_obtener_abonacion_actividad (
	@p_id_acti INT
)
AS
BEGIN
	SELECT 
		a.id_abonaci AS IdAbonacion
		,a.cantidad_abonaci AS CantidadAbonacion
		,a.unidadDatoComun AS UnidadDatoComunAbonacion
		,dc.descripcionCorta AS UnidadDescripcionAbonacion
		,a.id_abono AS IdAbono
	FROM ABONACION a
	LEFT JOIN DATO_COMUN dc on dc.codigoTabla = 4 AND dc.id_datoComun = a.unidadDatoComun
	WHERE a.id_acti = @p_id_acti
END

