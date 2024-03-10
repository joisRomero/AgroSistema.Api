USE [agro_sistema_bd]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_AgregarAgroquimico')
	DROP PROCEDURE sp_AgregarAgroquimico
GO

CREATE PROCEDURE sp_AgregarAgroquimico
(
	@nombreAgroquimico varchar(100)
	,@idTipoAgroquimico int
	,@descripcion varchar(200)
	,@usuarioInserta varchar(50)
	,@idUsuario int
)
AS
BEGIN

	INSERT INTO AGROQUIMICO
	(
		nombre_agroqui,
		descripcion_agroqui,
		estado_agrpqui,
		usuarioInserta_agrpqui,
		fechaInserta_agrpqui,
		id_tipoAgroqui,
		id_usu
	)
	VALUES(
		@nombreAgroquimico,
		@descripcion,
		1,
		@usuarioInserta,
		GETDATE(),
		@idTipoAgroquimico,
		@idUsuario
	)

END