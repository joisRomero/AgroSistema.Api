--SELECT * FROM DATO_COMUN 

INSERT INTO DATO_COMUN (id_datoComun,codigoTabla,codigoFila,descripcionCorta,descripcionLarga,estado,usuarioInserta,fechaInserta)
VALUES (40000,4,0,'UNIDAD ABONACION','Unidades para la tabla ABONACION',1,'admin',dbo.GETDATENEW()),
(50000,5,0,'UNIDAD FUMIGACION','Unidades para la tabla FUMIGACION',1,'admin',dbo.GETDATENEW()),
(60000,6,0,'UNIDAD FUMIGACION_DETALLE','Unidades para la tabla FUMIGACION_DETALLE',1,'admin',dbo.GETDATENEW())