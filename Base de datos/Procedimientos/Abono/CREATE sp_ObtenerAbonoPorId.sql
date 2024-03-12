IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerAbonoPorId')
	DROP PROCEDURE sp_ObtenerAbonoPorId
GO

CREATE PROCEDURE sp_ObtenerAbonoPorId
(
	@idAbono int
)
AS
BEGIN

	SELECT 
		id_abono AS IdAbono,
		nombre_abono AS NombreAbono,
		descripcion_abono AS Descripcion
	FROM 
		ABONO
	WHERE 
		id_abono = @idAbono

END