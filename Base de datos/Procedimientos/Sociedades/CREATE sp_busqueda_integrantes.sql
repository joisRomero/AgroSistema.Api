IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_busqueda_integrantes')
	DROP PROCEDURE sp_busqueda_integrantes
GO

CREATE PROCEDURE sp_busqueda_integrantes(
	 @p_nombreUsuario	varchar(150)
	 ,@p_idUsuario		int
	 ,@p_id_soc			int
)
AS
BEGIN
	IF(@p_nombreUsuario = '')
		SET @p_nombreUsuario = NULL

	SELECT DISTINCT u.id_usu AS IdUsuario
		,CONCAT(u.nombre_usu,' ',u.apellidoPaterno_usu,' ',u.apellidoMaterno_usu) AS NombreCompleto
		,u.nombreUsuario_usu AS NombreUsuario
	FROM USUARIO u WITH(NOLOCK)
	WHERE
	u.id_usu NOT IN (
		SELECT 
			id_usu
		FROM USUARIO_SOCIEDAD us WITH(NOLOCK) 
		WHERE us.id_soc= @p_id_soc
	)
	AND u.id_usu NOT IN (
		SELECT 
			ins.idReceptor_usu
		FROM INVITACION_SOCIEDAD ins WITH(NOLOCK)
		WHERE 
		ins.id_soc= @p_id_soc
		AND ins.estadoInvitacion_inviSoc IN(0,1)
	)
	AND NOT u.id_usu = @p_idUsuario 
	AND (CONCAT(u.nombre_usu,' ',u.apellidoPaterno_usu,' ',u.apellidoMaterno_usu) LIKE '%'+@p_nombreUsuario+'%'
	OR u.nombreUsuario_usu LIKE '%'+@p_nombreUsuario+'%')
	
END


