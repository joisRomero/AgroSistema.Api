USE [agro_sistema_bd]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_AgregarTipoGasto')
	DROP PROCEDURE sp_AgregarTipoGasto
GO

CREATE PROCEDURE sp_AgregarTipoGasto
(
	@nombreTipoGasto varchar(100)
	,@descripcion varchar(200)
	,@usuarioInserta varchar(50)
)
AS
BEGIN

	INSERT INTO TIPO_GASTO
	(
		nombre_tipoGasto,
		descripcion_tipoGasto,
		estado_tipoGasto,
		usuarioInserta_tipoGasto,
		fechaInserta_tipoGasto
	)
	VALUES(
		@nombreTipoGasto,
		@descripcion,
		1,
		@usuarioInserta,
		GETDATE()
	)

END