--SELECT * FROM DATO_COMUN

INSERT INTO DATO_COMUN (id_datoComun,codigoTabla,codigoFila,descripcionCorta,descripcionLarga,estado,usuarioInserta,fechaInserta)
VALUES(70000,7,0,'UNIDAD SEMILLA','Unidades para las semillas',1,'admin',dbo.GETDATENEW())

INSERT INTO DATO_COMUN (id_datoComun,codigoTabla,codigoFila,descripcionCorta,descripcionLarga,estado,usuarioInserta,fechaInserta)
VALUES(70001,7,1,'General','General',1,'admin',dbo.GETDATENEW()),
(70002,7,2,'und','Unidad',1,'admin',dbo.GETDATENEW()),
(70003,7,3,'Bolsa','Bolsa',1,'admin',dbo.GETDATENEW()),
(70004,7,4,'kg','Kilogramo',1,'admin',dbo.GETDATENEW()),
(70005,7,5,'Tercios','Tercios',1,'admin',dbo.GETDATENEW()),
(70006,7,6,'Plantines','Plantines',1,'admin',dbo.GETDATENEW()),
(70007,7,7,'Sobres','Sobres',1,'admin',dbo.GETDATENEW()),
(70008,7,8,'Badejas de plantines','Badejas de plantines',1,'admin',dbo.GETDATENEW()),
(70009,7,9,'Sacos','Sacos',1,'admin',dbo.GETDATENEW())

INSERT INTO DATO_COMUN (id_datoComun,codigoTabla,codigoFila,descripcionCorta,descripcionLarga,estado,usuarioInserta,fechaInserta)
VALUES(40001,4,1,'General','General',1,'admin',dbo.GETDATENEW()),
(40002,4,2,'Sacos','Sacos',1,'admin',dbo.GETDATENEW()),
(40003,4,3,'kg','Kilogramos',1,'admin',dbo.GETDATENEW())

INSERT INTO DATO_COMUN (id_datoComun,codigoTabla,codigoFila,descripcionCorta,descripcionLarga,estado,usuarioInserta,fechaInserta)
VALUES(50001,5,1,'General','General',1,'admin',dbo.GETDATENEW()),
(50002,5,2,'l','Litros',1,'admin',dbo.GETDATENEW())

INSERT INTO DATO_COMUN (id_datoComun,codigoTabla,codigoFila,descripcionCorta,descripcionLarga,estado,usuarioInserta,fechaInserta)
VALUES(60001,6,1,'General','General',1,'admin',dbo.GETDATENEW()),
(60002,6,2,'Sobres','Sobres',1,'admin',dbo.GETDATENEW()),
(60003,6,3,'l','Litros',1,'admin',dbo.GETDATENEW()),
(60004,6,4,'ml','Mililitros',1,'admin',dbo.GETDATENEW()),
(60005,6,5,'gr','Gramos',1,'admin',dbo.GETDATENEW()),
(60006,6,6,'kg','Kilogramos',1,'admin',dbo.GETDATENEW())


--SELECT * FROM TIPO_AGROQUIMICO
INSERT INTO TIPO_AGROQUIMICO(nombre_tipoAgroqui,descripcion_tipoAgroqui,estado_tipoAgroqui,usuarioInserta_tipoAgroqui,fechaInserta_tipoAgroqui)
VALUES
('Fungicidas','Fungicidas',1,'admin',dbo.GETDATENEW()),
('Insecticidas','Insecticidas',1,'admin',dbo.GETDATENEW()),
('Abonos foliares','Abonos foliares',1,'admin',dbo.GETDATENEW()),
('Herbicidas','Herbicidas',1,'admin',dbo.GETDATENEW()),
('Adherente','Adherente',1,'admin',dbo.GETDATENEW()),
('Otros','Otros',1,'admin',dbo.GETDATENEW())