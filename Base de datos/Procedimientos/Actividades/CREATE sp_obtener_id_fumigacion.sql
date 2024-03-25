IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_obtener_id_fumigacion')
	DROP PROCEDURE sp_obtener_id_fumigacion
GO

CREATE PROCEDURE sp_obtener_id_fumigacion (
	@p_id_acti INT
)
AS
BEGIN
	SELECT
		top(1) id_fumi
	FROM FUMIGACION
	WHERE id_acti = @p_id_acti
END