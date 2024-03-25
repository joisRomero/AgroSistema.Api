IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_eliminar_listaAbonacion')
	DROP PROCEDURE sp_eliminar_listaAbonacion
GO

CREATE PROCEDURE sp_eliminar_listaAbonacion(
	@p_id_acti INT
	,@p_XML_Abonacion XML NULL
	,@p_usuarioElimina_abonaci VARCHAR(50)
)
AS
BEGIN
	IF OBJECT_ID('tempdb..#temp_TablaAbonacion') IS NOT NULL
	DROP TABLE #temp_TablaAbonacion

	DECLARE @s_XML_Abonacion	XML = NULL

	SET @s_XML_Abonacion	= @p_XML_Abonacion

	SELECT
		TD.value('(IdAbonacion/text())[1]','int') AS IdAbonacion
	INTO #temp_TablaAbonacion
	FROM @s_XML_Abonacion.nodes('/DocumentElement/Abonacion') AS TEMPTABLE(TD)

	UPDATE a
		SET a.estado_abonaci = 0
			,a.usuarioElimina_abonaci = @p_usuarioElimina_abonaci
			,a.fechaElimina_abonaci = dbo.GETDATENEW()
	FROM ABONACION a 
	WHERE a.id_abonaci NOT IN (SELECT IdAbonacion FROM #temp_TablaAbonacion)
	AND a.id_acti = @p_id_acti
END