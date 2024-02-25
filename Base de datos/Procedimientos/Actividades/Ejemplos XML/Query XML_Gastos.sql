DECLARE @p_XML_Gastos XML

SET @p_XML_Gastos = '
<DocumentElement>
	<Gastos>
		<Descripcion>Gasto por COCA</Descripcion>
		<Cantidad>4</Cantidad>
		<CostoUnitario>15.00</CostoUnitario>
		<CostoTotal>60.00</CostoTotal>
		<IdTipoGasto>1</IdTipoGasto>
	</Gastos>
	<Gastos>
		<Descripcion>Gasto por TUSI</Descripcion>
		<Cantidad>10</Cantidad>
		<CostoUnitario>25.00</CostoUnitario>
		<CostoTotal>250.00</CostoTotal>
		<IdTipoGasto>2</IdTipoGasto>
	</Gastos>
</DocumentElement>
'

DECLARE @s_XML_Gastos XML = NULL
SET @s_XML_Gastos = @p_XML_Gastos


SELECT
	TD.value('(Descripcion/text())[1]','varchar(250)') AS DescripcionTrabajador
	,TD.value('(Cantidad/text())[1]','int') AS CantidadTrabajador
	,TD.value('(CostoUnitario/text())[1]','money') AS CostoUnitario
	,TD.value('(CostoTotal/text())[1]','money') AS CostoTotal
	--,TD.value('(FechaGasto/text())[1]','datetime') AS FechaGasto
	,TD.value('(IdTipoGasto/text())[1]','int') AS IdTipoGasto
INTO #temp_TablaGastos
FROM @s_XML_Gastos.nodes('/DocumentElement/Gastos') AS TEMPTABLE(TD)


SELECT * FROM #temp_TablaGastos