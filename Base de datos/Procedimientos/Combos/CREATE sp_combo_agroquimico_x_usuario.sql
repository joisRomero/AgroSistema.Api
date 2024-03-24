IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_combo_agroquimico_x_usuario')
	DROP PROCEDURE sp_combo_agroquimico_x_usuario
GO

CREATE PROCEDURE sp_combo_agroquimico_x_usuario(
	@p_id_usu INT
)
AS
BEGIN
	SELECT
		ag.id_agroqui
		,ag.nombre_agroqui
	FROM AGROQUIMICO ag
	WHERE ag.id_usu = @p_id_usu
END	