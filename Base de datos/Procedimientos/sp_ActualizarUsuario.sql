IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_ActualizarUsuario') 
	BEGIN
		DROP PROCEDURE sp_ActualizarUsuario;
	END
GO
create procedure sp_ActualizarUsuario(
	@pIdUsuario int,
	@pNombre varchar(50),
	@pApellidoPaterno varchar(50),
	@pApellidoMaterno varchar(50),
	@pCorreo varchar(250)
)
as begin
	update USUARIO set 
	nombre_usu = @pNombre,
	apellidoPaterno_usu = @pApellidoPaterno,
	apellidoMaterno_usu = @pApellidoMaterno,
	correo_usu = @pCorreo
	where id_usu = @pIdUsuario


	select 
		id_usu as Id,
		nombre_usu as Nombre,
		apellidoPaterno_usu as ApellidoPaterno,
		apellidoMaterno_usu as ApellidoMaterno,
		correo_usu as Correo
	from  USUARIO
	where id_usu = @pIdUsuario
end
