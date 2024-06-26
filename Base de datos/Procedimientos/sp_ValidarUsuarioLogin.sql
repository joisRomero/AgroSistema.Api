IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_ValidarUsuarioLogin') 
	BEGIN
		DROP PROCEDURE sp_ValidarUsuarioLogin;
	END
GO
create  procedure [dbo].[sp_ValidarUsuarioLogin](
	 @pUsuario varchar(50),
	 @pClave varchar(1000)
)
as begin 
	
	declare @sUsuario varchar(50) = @pUsuario
	declare @sClave varchar(1000) = @pClave
	declare @sRespuesta int = 0
	
	select @sRespuesta = ISNULL(COUNT(nombreUsuario_usu), 0)
	from USUARIO with(nolock)
	where nombreUsuario_usu = @sUsuario and clave_usu = @sClave and estado_usu = 1

	if (@sRespuesta > 0)
	begin 
		select 1 as respuesta
	end 
	else 
	begin
		select 0 as respuesta
	end
end
