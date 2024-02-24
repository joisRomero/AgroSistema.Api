USE agro_sistema_bd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerTipoGastoPorId')
	DROP PROCEDURE sp_ObtenerTipoGastoPorId
GO

CREATE PROCEDURE sp_ObtenerTipoGastoPorId
(
	@idTipoGasto int
)
AS
BEGIN

	SELECT 
		id_tipoGasto AS IdTipoGasto,
		nombre_tipoGasto AS NombreTipoGasto,
		descripcion_tipoGasto AS Descripcion
	FROM 
		TIPO_GASTO
	WHERE 
		id_tipoGasto = @idTipoGasto

END