IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_modificar_fumigacion_detalle')
	DROP PROCEDURE sp_agregar_fumigacion_detalle
GO

CREATE PROCEDURE sp_agregar_fumigacion_detalle(
	@p_id_fum INT
	,@p_cantidad_fumiDet INT
	,@p_id_agroqui INT
	,@p_unidadDatoComun_fumiDet INT
	,@p_usuarioInserta_fumiDet VARCHAR(50)
)
AS
BEGIN
	INSERT INTO FUMIGACION_DETALLE(
		cantidad_fumiDet
		,unidadDatoComun_fumiDet
		,id_fumi
		,id_agroqui
		,usuarioInserta_fumiDet
		,fechaInserta_fumiDet
	)
	VALUES
	(
		@p_cantidad_fumiDet
		,@p_unidadDatoComun_fumiDet
		,@p_id_fum
		,@p_id_agroqui
		,@p_usuarioInserta_fumiDet
		,dbo.GETDATENEW()
	)
END