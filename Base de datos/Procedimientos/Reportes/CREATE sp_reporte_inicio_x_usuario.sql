IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_reporte_inicio_x_usuario')
	DROP PROCEDURE sp_reporte_inicio_x_usuario
GO

CREATE PROCEDURE sp_reporte_inicio_x_usuario(
	@p_id_usu INT
)
AS
BEGIN
	IF OBJECT_ID('tempdb..#temp_TotalCampaniaEstado') IS NOT NULL
		DROP TABLE #temp_TotalCampaniaEstado

	;WITH 
	TablaTotalEstadoProcesoCampania
	AS
	(
		SELECT 
		estado_proceso_camp AS EstadoProcesoCampania
		,COUNT(c.estado_proceso_camp) AS SumatoriaCampia_X_Estados
		FROM CAMPANIA c
		LEFT JOIN SOCIEDAD s on s.id_soc = c.id_soc
		LEFT JOIN USUARIO_SOCIEDAD u on u.id_soc = s.id_soc
		WHERE u.id_usu = @p_id_usu OR c.id_usu = @p_id_usu
		GROUP BY estado_proceso_camp
	)
	SELECT 
		EstadoProcesoCampania
		,SumatoriaCampia_X_Estados
	INTO #temp_TotalCampaniaEstado
	FROM TablaTotalEstadoProcesoCampania
	SELECT * FROM #temp_TotalCampaniaEstado
	SELECT *
	FROM (
		SELECT EstadoProcesoCampania, SumatoriaCampia_X_Estados
		FROM #temp_TotalCampaniaEstado
	) AS SourceTable
	PIVOT (
		MAX(SumatoriaCampia_X_Estados)
		FOR EstadoProcesoCampania IN ([P], [T], [R])
	) AS PivotTable;
END