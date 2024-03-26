IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_reporteInicio_cultivosCampania_x_usuario')
	DROP PROCEDURE sp_reporteInicio_cultivosCampania_x_usuario
GO

CREATE PROCEDURE sp_reporteInicio_cultivosCampania_x_usuario(
	@p_id_usu INT
)
AS
BEGIN
	;WITH 
	TablaTotalCultivosCampania
	AS
	(
		SELECT 
			c.id_culti AS IdCultivo
			,cu.nombre_culti AS NombreCultivo
			,COUNT(c.id_culti) AS TotalCultivosCampania
		FROM CAMPANIA c
		LEFT JOIN CULTIVO cu on cu.id_culti = c.id_culti
		LEFT JOIN SOCIEDAD s on s.id_soc = c.id_soc
		LEFT JOIN USUARIO_SOCIEDAD u on u.id_soc = s.id_soc
		WHERE u.id_usu = @p_id_usu OR c.id_usu = @p_id_usu
		GROUP BY c.id_culti,cu.nombre_culti 
	)
	SELECT 
		NombreCultivo
		,TotalCultivosCampania
	FROM TablaTotalCultivosCampania
END