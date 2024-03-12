IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_eliminar_actividad')
	DROP PROCEDURE sp_eliminar_actividad
GO

CREATE PROCEDURE sp_eliminar_actividad(
	@p_id_acti	INT
	,@p_usuarioElimina_acti VARCHAR(50)
)
AS
BEGIN
	UPDATE ACTIVIDAD
		SET estado_acti = 0
			,usuarioElimina_acti = @p_usuarioElimina_acti
			,fechaElimina_acti = dbo.GETDATENEW()
	WHERE id_acti = @p_id_acti


END