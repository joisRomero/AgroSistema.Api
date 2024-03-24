IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_eliminar_listaFumigacionDetalle')
	DROP PROCEDURE sp_eliminar_listaFumigacionDetalle
GO

CREATE PROCEDURE sp_eliminar_listaFumigacionDetalle(
	@p_id_acti INT
	,@p_XML_Fumigacion_Detalle	XML	NULL
	,@p_usuarioElimina_fumiDet VARCHAR(50)
)
AS
BEGIN
	IF OBJECT_ID('tempdb..#temp_TablaFumigacionDetalle') IS NOT NULL
	DROP TABLE #temp_TablaFumigacionDetalle

	DECLARE @s_XML_Fumigacion_Detalle XML = NULL
	SET @s_XML_Fumigacion_Detalle = @p_XML_Fumigacion_Detalle

	SELECT
		TD.value('(IdFumigacionDetalle/text())[1]','int')	AS IdFumigacionDetalle
	INTO #temp_TablaFumigacionDetalle
	FROM @s_XML_Fumigacion_Detalle.nodes('/DocumentElement/FumigacionDetalle') AS TEMPTABLE(TD)

	UPDATE fd
		SET fd.estado_fumiDet = 0
			,fd.usuarioElimina_fumiDet = @p_usuarioElimina_fumiDet
			,fd.fechaElimina_fumiDet = dbo.GETDATENEW()
	FROM FUMIGACION_DETALLE fd
	INNER JOIN FUMIGACION f on f.id_fumi = fd.id_fumi
	WHERE fd.id_fumiDet NOT IN (SELECT IdFumigacionDetalle FROM #temp_TablaFumigacionDetalle)
	AND f.id_acti = @p_id_acti
END