IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_AgregarCosecha')
	DROP PROCEDURE sp_AgregarCosecha
GO

CREATE PROCEDURE sp_AgregarCosecha
(
	@fechaCosecha datetime
	,@idCampania int
	,@descripcion varchar(200)
	,@usuarioInserta varchar(50)
	,@xmlCosechaDetalle XML
)
AS
BEGIN

	CREATE TABLE #CosechaDetalleTMP_XML(
		Cantidad INT,
		Unidad INT,
		Calidad INT,
		Descripcion VARCHAR(200)
	)

	INSERT INTO #CosechaDetalleTMP_XML (Cantidad, Unidad, Calidad, Descripcion)
	SELECT
		XmlColumn.value('Cantidad[1]', 'INT') AS Cantidad,
		XmlColumn.value('Unidad[1]', 'INT') AS Unidad,
		XmlColumn.value('Calidad[1]', 'INT') AS Calidad,
		XmlColumn.value('Descripcion[1]', 'VARCHAR(200)') AS Descripcion
	FROM @XmlCosechaDetalle.nodes('/ArrayOfCosechaDetalleDTO/CosechaDetalleDTO') AS T(XmlColumn);

	INSERT INTO COSECHA
	(
		fecha_cose,
		descripcion_cose,
		estado_cose,
		id_camp,
		usuarioInserta_cose,
		fechaInserta_cose
	)
	VALUES(
		@fechaCosecha,
		@descripcion,
		1,
		@idCampania,
		@usuarioInserta,
		GETDATE()
	)
	
	DECLARE @idCosecha INT = (SELECT SCOPE_IDENTITY());

	INSERT INTO COSECHA_DETALLE (cantidad_coseDet, unidadDatoComun_coseDet, calidadDatoComun_coseDet, descripcion_coseDet, id_cose, usuarioInserta_coseDet, fechaInserta_coseDet, estado_coseDet)
	SELECT
		Cantidad AS cantidad_coseDet,
		Unidad AS unidadDatoComun_coseDet,
		Calidad AS calidadDatoComun_coseDet,
		Descripcion AS descripcion_coseDet,	
		@idCosecha AS id_cose,
		@usuarioInserta AS usuarioInserta_coseDet,
		GETDATE() AS fechaInserta_coseDet,
		1 AS estado_coseDet
	FROM #CosechaDetalleTMP_XML

END