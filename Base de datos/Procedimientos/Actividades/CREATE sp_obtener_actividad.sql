IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_actividad')
	DROP PROCEDURE sp_obtener_actividad
GO

CREATE PROCEDURE sp_obtener_actividad(
	@p_id_acti	INT
)
AS
BEGIN
	SELECT 
		a.id_acti AS IdActividad
		,a.fecha_acti AS FechaActividad
		,a.descripcion_acti AS DescripcionActividad
		,a.id_tipoActi AS IdTipoActividad
		,ta.descripcion_tipoActi AS DescripcionTipoActividad
		,a.cantidadSemilla_acti AS CantidadSemilla
		,a.unidadSemillaDatoComun_acti AS UnidadSemilla
		,dc7.descripcionLarga AS UnidadDescripcionSemilla
		,f.id_fumi AS IdFumigacion
		,f.cantidad_fumi AS CantidadFumigacion
		,f.unidadDatoComun_fumi AS UnidadDatoComunFumigacion
		,dc.descripcionLarga AS UnidadDescripcionFumigacion
	FROM ACTIVIDAD a
	INNER JOIN TIPO_ACTIVIDAD ta on ta.id_tipoActi = a.id_tipoActi
	LEFT JOIN FUMIGACION f on f.id_acti = a.id_acti 
	LEFT JOIN DATO_COMUN dc on dc.codigoTabla = 5 AND dc.id_datoComun = f.unidadDatoComun_fumi
	LEFT JOIN DATO_COMUN dc7 on dc7.codigoTabla = 7 AND dc7.id_datoComun = a.unidadSemillaDatoComun_acti
	WHERE a.id_acti = @p_id_acti 
END
