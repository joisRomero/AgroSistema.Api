IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_agregar_abonacion')
	DROP PROCEDURE sp_agregar_abonacion
GO

CREATE PROCEDURE sp_agregar_abonacion(
	@p_cantidad_abonaci INT
	,@p_unidadDatoComun INT
	,@p_id_abono INT
	,@p_id_acti INT
	,@p_usuarioInserta_abonaci VARCHAR(50)
)
AS
BEGIN
	INSERT INTO ABONACION(
		cantidad_abonaci
		,unidadDatoComun
		,id_abono
		,id_acti
		,usuarioInserta_abonaci
		,fechaInserta_abonaci
	)
	VALUES(
		@p_cantidad_abonaci
		,@p_unidadDatoComun
		,@p_id_abono
		,@p_id_acti
		,@p_usuarioInserta_abonaci
		,dbo.GETDATENEW()
	)
END