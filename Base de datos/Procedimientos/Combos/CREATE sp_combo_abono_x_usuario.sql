IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_combo_abono_x_usuario')
	DROP PROCEDURE sp_combo_abono_x_usuario
GO

CREATE PROCEDURE sp_combo_abono_x_usuario(
	@p_id_usu INT
)
AS
BEGIN
	SELECT 
		a.id_abono AS IdAbono
		,a.nombre_abono AS NombreAbono
	FROM ABONO a
	WHERE a.id_usu = @p_id_usu
END