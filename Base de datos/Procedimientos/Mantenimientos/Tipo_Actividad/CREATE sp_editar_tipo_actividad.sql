IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_editar_tipo_actividad')
	DROP PROCEDURE sp_editar_tipo_actividad
GO

CREATE PROCEDURE sp_editar_tipo_actividad(
	@p_id_tipoActi				INT
	,@p_nombre_tipoActi			VARCHAR(100)
	,@p_realizadaPor_tipoActi	CHAR(1)
	,@p_descripcion_tipoActi	VARCHAR(250)
	,@p_usuarioModifica_tipoActi VARCHAR(50)
)
AS
BEGIN
	UPDATE TIPO_ACTIVIDAD
		SET nombre_tipoActi = @p_nombre_tipoActi
			,realizadaPor_tipoActi = @p_realizadaPor_tipoActi
			,descripcion_tipoActi = @p_descripcion_tipoActi
			,usuarioModifica_tipoActi = @p_usuarioModifica_tipoActi
			,fechaModifica_tipoActi = GETDATE()
		WHERE id_tipoActi = @p_id_tipoActi
END