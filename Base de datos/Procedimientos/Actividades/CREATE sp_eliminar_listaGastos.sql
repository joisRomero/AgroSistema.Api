IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_eliminar_listaGastos')
	DROP PROCEDURE sp_eliminar_listaGastos
GO

CREATE PROCEDURE sp_eliminar_listaGastos(
	@p_XML_Gastos XML
	,@p_usuarioElimina_gastoDet VARCHAR(50)
)
AS
BEGIN
	IF OBJECT_ID('tempdb..#temp_TablaGastos') IS NOT NULL
		DROP TABLE #temp_TablaGastos

	DECLARE @s_XML_Gastos XML

	SET @s_XML_Gastos = @p_XML_Gastos

	SELECT
		TD.value('(IdGasto/text())[1]','int') AS IdGasto
	INTO #temp_TablaGastos
	FROM @s_XML_Gastos.nodes('/DocumentElement/Gastos') AS TEMPTABLE(TD)

	UPDATE gd
		SET gd.estado_gastoDet = 0
			,gd.usuarioElimina_gastoDet = @p_usuarioElimina_gastoDet
			,gd.fechaElimina_gastoDet = dbo.GETDATENEW()
	FROM GASTO_DETALLE gd
	WHERE gd.id_gastoDet NOT IN (SELECT IdGasto FROM #temp_TablaGastos)

END