IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_eliminar_campania')
	DROP PROCEDURE sp_eliminar_campania
GO

CREATE PROCEDURE sp_eliminar_campania
(
	@p_id_camp						int
	,@p_usuarioElimina_camp		varchar(50)
)
AS
BEGIN
	UPDATE CAMPANIA
	SET estado_camp				= 0
	,usuarioElimina_camp		= @p_usuarioElimina_camp
	,fechaElimina_camp			= GETDATE()
	WHERE id_camp = @p_id_camp

END