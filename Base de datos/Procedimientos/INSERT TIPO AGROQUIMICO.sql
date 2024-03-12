
INSERT INTO [dbo].[TIPO_AGROQUIMICO]
           ([nombre_tipoAgroqui]
           ,[estado_tipoAgroqui]
           ,[usuarioInserta_tipoAgroqui]
           ,[fechaInserta_tipoAgroqui])
     VALUES
           ('General'
           ,1
           ,'SYSTEM'
           ,dbo.GETDATENEW())
