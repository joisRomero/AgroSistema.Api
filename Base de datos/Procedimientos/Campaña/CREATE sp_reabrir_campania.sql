IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_reabrir_campania')
	DROP PROCEDURE sp_reabrir_campania
GO

CREATE PROCEDURE sp_reabrir_campania (
	@p_id_camp INT
	,@p_usuarioModifica_camp VARCHAR(50)
)
AS
BEGIN
	UPDATE CAMPANIA
		SET estado_proceso_camp = 'R'
			,fechaReabierta_camp = dbo.GETDATENEW()
			,usuarioModifica_camp = @p_usuarioModifica_camp
			,fechaModifica_camp = dbo.GETDATENEW()
	WHERE id_camp = @p_id_camp
END