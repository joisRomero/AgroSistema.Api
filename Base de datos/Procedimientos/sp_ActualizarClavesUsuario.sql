IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_ActualizarClavesUsuario') 
	BEGIN
		DROP PROCEDURE sp_ActualizarClavesUsuario;
	END
GO
create procedure sp_ActualizarClavesUsuario(
	@pIdUsuario int,
	@pClave varchar(1000)
)
as begin
	update USUARIO set 
	clave_usu = @pClave
	where id_usu = @pIdUsuario


	select @pIdUsuario as IdUsuario
		
end
