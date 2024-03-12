IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_modificar_actividad')
	DROP PROCEDURE sp_modificar_actividad
GO

CREATE PROCEDURE sp_modificar_actividad(
	@p_id_acti					INT
	,@p_fecha_acti				DATETIME
	,@p_descripcion_acti		VARCHAR(250)
	,@p_cantidadSemilla_acti	INT
	,@p_unidadSemillaDatoComun_acti INT
	,@p_id_camp					INT	NULL
	,@p_id_tipoActi				INT NULL
	,@p_usuarioModifica_acti	VARCHAR(50)
)
AS
BEGIN TRY
	BEGIN TRANSACTION
	UPDATE ACTIVIDAD 
		SET fecha_acti				= @p_fecha_acti
			,descripcion_acti		= @p_descripcion_acti
			,cantidadSemilla_acti	= @p_cantidadSemilla_acti
			,unidadSemillaDatoComun_acti = @p_unidadSemillaDatoComun_acti
			,id_camp				= @p_id_camp
			,id_tipoActi			= @p_id_tipoActi
			,usuarioModifica_acti	= @p_usuarioModifica_acti
	WHERE id_acti = @p_id_acti
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	IF XACT_STATE() <> 0
	ROLLBACK TRANSACTION;

END CATCH