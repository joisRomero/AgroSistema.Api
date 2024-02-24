USE [agro_sistema_bd]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_AgregarGastoDetalle')
	DROP PROCEDURE sp_AgregarGastoDetalle
GO

CREATE PROCEDURE sp_AgregarGastoDetalle
(
	@idCampania int
	,@idTipoGasto int
	,@fechaGasto datetime
	,@cantidad int
	,@costoUnitario decimal(18,2)
	,@costoTotal decimal(18,2)
	,@descripcion varchar(200)
	,@usuarioInserta varchar(50)
)
AS
BEGIN

	INSERT INTO GASTO_DETALLE
	(
		estado_gastoDet,
		descripcion_gastoDet,
		cantidad_gastoDet,
		costoUnitario_gastoDet,
		costoTotal_gastoDet,
		fecha_gastoDet,
		id_tipoGasto,
		id_camp,
		usuarioInserta_gastoDet,
		fechaInserta_gastoDet
	)
	VALUES(
		1,
		@descripcion,
		@cantidad,
		@costoUnitario,
		@costoTotal,
		@fechaGasto,
		@idTipoGasto,
		@idCampania,
		@usuarioInserta,
		GETDATE()
	)

END