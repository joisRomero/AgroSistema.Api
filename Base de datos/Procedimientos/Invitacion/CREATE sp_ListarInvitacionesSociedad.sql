
IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_ListarInvitacionesSociedad')
	DROP PROCEDURE sp_ListarInvitacionesSociedad
GO


CREATE PROCEDURE sp_ListarInvitacionesSociedad
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
	WHERE 
	i.estadoEliminado_inviSoc = 0
	AND i.estadoInvitacion_inviSoc = 0
	AND i.idReceptor_usu = @idUsuario
END