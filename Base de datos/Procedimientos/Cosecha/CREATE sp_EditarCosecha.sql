IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EditarCosecha')
	DROP PROCEDURE sp_EditarCosecha
GO

CREATE PROCEDURE sp_EditarCosecha
(
	@idCosecha int
	,@fechaCosecha datetime
	,@idCampania int
	,@descripcion varchar(200)
	,@usuarioModifica varchar(50)
	,@xmlCosechaDetalle XML
)
AS
BEGIN

	CREATE TABLE #CosechaDetalleTMP_XML(
		IdCosechaDetalle INT NULL,
		Cantidad INT,
		Unidad INT,
		Calidad INT,
		Descripcion VARCHAR(200)
	)

	INSERT INTO #CosechaDetalleTMP_XML (IdCosechaDetalle, Cantidad, Unidad, Calidad, Descripcion)
	SELECT
		XmlColumn.value('IdCosechaDetalle[1]', 'INT') AS IdCosechaDetalle,
		XmlColumn.value('Cantidad[1]', 'INT') AS Cantidad,
		XmlColumn.value('Unidad[1]', 'INT') AS Unidad,
		XmlColumn.value('Calidad[1]', 'INT') AS Calidad,
		XmlColumn.value('Descripcion[1]', 'VARCHAR(200)') AS Descripcion
	FROM @XmlCosechaDetalle.nodes('/ArrayOfCosechaDetalleRequestDTO/CosechaDetalleRequestDTO') AS T(XmlColumn);

	UPDATE COSECHA
	SET
		fecha_cose = @fechaCosecha
		,id_camp = @idCampania
		,descripcion_cose= @descripcion
		,usuarioModifica_cose = @usuarioModifica
		,fechaModifica_cose = GETDATE()
	WHERE id_cose = @idCosecha

	UPDATE C
	SET
		C.cantidad_coseDet = CD.Cantidad,
		C.unidadDatoComun_coseDet = CD.Unidad,
		C.calidadDatoComun_coseDet = CD.Calidad,
		C.descripcion_coseDet = CD.Descripcion,
		C.usuarioModifica_coseDet = @usuarioModifica,
		C.fechaModifica_coseDet = GETDATE()
	FROM COSECHA_DETALLE C
		INNER JOIN #CosechaDetalleTMP_XML CD ON C.id_coseDet = CD.IdCosechaDetalle

	INSERT INTO COSECHA_DETALLE (cantidad_coseDet, unidadDatoComun_coseDet, calidadDatoComun_coseDet, descripcion_coseDet, id_cose, usuarioInserta_coseDet, fechaInserta_coseDet, estado_coseDet)
	SELECT
		Cantidad AS cantidad_coseDet,
		Unidad AS unidadDatoComun_coseDet,
		Calidad AS calidadDatoComun_coseDet,
		Descripcion AS descripcion_coseDet,
		@idCosecha AS id_cose,
		@usuarioModifica AS usuarioInserta_coseDet,
		GETDATE() AS fechaInserta_coseDet,
		1 AS estado_coseDet
	FROM #CosechaDetalleTMP_XML
	WHERE IdCosechaDetalle = 0

END