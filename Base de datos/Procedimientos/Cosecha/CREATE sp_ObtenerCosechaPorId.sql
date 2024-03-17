IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerCosechaPorId')
	DROP PROCEDURE sp_ObtenerCosechaPorId
GO

CREATE PROCEDURE sp_ObtenerCosechaPorId
(
	@idCosecha int
)
AS
BEGIN

	SELECT 
		id_cose AS IdCosecha,
		fecha_cose AS FechaCosecha,
		descripcion_cose AS Descripcion,
		id_camp AS IdCampania
	FROM 
		COSECHA
	WHERE 
		id_cose = @idCosecha

END