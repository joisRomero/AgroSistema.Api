IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerCosechaDetallePorId')
	DROP PROCEDURE sp_ObtenerCosechaDetallePorId
GO

CREATE PROCEDURE sp_ObtenerCosechaDetallePorId
(
	@idCosecha int
)
AS
BEGIN

	SELECT 
		id_coseDet AS IdCosechaDetalle,
		cantidad_coseDet AS Cantidad,
		unidadDatoComun_coseDet AS Unidad,
		calidadDatoComun_coseDet AS Calidad,
		descripcion_coseDet AS Descripcion
	FROM 
		COSECHA_DETALLE
	WHERE 
		id_cose = @idCosecha
		AND estado_coseDet = 1

END