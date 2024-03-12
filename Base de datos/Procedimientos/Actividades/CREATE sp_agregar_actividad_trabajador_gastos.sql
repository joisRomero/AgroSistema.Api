IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_agregar_actividad_trabajador_gastos')
	DROP PROCEDURE sp_agregar_actividad_trabajador_gastos
GO

CREATE PROCEDURE sp_agregar_actividad_trabajador_gastos(
	@p_fecha_acti datetime
	,@p_descripcion_acti VARCHAR(250)
	,@p_cantidadSemilla_acti INT NULL
	,@p_unidadSemillaDatoComun_acti INT NULL
	,@p_id_camp	INT	NULL
	,@p_id_tipoActi	INT NULL
	,@p_usuarioInserta_acti VARCHAR(50)
	,@p_XML_Trabajadores XML NULL
	,@p_XML_Gastos XML NULL
	,@p_XML_Abonacion XML NULL
	--Fumigacion
	,@p_cantidad_fumi			INT NULL
	,@p_unidadDatoComun_fumi	INT NULL
	,@p_XML_Fumigacion_Detalle	XML	NULL
)
AS 
BEGIN TRY
	IF OBJECT_ID('tempdb..#temp_TablaTrabajadores') IS NOT NULL
		DROP TABLE #temp_TablaTrabajadores
		
	IF OBJECT_ID('tempdb..#temp_TablaGastos') IS NOT NULL
		DROP TABLE #temp_TablaGastos

	IF OBJECT_ID('tempdb..#temp_TablaAbonacion') IS NOT NULL
	DROP TABLE #temp_TablaAbonacion
	
	IF OBJECT_ID('tempdb..#temp_TablaFumigacionDetalle') IS NOT NULL
	DROP TABLE #temp_TablaFumigacionDetalle

	DECLARE @s_XML_Trabajadores XML = NULL
	DECLARE @s_XML_Gastos		XML = NULL
	DECLARE @s_XML_Abonacion	XML = NULL
	DECLARE @s_XML_Fumigacion_Detalle XML = NULL
	DECLARE @s_id_acti INT
	DECLARE @s_id_fumi INT

	SET @s_XML_Trabajadores = @p_XML_Trabajadores
	SET @s_XML_Gastos		= @p_XML_Gastos
	SET @s_XML_Abonacion	= @p_XML_Abonacion
	SET @s_XML_Fumigacion_Detalle = @p_XML_Fumigacion_Detalle

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

	SELECT
		TD.value('(Cantidad/text())[1]','int') AS CantidadAbonacion
		,TD.value('(UnidadDatoComunAbonacion/text())[1]','int') AS UnidadDcAbonacion
		,TD.value('(IdAbono/text())[1]','int') AS IdAbono
	INTO #temp_TablaAbonacion
	FROM @s_XML_Abonacion.nodes('/DocumentElement/Abonacion') AS TEMPTABLE(TD)

	SELECT
		TD.value('(Cantidad/text())[1]','int')			AS CantidadFumigacionDetalle
		,TD.value('(UnidadDatoComunFumigacionDetalle/text())[1]','int') AS UnidadDcFumigacionDetalle
		,TD.value('(IdAgroquimico/text())[1]','int')	AS IdAgroquimico
	INTO #temp_TablaFumigacionDetalle
	FROM @s_XML_Fumigacion_Detalle.nodes('/DocumentElement/FumigacionDetalle') AS TEMPTABLE(TD)

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
			,dbo.GETDATENEW()
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
			,dbo.GETDATENEW()
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
			,dbo.GETDATENEW()
		FROM #temp_TablaGastos

	COMMIT TRANSACTION

	BEGIN TRANSACTION

		INSERT INTO ABONACION(
			cantidad_abonaci
			,unidadDatoComun
			,id_abono
			,id_acti
			,usuarioInserta_abonaci
			,fechaInserta_abonaci
		)
		SELECT
			CantidadAbonacion
			,UnidadDcAbonacion
			,IdAbono
			,@s_id_acti
			,@p_usuarioInserta_acti
			,dbo.GETDATENEW()
		FROM #temp_TablaAbonacion

		INSERT INTO FUMIGACION(
			cantidad_fumi
			,unidadDatoComun_fumi
			,estado_fumi
			,id_acti
			,usuarioInserta_fumi
			,fechaInserta_fumi
		)
		VALUES(
			@p_cantidad_fumi
			,@p_unidadDatoComun_fumi
			,1
			,@s_id_acti
			,@p_usuarioInserta_acti
			,dbo.GETDATENEW()
		)
		SET @s_id_fumi = (SELECT @@IDENTITY);

		INSERT INTO FUMIGACION_DETALLE(
			cantidad_fumiDet
			,unidadDatoComun_fumiDet
			,id_fumi
			,id_agroqui
			,usuarioInserta_fumiDet
			,fechaInserta_fumiDet
		)
		SELECT
			CantidadFumigacionDetalle
			,UnidadDcFumigacionDetalle
			,@s_id_fumi
			,IdAgroquimico
			,@p_usuarioInserta_acti
			,dbo.GETDATENEW()
		FROM #temp_TablaFumigacionDetalle
	COMMIT TRANSACTION

END TRY
BEGIN CATCH
	IF XACT_STATE() <> 0
	ROLLBACK TRANSACTION;

END CATCH