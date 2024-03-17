IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_eliminar_listaTrabajador')
	DROP PROCEDURE sp_eliminar_listaTrabajador
GO

CREATE PROCEDURE sp_eliminar_listaTrabajador(
	@p_XML_ListaTrabajador	XML	NULL
	,@p_usuarioElimina_trab VARCHAR(50)
)
AS
BEGIN
	DECLARE @s_XML_ListaTrabajador XML 

	SET @s_XML_ListaTrabajador = @p_XML_ListaTrabajador

	IF OBJECT_ID('tempdb..#temp_TablaTrabajadores') IS NOT NULL
		DROP TABLE #temp_TablaTrabajadores

	SELECT
		TD.value('(IdTrabajador/text())[1]','int') AS IdTrabajador
	INTO #temp_TablaTrabajadores
	FROM @s_XML_ListaTrabajador.nodes('/DocumentElement/Trabajador') AS TEMPTABLE(TD)


	UPDATE t
		SET 
		t.estado_trab = 0
		,t.usuarioElimina_trab = @p_usuarioElimina_trab
		,t.fechaElimina_trab = dbo.GETDATENEW()
	FROM TRABAJADOR t
	WHERE t.id_acti NOT IN (SELECT IdTrabajador FROM #temp_TablaTrabajadores)
	
END