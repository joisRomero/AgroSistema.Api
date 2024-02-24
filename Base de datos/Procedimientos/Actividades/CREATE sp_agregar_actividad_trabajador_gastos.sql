IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_agregar_actividad_trabajador_gastos')
	DROP PROCEDURE sp_agregar_actividad_trabajador_gastos
GO

CREATE PROCEDURE sp_agregar_actividad_trabajador_gastos(
	@p_fecha_acti datetime
	,@p_descripcion_acti VARCHAR(250)
	,@p_cantidadSemilla_acti INT
	,@p_unidadSemillaDatoComun_acti INT
	,@p_id_camp	INT	NULL
	,@p_id_tipoActi	INT NULL
	,@p_usuarioInserta_acti VARCHAR(50)
	,@p_XML_Trabajadores XML
	,@p_XML_Gastos XML
)
AS 
BEGIN TRY
	IF OBJECT_ID('tempdb..#temp_TablaTrabajadores') IS NOT NULL
		DROP TABLE #temp_TablaTrabajadores
		
	IF OBJECT_ID('tempdb..#temp_TablaGastos') IS NOT NULL
		DROP TABLE #temp_TablaGastos
		
	DECLARE @s_XML_Trabajadores XML = NULL
	DECLARE @s_XML_Gastos XML = NULL
	DECLARE @s_id_acti INT

	SET @s_XML_Trabajadores = @p_XML_Trabajadores
	SET @s_XML_Gastos = @p_XML_Gastos

	SELECT
		TD.value('(DescripcionTrabajador/text())[1]','varchar(250)') AS DescripcionTrabajador
		,TD.value('(CantidadTrabajador/text())[1]','int') AS CantidadTrabajador
		,TD.value('(CostoUnitario/text())[1]','money') AS CostoUnitario
		,TD.value('(CostoTotal/text())[1]','money') AS CostoTotal
		,TD.value('(IdTipoTrabajador/text())[1]','int') AS IdTipoTrabajador
	INTO #temp_TablaTrabajadores
	FROM @s_XML_Trabajadores.nodes('/DocumentElement/Trabajador') AS TEMPTABLE(TD)

	SELECT
		TD.value('(Descripcion/text())[1]','varchar(250)') AS DescripcionGasto
		,TD.value('(Cantidad/text())[1]','int') AS CantidadGasto
		,TD.value('(CostoUnitario/text())[1]','money') AS CostoUnitario
		,TD.value('(CostoTotal/text())[1]','money') AS CostoTotal
		,TD.value('(IdTipoGasto/text())[1]','int') AS IdTipoGasto
	INTO #temp_TablaGastos
	FROM @s_XML_Gastos.nodes('/DocumentElement/Gastos') AS TEMPTABLE(TD)

	BEGIN TRANSACTION
		INSERT INTO ACTIVIDAD(
			fecha_acti
			,descripcion_acti
			,cantidadSemilla_acti
			,unidadSemillaDatoComun_acti
			,id_camp
			,id_tipoActi
			,estado_acti
			,usuarioInserta_acti
			,fechaInserta_acti
		)
		VALUES
		(
			@p_fecha_acti
			,@p_descripcion_acti
			,@p_cantidadSemilla_acti
			,@p_unidadSemillaDatoComun_acti
			,@p_id_camp
			,@p_id_tipoActi
			,1
			,@p_usuarioInserta_acti
			,GETDATE()
		)
		SET @s_id_acti = (SELECT @@IDENTITY);

		INSERT INTO TRABAJADOR(
			descripcion_trab
			,cantidad_trab
			,costoUnitario_trab
			,costoTotal_trab
			,id_acti
			,id_tipoTrab
			,estado_trab
			,usuarioInserta_trab
			,fechaInserta_trab
		)
		SELECT
			DescripcionTrabajador
			,CantidadTrabajador
			,CostoUnitario
			,CostoTotal
			,@s_id_acti
			,IdTipoTrabajador
			,1
			,@p_usuarioInserta_acti
			,GETDATE()
		FROM #temp_TablaTrabajadores

		INSERT INTO GASTO_DETALLE(
			descripcion_gastoDet
			,cantidad_gastoDet
			,costoUnitario_gastoDet
			,costoTotal_gastoDet
			,fecha_gastoDet
			,id_tipoGasto
			,id_acti
			,id_camp
			,usuarioInserta_gastoDet
			,fechaInserta_gastoDet
		)
		SELECT
			DescripcionGasto
			,CantidadGasto
			,CostoUnitario
			,CostoTotal
			,@p_fecha_acti
			,IdTipoGasto
			,@s_id_acti
			,NULL
			,@p_usuarioInserta_acti
			,GETDATE()
		FROM #temp_TablaGastos

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	IF XACT_STATE() <> 0
	ROLLBACK TRANSACTION;

END CATCH