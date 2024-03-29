IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_ObtenerUsuarioLogin') 
	BEGIN
		DROP PROCEDURE sp_ObtenerUsuarioLogin;
	END
GO
create procedure [dbo].[sp_ObtenerUsuarioLogin](
	 @pUsuario varchar(50),
	 @pClave varchar(1000)
)
as begin 
	
	declare @sUsuario varchar(50) = @pUsuario
	declare @sClave varchar(1000) = @pClave
	
	select	id_usu as IdUsuario, 
			nombreUsuario_usu as NombreUsuario, 
			CONCAT(nombre_usu, ' ', apellidoPaterno_usu, ' ', apellidoMaterno_usu) as NombreCompleto
	from USUARIO with(nolock)
	where nombreUsuario_usu = @sUsuario and clave_usu = @sClave and estado_usu = 1

end
