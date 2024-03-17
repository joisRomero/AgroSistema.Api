DECLARE @p_XML_Trabajador XML = NULL

SET @p_XML_Trabajador = '
<DocumentElement>
	<Trabajador>
		<IdTrabajador>1</IdTrabajador>
	</Trabajador>
	<Trabajador>
		<IdTrabajador>2</IdTrabajador>
	</Trabajador>
	<Trabajador>
		<IdTrabajador>3</IdTrabajador>
	</Trabajador>
</DocumentElement>
'

DECLARE @s_XML_Trabajador XML --= NULL
SET @s_XML_Trabajador = @p_XML_Trabajador

	IF OBJECT_ID('tempdb..#temp_TablaTrabajadores') IS NOT NULL
		DROP TABLE #temp_TablaTrabajadores

	SELECT
		TD.value('(IdTrabajador/text())[1]','int') AS IdTrabajador
	INTO #temp_TablaTrabajadores
	FROM @s_XML_Trabajador.nodes('/DocumentElement/Trabajador') AS TEMPTABLE(TD)

	SELECT * FROM #temp_TablaTrabajadores

	SELECT * 
	FROM TRABAJADOR 
	WHERE id_trab not in (SELECT IdTrabajador FROM #temp_TablaTrabajadores)
