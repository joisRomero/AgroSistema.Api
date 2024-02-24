DECLARE @p_XML_Trabajadores XML

SET @p_XML_Trabajadores = '
<DocumentElement>
	<Trabajador>
		<DescripcionTrabajador>Esclavos para arar</DescripcionTrabajador>
		<CantidadTrabajador>4</CantidadTrabajador>
		<CostoUnitario>2.00</CostoUnitario>
		<CostoTotal>8.00</CostoTotal>
		<IdTipoTrabajador>1</IdTipoTrabajador>
	</Trabajador>
	<Trabajador>
		<DescripcionTrabajador>N3gro para sembrar</DescripcionTrabajador>
		<CantidadTrabajador>5</CantidadTrabajador>
		<CostoUnitario>2.00</CostoUnitario>
		<CostoTotal>10.00</CostoTotal>
		<IdTipoTrabajador>2</IdTipoTrabajador>
	</Trabajador>
</DocumentElement>
'

DECLARE @s_XML_Trabajadores XML = NULL
SET @s_XML_Trabajadores = @p_XML_Trabajadores

IF OBJECT_ID('tempdb..#temp_TablaTrabajadores') IS NOT NULL
	DROP TABLE #temp_TablaTrabajadores

SELECT
	TD.value('(DescripcionTrabajador/text())[1]','varchar(250)') AS DescripcionTrabajador
	,TD.value('(CantidadTrabajador/text())[1]','int') AS CantidadTrabajador
	,TD.value('(CostoUnitario/text())[1]','money') AS CostoUnitario
	,TD.value('(CostoTotal/text())[1]','money') AS CostoTotal
	,TD.value('(IdTipoTrabajador/text())[1]','int') AS IdTipoTrabajador
INTO #temp_TablaTrabajadores
FROM @s_XML_Trabajadores.nodes('/DocumentElement/Trabajador') AS TEMPTABLE(TD)


SELECT * FROM #temp_TablaTrabajadores
