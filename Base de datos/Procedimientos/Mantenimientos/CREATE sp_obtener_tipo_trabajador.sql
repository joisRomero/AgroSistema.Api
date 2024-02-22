IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_tipo_trabajador')
	DROP PROCEDURE sp_obtener_tipo_trabajador
GO
IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_tipo_trabajador')
	DROP PROCEDURE sp_obtener_tipo_trabajador
GO

CREATE PROCEDURE sp_obtener_tipo_trabajador (
	@p_id_tipoTrab	INT
)
AS
BEGIN
	SELECT
		id_tipoTrab AS IdTipoTrabajador
		,nombre_tipoTrab AS NombreTipoTrabajador
		,descripcion_tipoTrab AS DescripcionTipoTrabajador
	FROM TIPO_TRABAJADOR
	WHERE id_tipoTrab = @p_id_tipoTrab
END