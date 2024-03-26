IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_reporteInicio_sociedadesTop_x_usuario')
	DROP PROCEDURE sp_reporteInicio_sociedadesTop_x_usuario
GO

CREATE PROCEDURE sp_reporteInicio_sociedadesTop_x_usuario(
	@p_id_usu INT
)
AS
BEGIN
	IF OBJECT_ID('tempdb..#temp_SociedadesTop') IS NOT NULL
		DROP TABLE #temp_SociedadesTop

	SELECT TOP(5)
		s.nombre_soc AS NombreSociedad
		,s.fechaCreacion_soc AS FechaCreacion
	INTO #temp_SociedadesTop
	FROM SOCIEDAD s
	LEFT JOIN USUARIO_SOCIEDAD u on u.id_soc = s.id_soc
	WHERE u.id_usu = @p_id_usu
	ORDER BY s.fechaCreacion_soc desc

	SELECT
		NombreSociedad
	FROM #temp_SociedadesTop
END