IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_modificar_gastosActividad')
	DROP PROCEDURE sp_modificar_gastosActividad
GO

CREATE PROCEDURE sp_modificar_gastosActividad(
	@p_id_gastoDet				INT
	,@p_descripcion_gastoDet	VARCHAR(250)
	,@p_cantidad_gastoDet		INT
	,@p_costoUnitario_gastoDet	DECIMAL(9,2)
	,@p_costoTotal_gastoDet		DECIMAL(9,2)
	,@p_fecha_gastoDet			DATETIME
	,@p_id_tipoGasto			INT
	,@p_usuarioModifica_gastoDet VARCHAR(50)
)
AS
BEGIN TRY
	BEGIN TRANSACTION
		UPDATE GASTO_DETALLE
			SET descripcion_gastoDet		= @p_descripcion_gastoDet
				,cantidad_gastoDet			= @p_cantidad_gastoDet
				,costoUnitario_gastoDet		= @p_costoUnitario_gastoDet
				,costoTotal_gastoDet		= @p_costoTotal_gastoDet
				,fecha_gastoDet				= @p_fecha_gastoDet
				,id_tipoGasto				= @p_id_tipoGasto
				,usuarioModifica_gastoDet	= @p_usuarioModifica_gastoDet
				,fechaModifica_gastoDet		= GETDATE()
		WHERE id_gastoDet = @p_id_gastoDet


	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	IF XACT_STATE() <> 0
	ROLLBACK TRANSACTION;

END CATCH