IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_x_usuario_tipo_trabajador')
	DROP PROCEDURE sp_obtener_x_usuario_tipo_trabajador
GO

CREATE PROCEDURE sp_obtener_x_usuario_tipo_trabajador (
	@p_id_usu	INT
)
AS
BEGIN
	SELECT
		id_tipoTrab AS IdTipoTrabajador
		,nombre_tipoTrab AS NombreTipoTrabajador
	FROM TIPO_TRABAJADOR
	WHERE id_usu = @p_id_usu
END