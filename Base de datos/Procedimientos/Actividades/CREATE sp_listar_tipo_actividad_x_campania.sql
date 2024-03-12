IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_listar_tipo_actividad_x_campania')
	DROP PROCEDURE sp_listar_tipo_actividad_x_campania
GO

CREATE PROCEDURE sp_listar_tipo_actividad_x_campania(
	@p_id_camp INT
)
AS
BEGIN
	SELECT DISTINCT
		ta.nombre_tipoActi
		,ta.id_tipoActi
		--* 
	FROM ACTIVIDAD a
	LEFT JOIN TIPO_ACTIVIDAD ta on ta.id_tipoActi = a.id_tipoActi
	WHERE a.id_camp = @p_id_camp
END