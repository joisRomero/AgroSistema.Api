IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_finalizar_campania')
	DROP PROCEDURE sp_finalizar_campania
GO

CREATE PROCEDURE sp_finalizar_campania
(
	@p_id_camp						int
	,@p_fechaFin_camp				datetime
	,@p_usuarioModifica_camp		varchar(50)
)
AS
BEGIN
	DECLARE @s_fechaFin_camp VARCHAR(20)

	IF((@p_fechaFin_camp IS NOT NULL) OR (@p_fechaFin_camp != '')) 
	BEGIN
		
		SET @s_fechaFin_camp = convert(datetime,@p_fechaFin_camp,103)
		
		UPDATE CAMPANIA
		SET 
		fechaFin_camp				= @s_fechaFin_camp
		,estado_proceso_camp				= 'T'
		,usuarioModifica_camp		= @p_usuarioModifica_camp
		,fechaModifica_camp			= GETDATE()
		WHERE id_camp = @p_id_camp

	END
END