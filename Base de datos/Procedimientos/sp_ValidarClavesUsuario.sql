IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_ValidarClavesUsuario') 
	BEGIN
		DROP PROCEDURE sp_ValidarClavesUsuario;
	END
GO
create procedure [dbo].sp_ValidarClavesUsuario(
	 @pIdUsuario int,
	 @pClave varchar(1000)
)
as begin 
	
	declare @sRespuesta int = 0
	
	select @sRespuesta = ISNULL(COUNT(nombreUsuario_usu), 0)
	from USUARIO with(nolock)
	where clave_usu = @pClave and estado_usu = 1

	if (@sRespuesta > 0)
	begin 
		select 1 as respuesta
	end 
	else 
	begin
		select 0 as respuesta
	end

end
