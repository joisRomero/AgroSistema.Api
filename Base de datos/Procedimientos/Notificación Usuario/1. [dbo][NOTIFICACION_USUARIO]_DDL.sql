CREATE TABLE NOTIFICACION_USUARIO (
	id_not INT IDENTITY(1,1) PRIMARY KEY,
	id_usu INT NOT NULL,
	descripcion_not VARCHAR(150),
	fechaCreacion_not DATETIME
	FOREIGN KEY (id_usu) REFERENCES USUARIO(id_usu)
);