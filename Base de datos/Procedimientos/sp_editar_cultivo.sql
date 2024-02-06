IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_editar_cultivo')
	DROP PROCEDURE sp_editar_cultivo
GO

CREATE PROCEDURE sp_editar_cultivo
(
	@p_id_culti int
	,@p_nombre_culti varchar(100)
	,@p_id_usu int 
	,@p_usuarioModifica_culti varchar(50)
)
AS
BEGIN

	UPDATE CULTIVO
	SET 
		nombre_culti = @p_nombre_culti
		,id_usu = @p_id_usu
		,usuarioModifica_culti = @p_usuarioModifica_culti
		,fechaModifica_culti = GETDATE()
	WHERE id_culti=@p_id_culti

END