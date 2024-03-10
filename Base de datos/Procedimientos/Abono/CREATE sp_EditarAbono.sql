USE [agro_sistema_bd]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EditarAbono')
	DROP PROCEDURE sp_EditarAbono
GO

CREATE PROCEDURE sp_EditarAbono
(
	@idAbono int
	,@nombreAbono varchar(100)
	,@descripcion varchar(200)
	,@usuarioModifica varchar(50)
)
AS
BEGIN

	UPDATE ABONO
	SET 
		nombre_abono = @nombreAbono
		,descripcion_abono = @descripcion
		,usuarioModifica_abono = @usuarioModifica
		,fechaModifica_abono = GETDATE()
	WHERE id_abono =@idAbono

END