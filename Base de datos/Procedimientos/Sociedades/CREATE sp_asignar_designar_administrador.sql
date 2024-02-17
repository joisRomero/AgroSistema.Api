IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_asignar_designar_administrador')
	DROP PROCEDURE sp_asignar_designar_administrador
GO

CREATE PROCEDURE sp_asignar_designar_administrador (
	@p_id_usu	INT
	,@p_id_soc	INT
	,@p_usuarioModifica_usuSoc VARCHAR(50)
	,@p_accion	CHAR(1)
)
AS
BEGIN
	IF(@p_accion = 'A')
	BEGIN
		UPDATE USUARIO_SOCIEDAD
		SET	esAdministrador_usuSoc = 1
			,usuarioModifica_usuSoc = @p_usuarioModifica_usuSoc
			,fechaModifica_usuSoc = GETDATE()
		WHERE 
		id_usu = @p_id_usu 
		AND id_soc = @p_id_soc
	END
	ELSE IF(@p_accion = 'D')
	BEGIN
		UPDATE USUARIO_SOCIEDAD
		SET	esAdministrador_usuSoc = 0
			,usuarioModifica_usuSoc = @p_usuarioModifica_usuSoc
			,fechaModifica_usuSoc = GETDATE()
		WHERE 
		id_usu = @p_id_usu 
		AND id_soc = @p_id_soc
	END
END
