IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_modificar_tipo_trabajador')
	DROP PROCEDURE sp_modificar_tipo_trabajador
GO

CREATE PROCEDURE sp_modificar_tipo_trabajador(
	@p_id_tipoTrab				INT
	,@p_nombre_tipoTrab			VARCHAR(100)
	,@p_descripcion_tipoTrab	VARCHAR(250)
	,@p_usuarioModifica_tipoTrab VARCHAR(50)
)
AS
BEGIN
	UPDATE TIPO_TRABAJADOR
		SET nombre_tipoTrab				= @p_nombre_tipoTrab
			,descripcion_tipoTrab		= @p_descripcion_tipoTrab
			,usuarioModifica_tipoTrab	= @p_usuarioModifica_tipoTrab
			,fechaModifica_tipoTrab		= GETDATE()
	WHERE id_tipoTrab = @p_id_tipoTrab
END