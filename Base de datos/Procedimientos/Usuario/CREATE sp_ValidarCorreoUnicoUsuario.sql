IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ValidarCorreoUnicoUsuario')
	DROP PROCEDURE sp_ValidarCorreoUnicoUsuario
GO

CREATE PROCEDURE [dbo].[sp_ValidarCorreoUnicoUsuario](
	@p_correo_usu varchar(250)
)
AS 
BEGIN
	declare @total int
	declare @respuesta bit

	select @total = COUNT(id_usu)
	from USUARIO
	where correo_usu = @p_correo_usu

	if (@total >= 1)
	begin 
		set @respuesta = 1
	end
	else
	begin 
		set @respuesta = 0
	end 

	select @respuesta as Respuesta
END