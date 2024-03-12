IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_AgregarAbono')
	DROP PROCEDURE sp_AgregarAbono
GO

CREATE PROCEDURE sp_AgregarAbono
(
	@nombreAbono varchar(100)
	,@descripcion varchar(200)
	,@usuarioInserta varchar(50)
	,@idUsuario int
)
AS
BEGIN

	INSERT INTO ABONO
	(
		nombre_abono,
		descripcion_abono,
		estado_abono,
		usuarioInserta_abono,
		fechaInserta_abono,
		id_usu
	)
	VALUES(
		@nombreAbono,
		@descripcion,
		1,
		@usuarioInserta,
		GETDATE(),
		@idUsuario
	)

END