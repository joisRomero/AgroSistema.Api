USE agro_sistema_bd
GO

IF EXISTS (SELECT * FROM sysobjects WHERE name='sp_ListarInvitacionesSociedad') 
	BEGIN
		DROP PROCEDURE sp_ListarInvitacionesSociedad;
	END
GO

CREATE PROCEDURE dbo.sp_ListarInvitacionesSociedad
	@idUsuario int
AS
BEGIN

	SELECT
		i.id_inviSoc AS IdInvitacion,
		CONCAT(u.nombre_usu,' ',u.apellidoPaterno_usu,' ',u.apellidoMaterno_usu) AS NombreEmisor,
		s.nombre_soc AS NombreSociedad
	FROM INVITACION_SOCIEDAD i
		INNER JOIN USUARIO u ON i.idEmisor_usu = u.id_usu
		INNER JOIN SOCIEDAD s ON i.id_soc = s.id_soc
	WHERE i.idReceptor_usu = @idUsuario

END