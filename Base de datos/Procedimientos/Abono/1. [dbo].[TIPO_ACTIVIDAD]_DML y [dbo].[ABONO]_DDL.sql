--- INSERTAR TIPO_ACTIVIDAD GENERALES
INSERT INTO TIPO_ACTIVIDAD (nombre_tipoActi, realizadaPor_tipoActi, descripcion_tipoActi, estado_tipoActi, usuarioInserta_tipoActi, fechaInserta_tipoActi)
VALUES ('Fumigación', 'A', 'Fumigación', '1', 'SYSTEM', GETDATE()), ('Abonamiento', 'A', 'Abonamiento', '1', 'SYSTEM', GETDATE()), ('Siembra', 'A', 'Siembra', '1', 'SYSTEM', GETDATE()),('General', 'A', 'General', '1', 'SYSTEM', GETDATE())
	
--- NUEVOS CAMPOS DE LA TABLA ABONO
ALTER TABLE ABONO ADD descripcion_abono VARCHAR(150) NULL
ALTER TABLE ABONO ADD id_usu INT NULL
ALTER TABLE ABONO ADD CONSTRAINT FK_ABONO_USUARIO FOREIGN KEY (id_usu) REFERENCES USUARIO(id_usu)