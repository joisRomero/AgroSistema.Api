IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_listar_tipo_gasto_x_campania')
	DROP PROCEDURE sp_listar_tipo_gasto_x_campania
GO

CREATE PROCEDURE sp_listar_tipo_gasto_x_campania(
	@p_id_camp INT
)
AS
BEGIN
	SELECT DISTINCT
		tg.nombre_tipoGasto
		,tg.id_tipoGasto
	FROM GASTO_DETALLE gd 
	LEFT JOIN TIPO_GASTO tg on gd.id_tipoGasto = tg.id_tipoGasto
	WHERE GD.id_camp = @p_id_camp
END