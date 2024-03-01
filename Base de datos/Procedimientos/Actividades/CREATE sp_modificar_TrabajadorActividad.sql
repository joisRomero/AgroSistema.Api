IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_modificar_trabajadorActividad')
	DROP PROCEDURE sp_modificar_trabajadorActividad
GO

CREATE PROCEDURE sp_modificar_trabajadorActividad(
	@p_id_trab				INT
	,@p_descripcion_trab		VARCHAR(250)
	,@p_cantidad_trab			INT
	,@p_costoUnitario_trab		DECIMAL(9,2)
	,@p_costoTotal_trab			DECIMAL(9,2)
	,@p_id_tipoTrab				INT
	,@p_usuarioModifica_trab	VARCHAR(50)
)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE TRABAJADOR
			SET	descripcion_trab		= @p_descripcion_trab
				,cantidad_trab			= @p_cantidad_trab
				,costoUnitario_trab		= @p_costoUnitario_trab
				,costoTotal_trab		= @p_costoTotal_trab
				,id_tipoTrab			= @p_id_tipoTrab
				,usuarioModifica_trab	= @p_usuarioModifica_trab
		WHERE id_trab = @p_id_trab
	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	IF XACT_STATE() <> 0
	ROLLBACK TRANSACTION;

END CATCH