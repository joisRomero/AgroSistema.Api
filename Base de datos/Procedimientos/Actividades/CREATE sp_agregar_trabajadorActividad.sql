IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_agregar_trabajadorActividad')
	DROP PROCEDURE sp_agregar_trabajadorActividad
GO

CREATE PROCEDURE sp_agregar_trabajadorActividad(
	@p_descripcion_trab		VARCHAR(250)
	,@p_cantidad_trab			INT
	,@p_costoUnitario_trab		DECIMAL(9,2)
	,@p_costoTotal_trab			DECIMAL(9,2)
	,@p_id_acti					INT
	,@p_id_tipoTrab				INT
	,@p_usuarioInserta_trab	VARCHAR(50)
)
AS
BEGIN TRY
	BEGIN TRANSACTION
		INSERT INTO TRABAJADOR(
			descripcion_trab
			,cantidad_trab
			,costoUnitario_trab
			,costoTotal_trab
			,id_acti
			,id_tipoTrab
			,estado_trab
			,usuarioInserta_trab
			,fechaInserta_trab
		)
		VALUES(
			@p_descripcion_trab
			,@p_cantidad_trab
			,@p_costoUnitario_trab
			,@p_costoTotal_trab
			,@p_id_acti
			,@p_id_tipoTrab
			,1
			,@p_usuarioInserta_trab
			,GETDATE()
		)

	COMMIT TRANSACTION
END TRY
BEGIN CATCH
	IF XACT_STATE() <> 0
	ROLLBACK TRANSACTION;

END CATCH