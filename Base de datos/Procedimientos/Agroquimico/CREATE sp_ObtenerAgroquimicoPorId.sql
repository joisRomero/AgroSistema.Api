
IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ObtenerAgroquimicoPorId')
	DROP PROCEDURE sp_ObtenerAgroquimicoPorId
GO

CREATE PROCEDURE sp_ObtenerAgroquimicoPorId
(
	@idAgroquimico int
)
AS
BEGIN

	SELECT 
		a.id_agroqui AS IdAgroquimico,
		a.nombre_agroqui AS NombreAgroquimico,
		a.descripcion_agroqui AS Descripcion,
		a.id_tipoAgroqui AS IdTipoAgroquimico,
		ta.nombre_tipoAgroqui AS NombreTipoAgroquimico
	FROM 
		AGROQUIMICO a
		INNER JOIN TIPO_AGROQUIMICO ta ON a.id_tipoAgroqui = ta.id_tipoAgroqui
	WHERE 
		a.id_agroqui = @idAgroquimico

END