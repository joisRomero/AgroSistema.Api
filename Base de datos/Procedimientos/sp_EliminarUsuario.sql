IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_EliminarUsuario') 
	BEGIN
		DROP PROCEDURE sp_EliminarUsuario;
	END
GO
create procedure sp_EliminarUsuario(
	@pIdUsuario int
)
as begin
	update USUARIO set 
	estado_usu = 0
	where id_usu = @pIdUsuario
end
