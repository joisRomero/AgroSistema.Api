IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_ObtenerDatosUsuario') 
	BEGIN
		DROP PROCEDURE sp_ObtenerDatosUsuario;
	END
GO
create procedure sp_ObtenerDatosUsuario(
	@pIdUsuario int
)
as begin
	select 
		correo_usu as Correo 
		,nombre_usu as Nombre
		,apellidoPaterno_usu as ApellidoPaterno
		,apellidoMaterno_usu as ApellidoMaterno
	from USUARIO
	where id_usu = @pIdUsuario
end
