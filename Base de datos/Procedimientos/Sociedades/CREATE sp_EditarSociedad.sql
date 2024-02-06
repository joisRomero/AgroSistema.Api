IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EditarSociedad')
	DROP PROCEDURE sp_EditarSociedad
GO

CREATE PROCEDURE sp_EditarSociedad
(
	@idSociedad int
	,@nombreSociedad varchar(100)
	,@usuarioModifica varchar(50)
)
AS
BEGIN

	UPDATE SOCIEDAD
	SET 
		nombre_soc = @nombreSociedad
		,usuarioModifica_soc = @usuarioModifica
		,fechaModifica_soc = GETDATE()
	WHERE id_soc=@idSociedad

END