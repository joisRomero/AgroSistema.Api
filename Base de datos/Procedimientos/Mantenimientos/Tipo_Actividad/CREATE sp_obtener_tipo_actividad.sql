IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_tipo_actividad')
	DROP PROCEDURE sp_obtener_tipo_actividad
GO

CREATE PROCEDURE sp_obtener_tipo_actividad(
	@p_id_tipoActi INT
)
AS
BEGIN
	SELECT 
		id_tipoActi		AS IdTipoActividad
		,nombre_tipoActi	AS NombreTipoActividad
		,realizadaPor_tipoActi	AS RealizadaPorTipoActividad
		,descripcion_tipoActi	AS DescripcionTipoActividad
	FROM TIPO_ACTIVIDAD
	WHERE id_tipoActi = @p_id_tipoActi

END