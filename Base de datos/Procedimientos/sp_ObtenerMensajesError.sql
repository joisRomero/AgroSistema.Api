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
	select codigo_tabMenError as Codigo,
			aplicacionGuid_tabMenError as AplicacionGuid,
			descripcion_tabMenError as Descripcion
	from TABLA_MENSAJE_ERROR with(nolock)
	where (ISNULL(@aplicacionGuid,'') = '' or @aplicacionGuid = aplicacionGuid_tabMenError)
end