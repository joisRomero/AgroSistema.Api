USE [agro_sistema_bd]
IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_ObtenerMensajesError') 
	BEGIN
		DROP PROCEDURE sp_ObtenerMensajesError;
	END
GO
create procedure sp_ObtenerMensajesError(
	 @aplicacionGuid varchar(200) = null
)
as begin 
	select codigo_menError as Codigo,
			aplicacionGuid_menError as AplicacionGuid,
			descripcion_menError as Descripcion
	from MENSAJE_ERROR with(nolock)
	where (ISNULL(@aplicacionGuid,'') = '' or @aplicacionGuid = aplicacionGuid_menError)
end
