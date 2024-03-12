IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EditarAgroquimico')
	DROP PROCEDURE sp_EditarAgroquimico
GO

CREATE PROCEDURE sp_EditarAgroquimico
(
	@idAgroquimico int
	,@nombreAgroquimico varchar(100)
	,@idTipoAgroquimico int
	,@descripcion varchar(200)
	,@usuarioModifica varchar(50)
)
AS
BEGIN

	UPDATE AGROQUIMICO
	SET 
		nombre_agroqui = @nombreAgroquimico
		,descripcion_agroqui = @descripcion
		,id_tipoAgroqui = @idTipoAgroquimico
		,usuarioModifica_agrpqui = @usuarioModifica
		,fechaModifica_agrpqui = GETDATE()
	WHERE id_agroqui =@idAgroquimico

END