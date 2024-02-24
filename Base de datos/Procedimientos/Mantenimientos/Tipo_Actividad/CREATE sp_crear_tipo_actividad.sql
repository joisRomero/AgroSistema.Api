IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_crear_tipo_actividad')
	DROP PROCEDURE sp_crear_tipo_actividad
GO

CREATE PROCEDURE sp_crear_tipo_actividad(
	@p_nombre_tipoActi			VARCHAR(100)
	,@p_realizadaPor_tipoActi	CHAR(1)
	,@p_descripcion_tipoActi	VARCHAR(250)
	,@p_id_usu					INT
	,@p_usuarioInserta_tipoActi VARCHAR(50)
)
AS
BEGIN
	INSERT INTO TIPO_ACTIVIDAD(
		nombre_tipoActi
		,realizadaPor_tipoActi
		,descripcion_tipoActi
		,estado_tipoActi
		,id_usu
		,usuarioInserta_tipoActi
		,fechaInserta_tipoActi
	)
	VALUES(
		@p_nombre_tipoActi
		,@p_realizadaPor_tipoActi
		,@p_descripcion_tipoActi
		,0
		,@p_id_usu
		,@p_usuarioInserta_tipoActi
		,GETDATE()
	)

END
