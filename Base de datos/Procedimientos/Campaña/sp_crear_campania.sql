IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_crear_campania')
	DROP PROCEDURE sp_crear_campania
GO

CREATE PROCEDURE sp_crear_campania
(
	@p_nombreTerreno_camp			varchar(100)
	,@p_areaSembrar_camp			decimal(9,2)
	,@p_unidadTerrenoDatoComun_camp	int
	,@p_nombre_camp					varchar(100)
	,@p_descripcion_camp			varchar(250)
	,@p_fechaInicio_camp			varchar(20)
	--,@p_fechaFin_camp				datetime = NULL
	,@p_id_culti					int
	,@p_id_soc						int = NULL
	,@p_id_usu						int = NULL
	,@p_usuarioInserta_camp			varchar(50)
)
AS
BEGIN
	DECLARE @s_fechaInicio_camp VARCHAR(20)
	
	SET @s_fechaInicio_camp = CONVERT(DATETIME,@p_fechaInicio_camp,103)

	IF @p_id_soc = 0
		SET @p_id_soc = NULL
	
	IF @p_id_usu = 0
		SET @p_id_usu = NULL 

	INSERT INTO CAMPANIA(
		nombreTerreno_camp
		,areaSembrar_camp
		,unidadTerrenoDatoComun_camp
		,nombre_camp
		,descripcion_camp
		,fechaInicio_camp
		--,fechaFin_camp
		,estado_camp
		,id_culti
		,id_soc
		,id_usu
		,usuarioInserta_camp
		,fechaInserta_camp
	)
	VALUES(
		@p_nombreTerreno_camp
		,@p_areaSembrar_camp
		,@p_unidadTerrenoDatoComun_camp
		,@p_nombre_camp
		,@p_descripcion_camp
		,@s_fechaInicio_camp
		--,@p_fechaFin_camp
		,1
		,@p_id_culti
		,@p_id_soc
		,@p_id_usu
		,@p_usuarioInserta_camp
		,GETDATE()
	)
END