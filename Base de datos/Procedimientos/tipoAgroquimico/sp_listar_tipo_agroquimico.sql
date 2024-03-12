
IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'P' AND name = 'sp_listar_tipo_agroquimico')
	DROP PROCEDURE sp_listar_tipo_agroquimico
GO
CREATE PROCEDURE sp_listar_tipo_agroquimico
AS
BEGIN
	SELECT id_tipoAgroqui as Id
		  ,nombre_tipoAgroqui as Nombre
	  FROM TIPO_AGROQUIMICO
	  WHERE estado_tipoAgroqui = 1
END