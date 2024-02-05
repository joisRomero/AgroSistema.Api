IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_CrearUsuario') 
	BEGIN
		DROP PROCEDURE sp_CrearUsuario;
	END
GO
create procedure sp_CrearUsuario(
	@pNombreUsuario varchar(50),
	@pClave varchar(1000),
	@pNombre varchar(50),
	@pApellidoPaterno varchar(50),
	@pApellidoMaterno varchar(50),
	@pCorreo varchar(250)
)
as begin
	declare @id int
	INSERT INTO [dbo].[USUARIO]
			   (nombreUsuario_usu
			   ,clave_usu
			   ,nombre_usu
			   ,apellidoPaterno_usu
			   ,apellidoMaterno_usu
			   ,correo_usu
			   ,fechaRegistro_usu
			   ,estado_usu)
		 VALUES
			   (@pNombreUsuario
			   ,@pClave
			   ,@pNombre
			   ,@pApellidoPaterno
			   ,@pApellidoMaterno
			   ,@pCorreo
			   ,GETDATE()
			   ,1)
		set @id = @@IDENTITY

		
	select @id as IdUsuario
end

