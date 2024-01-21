IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_ValidarNombreUsuario') 
	BEGIN
		DROP PROCEDURE sp_ValidarNombreUsuario;
	END
GO
create procedure sp_ValidarNombreUsuario(
	@pNombreUsuario varchar(50)
)
as begin
	declare @total int
	declare @respuesta bit

	select @total = COUNT(id_usu)
	from USUARIO
	where nombreUsuario_usu = @pNombreUsuario

	if (@total >= 1)
	begin 
		set @respuesta = 1
	end
	else
	begin 
		set @respuesta = 0
	end 

	select @respuesta as Respuesta
end