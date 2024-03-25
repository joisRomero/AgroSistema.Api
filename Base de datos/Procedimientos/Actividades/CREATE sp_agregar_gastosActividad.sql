IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_agregar_gastosActividad')
	DROP PROCEDURE sp_agregar_gastosActividad
GO

CREATE PROCEDURE sp_agregar_gastosActividad(
	@p_descripcion_gastoDet		VARCHAR(250)
	,@p_cantidad_gastoDet		INT
	,@p_costoUnitario_gastoDet	DECIMAL(9,2)
	,@p_costoTotal_gastoDet		DECIMAL(9,2)
	,@p_fecha_gastoDet			DATETIME
	,@p_id_tipoGasto			INT
	,@p_id_acti					INT
	,@p_usuarioInserta_gastoDet VARCHAR(50)
)
AS
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO GASTO_DETALLE (
			descripcion_gastoDet
			,cantidad_gastoDet
			,costoUnitario_gastoDet
			,costoTotal_gastoDet
			,fecha_gastoDet
			,id_tipoGasto
			,id_acti
			,id_camp
			,estado_gastoDet
			,usuarioInserta_gastoDet
			,fechaInserta_gastoDet
		)
		VALUES(
			@p_descripcion_gastoDet
			,@p_cantidad_gastoDet
			,@p_costoUnitario_gastoDet
			,@p_costoTotal_gastoDet
			,@p_fecha_gastoDet
			,@p_id_tipoGasto
			,@p_id_acti
			,NULL
			,1
			,@p_usuarioInserta_gastoDet
			,GETDATE()
		)


	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	IF XACT_STATE() <> 0
	ROLLBACK TRANSACTION;

END CATCH