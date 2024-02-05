IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_eliminar_cultivo')
	DROP PROCEDURE sp_eliminar_cultivo
GO

CREATE PROCEDURE sp_eliminar_cultivo
(
	@p_id_culti int
	,@p_usuarioElimina_culti varchar(50)
)
AS
BEGIN
	
	UPDATE CULTIVO
	SET 
		estado_culti = 0
		,usuarioElimina_culti = @p_usuarioElimina_culti
		,fechaElimina_culti = GETDATE()
	WHERE id_culti=@p_id_culti

END