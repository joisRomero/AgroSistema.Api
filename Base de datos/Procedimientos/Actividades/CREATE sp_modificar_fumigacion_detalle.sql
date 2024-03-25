IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_modificar_fumigacion_detalle')
	DROP PROCEDURE sp_modificar_fumigacion_detalle
GO

CREATE PROCEDURE sp_modificar_fumigacion_detalle(
	@p_id_fumiDet INT
	,@p_cantidad_fumiDet INT
	,@p_id_agroqui INT
	,@p_unidadDatoComun_fumiDet INT
	,@p_usuarioModifica_fumiDet VARCHAR(50)
)
AS
BEGIN
	UPDATE FUMIGACION_DETALLE
		SET cantidad_fumiDet = @p_cantidad_fumiDet 
			,unidadDatoComun_fumiDet = @p_unidadDatoComun_fumiDet
			,id_agroqui = @p_id_agroqui
			,usuarioModifica_fumiDet = @p_usuarioModifica_fumiDet
			,fechaModifica_fumiDet = dbo.GETDATENEW()		
	WHERE id_fumiDet = @p_id_fumiDet
END