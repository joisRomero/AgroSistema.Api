IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_fumigacion_actividad')
	DROP PROCEDURE sp_obtener_fumigacion_actividad
GO

CREATE PROCEDURE sp_obtener_fumigacion_actividad(
	@p_id_fumi INT
)
AS
BEGIN
	SELECT
		fd.id_fumiDet AS IdFumigacionDetalle
		,fd.cantidad_fumiDet as CantidadFumigacionDetalle
		,fd.unidadDatoComun_fumiDet AS UnidadDatoComunFumigacionDetalle
		,dc.descripcionCorta AS UnidadDescripcionFumigacionDetalle
		,fd.id_agroqui AS IdAgroQuimico
		
	FROM FUMIGACION_DETALLE fd
	LEFT JOIN DATO_COMUN dc on dc.codigoTabla = 6 AND dc.id_datoComun = fd.unidadDatoComun_fumiDet
	WHERE fd.id_fumi = @p_id_fumi
END