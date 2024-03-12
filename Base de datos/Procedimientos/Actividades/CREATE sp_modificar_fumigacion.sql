IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_modificar_fumigacion')
	DROP PROCEDURE sp_modificar_fumigacion
GO

CREATE PROCEDURE sp_modificar_fumigacion(
	@p_id_acti INT
	,@p_cantidad_fumi INT 
	,@p_unidadDatoComun_fumi INT 
	,@p_usuarioModifica_fumi VARCHAR(50)
) 
AS
BEGIN
	UPDATE FUMIGACION
		SET 
			cantidad_fumi = @p_cantidad_fumi
			,unidadDatoComun_fumi = @p_unidadDatoComun_fumi
			,usuarioModifica_fumi = @p_usuarioModifica_fumi
			,fechaModifica_fumi = dbo.GETDATENEW()
		WHERE id_acti = @p_id_acti
END