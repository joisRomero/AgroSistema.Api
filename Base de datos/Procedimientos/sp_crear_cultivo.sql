IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_crear_cultivo')
	DROP PROCEDURE sp_crear_cultivo
GO

CREATE PROCEDURE sp_crear_cultivo
(
	@p_nombre_culti varchar(100)
	,@p_id_usu int 
	,@p_usuarioInserta_culti varchar(50)
)
AS
BEGIN
	INSERT INTO CULTIVO 
	(
		nombre_culti
		,id_usu
		,estado_culti
		,usuarioInserta_culti
		,fechaInserta_culti
	)
	VALUES(
		@p_nombre_culti
		,@p_id_usu
		,1
		,@p_usuarioInserta_culti
		,GETDATE()
	)
END