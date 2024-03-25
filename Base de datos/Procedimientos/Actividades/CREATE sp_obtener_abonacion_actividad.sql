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
		,ab.descripcion_abono AS DescripcionAbono
	FROM ABONACION a
	LEFT JOIN ABONO ab on ab.id_abono = a.id_abono
	LEFT JOIN DATO_COMUN dc on dc.codigoTabla = 4 AND dc.id_datoComun = a.unidadDatoComun
	WHERE a.id_acti = @p_id_acti AND a.estado_abonaci = 1
END

