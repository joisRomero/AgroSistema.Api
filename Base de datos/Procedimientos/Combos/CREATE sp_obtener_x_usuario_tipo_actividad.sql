IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_x_usuario_tipo_actividad')
	DROP PROCEDURE sp_obtener_x_usuario_tipo_actividad
GO

CREATE PROCEDURE sp_obtener_x_usuario_tipo_actividad(
	@p_id_usu	INT
)
AS 
BEGIN
	SELECT 
		id_tipoActi	AS IdTipoActividad
		,nombre_tipoActi AS NombreTipoActividad
	FROM TIPO_ACTIVIDAD
	WHERE (id_usu = @p_id_usu 
		OR id_usu IS NULL)
		AND estado_tipoActi = '1'
	ORDER BY
		realizadaPor_tipoActi ASC
END