IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_crear_tipo_trabajador')
	DROP PROCEDURE sp_crear_tipo_trabajador
GO

CREATE PROCEDURE sp_crear_tipo_trabajador(
	@p_nombre_tipoTrab			VARCHAR(100)
	,@p_descripcion_tipoTrab	VARCHAR(250)
	,@p_id_usu					INT
	,@p_usuarioInserta_tipoTrab VARCHAR(50)
)
AS
BEGIN
	INSERT INTO TIPO_TRABAJADOR(
		nombre_tipoTrab
		,descripcion_tipoTrab
		,estado_tipoTrab
		,id_usu
		,usuarioInserta_tipoTrab
		,fechaInserta_tipoTrab
	)
	VALUES
	(
		@p_nombre_tipoTrab
		,@p_descripcion_tipoTrab
		,1
		,@p_id_usu
		,@p_usuarioInserta_tipoTrab
		,GETDATE()
	)
END