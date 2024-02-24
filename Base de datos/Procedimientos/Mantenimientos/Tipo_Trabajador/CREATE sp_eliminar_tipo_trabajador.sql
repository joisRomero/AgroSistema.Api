IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_eliminar_tipo_trabajador')
	DROP PROCEDURE sp_eliminar_tipo_trabajador
GO

CREATE PROCEDURE sp_eliminar_tipo_trabajador (
	@p_id_tipoTrab				INT
	,@p_usuarioElimina_tipoTrab VARCHAR(50)
)
AS
BEGIN
	UPDATE TIPO_TRABAJADOR
		SET estado_tipoTrab				= 0
			,usuarioElimina_tipoTrab	= @p_usuarioElimina_tipoTrab
			,fechaElimina_tipoTrab		= GETDATE() 
END