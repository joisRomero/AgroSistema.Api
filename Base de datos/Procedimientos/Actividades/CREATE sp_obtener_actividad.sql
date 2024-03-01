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
	FROM ACTIVIDAD a
	INNER JOIN TIPO_ACTIVIDAD ta on ta.id_tipoActi = a.id_tipoActi  
	WHERE a.id_acti = @p_id_acti
END
