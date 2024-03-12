IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_modificar_abonacion')
	DROP PROCEDURE sp_modificar_abonacion
GO

CREATE PROCEDURE sp_modificar_abonacion(
	@p_id_abonaci INT
	,@p_cantidad_abonaci INT
	,@p_unidadDatoComun INT
	,@p_id_abono INT
	,@p_usuarioModifica_abonaci VARCHAR(50)
)
AS
BEGIN
	UPDATE ABONACION
		SET cantidad_abonaci = @p_cantidad_abonaci
			,unidadDatoComun = @p_unidadDatoComun
			,id_abono = @p_id_abono
			,usuarioModifica_abonaci = @p_usuarioModifica_abonaci
			,fechaModifica_abonaci = dbo.GETDATENEW()
	WHERE id_abonaci = @p_id_abonaci
END