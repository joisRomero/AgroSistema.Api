IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_EliminarSociedad')
	DROP PROCEDURE sp_EliminarSociedad
GO

CREATE PROCEDURE sp_EliminarSociedad
(
	@idSociedad int
	,@usuarioElimina varchar(50)
)
AS
BEGIN
	
	UPDATE SOCIEDAD
		SET estado_soc = 0,
			usuarioElimina_soc = @usuarioElimina,
			fechaElimina_soc = GETDATE()
		WHERE
			id_soc = @idSociedad

END