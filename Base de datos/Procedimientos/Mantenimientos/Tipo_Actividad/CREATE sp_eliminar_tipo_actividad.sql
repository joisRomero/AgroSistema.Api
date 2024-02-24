IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_eliminar_tipo_actividad')
	DROP PROCEDURE sp_eliminar_tipo_actividad
GO

CREATE PROCEDURE sp_eliminar_tipo_actividad (
	@p_id_tipoActi				INT
	,@p_usuarioElimina_tipoActi VARCHAR(50)
)
AS
BEGIN
	UPDATE TIPO_ACTIVIDAD
		SET estado_tipoActi				= 0
			,usuarioElimina_tipoActi	= @p_usuarioElimina_tipoActi
			,fechaElimina_tipoActi		= GETDATE() 
	WHERE id_tipoActi = @p_id_tipoActi
END