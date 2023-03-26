CREATE DATABASE agro_sistema_bd

use agro_sistema_bd

create table DATO_COMUN(
	id_datoComun int NOT NULL,
	codigoTabla int NOT NULL,
	codigoFila int NOT NULL,
	descripcionCorta varchar(100) NULL,
	descripcionLarga varchar(2000) NULL,
	valorTexto1 varchar(50) NULL,
	valorTexto2 varchar(50) NULL,
	valorTexto3 varchar(50) NULL,
	valorTexto4 varchar(2000) NULL,
	valorTexto5 varchar(50) NULL,
	valorTexto6 varchar(50) NULL,
	estado bit NOT NULL,	
	usuarioInserta varchar(50) NULL,
	fechaInserta datetime NOT NULL,
	usuarioModifica varchar(50) NULL,
	fechaModifica datetime NULL,
	usuarioElimina_soc varchar(50) NULL,
	fechaElimina_soc datetime NULL
)

create table USUARIO(
	id_usu int primary key identity (1,1) not null, 
	nombreUsuario_usu varchar(50) not null, 
	clave_usu varchar(30) not null, 
	nombre_usu varchar(50) not null, 
	apellidoPaterno_usu varchar(50) not null, 
	apellidoMaterno_usu varchar(50) not null, 
	correo_usu varchar(250) not null,
	fechaRegistro_usu datetime not null,
	estado_usu bit NOT NULL,
)

create table SOCIEDAD(
	id_soc int primary key identity (1,1) not null, 
	nombre_soc varchar(100) not null, 
	fechaCreacion_soc datetime not null, 
	estado_soc bit NOT NULL,
	usuarioInserta_soc varchar(50) NULL,
	fechaInserta_soc datetime NOT NULL,
	usuarioModifica_soc varchar(50) NULL,
	fechaModifica_soc datetime NULL,
	usuarioElimina_soc varchar(50) NULL,
	fechaElimina_soc datetime NULL
)

create table USUARIO_SOCIEDAD (
	id_usuSoc int primary key identity (1,1) not null, 
	esAdministrador_usuSoc bit not null, 
	estado_usuSoc bit NOT NULL,
	id_soc int not null, 
	id_usu int not null, 
	usuarioInserta_usuSoc varchar(50) NULL,
	fechaInserta_usuSoc datetime NOT NULL,
	usuarioModifica_usuSoc varchar(50) NULL,
	fechaModifica_usuSoc datetime NULL,
	usuarioElimina_usuSoc varchar(50) NULL,
	fechaElimina_usuSoc datetime NULL,
	CONSTRAINT fk_usuSoc_usu FOREIGN KEY (id_usu) REFERENCES USUARIO(id_usu),
	CONSTRAINT fk_usuSoc_soc FOREIGN KEY (id_soc) REFERENCES SOCIEDAD(id_soc),
)

CREATE TABLE CULTIVO(
	id_culti int primary key IDENTITY (1,1) NOT NULL,
	nombre_culti varchar (100) NOT NULL,
	estado_culti bit NOT NULL,
	id_usu int not null,
	usuarioInserta_culti varchar(50) NULL,
	fechaInserta_culti datetime NOT NULL,
	usuarioModifica_culti varchar(50) NULL,
	fechaModifica_culti datetime NULL,
	usuarioElimina_culti varchar(50) NULL,
	fechaElimina_culti datetime NULL,
	CONSTRAINT fk_culti_usu FOREIGN KEY (id_usu) REFERENCES USUARIO(id_usu),
) 

CREATE TABLE CAMPANIA(
	id_camp int primary key identity (1,1) not null,
	nombreTerreno_camp varchar(100) not null,
	areaSembrar_camp smallint not null, 
	unidadTerrenoDatoComun_camp int not null, 
	nombre_camp varchar(100) not null, 
	descripcion_camp varchar(250) not null,
	fechaInicio_camp datetime not null, 
	fechaFin_camp datetime null, 
	estado_camp bit not null,
	id_culti int not null, 
	id_soc int null, 
	id_usu int null, 
	usuarioInserta_camp varchar(50) NULL,
	fechaInserta_camp datetime NOT NULL,
	usuarioModifica_camp varchar(50) NULL,
	fechaModifica_camp datetime NULL,
	usuarioElimina_camp varchar(50) NULL,
	fechaElimina_camp datetime NULL,
	CONSTRAINT fk_camp_culti FOREIGN KEY (id_culti) REFERENCES CULTIVO(id_culti),
	CONSTRAINT fk_camp_soc FOREIGN KEY (id_soc) REFERENCES SOCIEDAD(id_soc),
	CONSTRAINT fk_camp_usu FOREIGN KEY (id_usu) REFERENCES USUARIO(id_usu),
	CONSTRAINT fk_camp_datoComun FOREIGN KEY (unidadTerrenoDatoComun_camp) REFERENCES DATO_COMUN(id_datoComun)
)

CREATE TABLE COSECHA(
	id_cose int primary key identity(1,1) not null, 
	numero_cose smallint not null, 
	fecha_cose datetime not null, 
	descripcion_cose varchar(250) null, 
	estado_cose bit not null, 
	id_camp int not null, 

	usuarioInserta_cose varchar(50) NULL,
	fechaInserta_cose datetime NOT NULL,
	usuarioModifica_cose varchar(50) NULL,
	fechaModifica_cose datetime NULL,
	usuarioElimina_cose varchar(50) NULL,
	fechaElimina_cose datetime NULL,
	CONSTRAINT fk_cose_camp FOREIGN KEY (id_camp) REFERENCES CAMPANIA(id_camp),
)

CREATE TABLE COSECHA_DETALLE(
	id_coseDet int primary key identity(1,1) not null, 
	cantidad_coseDet smallint not null, 
	unidadDatoComun_coseDet int not null, 
	calidadDatoComun_coseDet int not null, 
	id_cose int not null,

	usuarioInserta_coseDet varchar(50) NULL,
	fechaInserta_coseDet datetime NOT NULL,
	usuarioModifica_coseDet varchar(50) NULL,
	fechaModifica_coseDet datetime NULL,
	usuarioElimina_coseDet varchar(50) NULL,
	fechaElimina_coseDet datetime NULL,

	CONSTRAINT fk_coseDet_datoComun FOREIGN KEY (unidadDatoComun_coseDet) REFERENCES DATO_COMUN(id_datoComun), 
	CONSTRAINT fk_coseDet_datoComun2 FOREIGN KEY (calidadDatoComun_coseDet) REFERENCES DATO_COMUN(id_datoComun), 
	CONSTRAINT fk_coseDet_cose FOREIGN KEY (id_cose) REFERENCES COSECHA(id_cose), 
)

CREATE TABLE TIPO_ACTIVIDAD(
	id_tipoActi int primary key identity (1,1) not null, 
	nombre_tipoActi varchar(100) not null, 
	realizadaPor_tipoActi char(1) not null, 
	descripcion_tipoActi varchar(250) null, 
	estado_tipoActi bit not null,

	usuarioInserta_tipoActi varchar(50) NULL,
	fechaInserta_tipoActi datetime NOT NULL,
	usuarioModifica_tipoActi varchar(50) NULL,
	fechaModifica_tipoActi datetime NULL,
	usuarioElimina_tipoActi varchar(50) NULL,
	fechaElimina_tipoActi datetime NULL 
)

CREATE TABLE ACTIVIDAD(
	id_acti bigint primary key identity (1,1) not null, 
	fecha_acti datetime not null,
	descripcion_acti varchar(250) null,
	cantidadSemilla_acti smallint null, 
	unidadSemillaDatoComun_acti int null, 
	id_camp int not null, 
	id_tipoActi int not null, 
	estado_acti bit not null,
	usuarioInserta_acti varchar(50) NULL,
	fechaInserta_acti datetime NOT NULL,
	usuarioModifica_acti varchar(50) NULL,
	fechaModifica_acti datetime NULL,
	usuarioElimina_acti varchar(50) NULL,
	fechaElimina_acti datetime NULL,
	CONSTRAINT fk_acti_datoComun FOREIGN KEY (unidadSemillaDatoComun_acti) REFERENCES DATO_COMUN(id_datoComun),
	CONSTRAINT fk_acti_camp FOREIGN KEY (id_camp) REFERENCES CAMPANIA(id_camp),
	CONSTRAINT fk_acti_tipoActi FOREIGN KEY (id_tipoActi) REFERENCES TIPO_ACTIVIDAD(id_tipoActi)
)

CREATE TABLE TIPO_GASTO(
	id_tipoGasto int primary key identity (1,1) not null, 
	nombre_tipoGasto varchar(100) not null, 
	descripcion_tipoGasto varchar(250) null, 
	estado_tipoGasto bit not null, 
	usuarioInserta_tipoGasto varchar(50) NULL,
	fechaInserta_tipoGasto datetime NOT NULL,
	usuarioModifica_tipoGasto varchar(50) NULL,
	fechaModifica_tipoGasto datetime NULL,
	usuarioElimina_tipoGasto varchar(50) NULL,
	fechaElimina_tipoGasto datetime NULL,
)

CREATE TABLE GASTO_DETALLE(
	id_gastoDet int primary key identity(1,1) not null, 
	descripcion_gastoDet varchar(250) null, 
	cantidad_gastoDet smallint null, 
	costoUnitario_gastoDet smallmoney null, 
	costoTotal_gastoDet smallmoney null, 
	fecha_gastoDet datetime not null,
	id_tipoGasto int not null, 
	id_acti bigint null, 
	id_camp int null,
	usuarioInserta_gastoDet varchar(50) NULL,
	fechaInserta_gastoDet datetime NOT NULL,
	usuarioModifica_gastoDet varchar(50) NULL,
	fechaModifica_gastoDet datetime NULL,
	usuarioElimina_gastoDet varchar(50) NULL,
	fechaElimina_gastoDet datetime NULL, 
	CONSTRAINT fk_gastoDet_tipoGasto FOREIGN KEY (id_tipoGasto) REFERENCES TIPO_GASTO(id_tipoGasto),
	CONSTRAINT fk_gastoDet_acti FOREIGN KEY (id_acti) REFERENCES ACTIVIDAD(id_acti),
	CONSTRAINT fk_gastoDet_camp FOREIGN KEY (id_camp) REFERENCES CAMPANIA(id_camp)
)

CREATE TABLE TIPO_TRABAJADOR(
	id_tipoTrab int primary key identity(1,1) not null, 
	nombre_tipoTrab varchar(100) not null, 
	descripcion_tipoTrab varchar(250) null, 
	estado_tipoTrab bit not null,

	usuarioInserta_tipoTrab varchar(50) NULL,
	fechaInserta_tipoTrab datetime NOT NULL,
	usuarioModifica_tipoTrab varchar(50) NULL,
	fechaModifica_tipoTrab datetime NULL,
	usuarioElimina_tipoTrab varchar(50) NULL,
	fechaElimina_tipoTrab datetime NULL
)

CREATE TABLE TRABAJADOR(
	id_trab int primary key identity (1,1) not null, 
	descripcion_trab varchar(250) null, 
	cantidad_trab smallint default 0, 
	costoUnitario_trab smallmoney default 0, 
	costoTotal_trab smallmoney default 0, 
	id_acti bigint not null,
	id_tipoTrab int not null, 
	estado_trab bit not null,

	usuarioInserta_trab varchar(50) NULL,
	fechaInserta_trab datetime NOT NULL,
	usuarioModifica_trab varchar(50) NULL,
	fechaModifica_trab datetime NULL,
	usuarioElimina_trab varchar(50) NULL,
	fechaElimina_trab datetime NULL,
	CONSTRAINT fk_trab_acti FOREIGN KEY (id_acti) REFERENCES ACTIVIDAD(id_acti),
	CONSTRAINT fk_trab_tipoTrab FOREIGN KEY (id_tipoTrab) REFERENCES TIPO_TRABAJADOR(id_tipoTrab)
)

CREATE TABLE TIPO_AGROQUIMICO(
	id_tipoAgroqui int primary key identity (1,1) not null,
	nombre_tipoAgroqui varchar(100) not null,
	descripcion_tipoAgroqui varchar(250) null,
	estado_tipoAgroqui bit not null,

	usuarioInserta_tipoAgroqui varchar(50) NULL,
	fechaInserta_tipoAgroqui datetime NOT NULL,
	usuarioModifica_tipoAgroqui varchar(50) NULL,
	fechaModifica_tipoAgroqui datetime NULL,
	usuarioElimina_tipoAgroqui varchar(50) NULL,
	fechaElimina_tipoAgroqui datetime NULL
)

create table AGROQUIMICO(
	id_agroqui int primary key identity (1,1) not null, 
	nombre_agroqui varchar(100) not null, 
	descripcion_agroqui varchar(250) null,
	estado_agrpqui bit not null, 
	id_tipoAgroqui int not null,
	usuarioInserta_agrpqui varchar(50) NULL,
	fechaInserta_agrpqui datetime NOT NULL,
	usuarioModifica_agrpqui varchar(50) NULL,
	fechaModifica_agrpqui datetime NULL,
	usuarioElimina_agrpqui varchar(50) NULL,
	fechaElimina_agrpqui datetime NULL,
	CONSTRAINT fk_agroqui_tipoagroqui FOREIGN KEY (id_tipoAgroqui) REFERENCES TIPO_AGROQUIMICO(id_tipoAgroqui),
)

CREATE TABLE FUMIGACION(
	id_fumi int primary key identity(1,1) not null, 
	cantidad_fumi smallint not null, 
	unidadDatoComun_fumi int not null,
	estado_fumi bit not null,
	id_acti bigint not null,
	usuarioInserta_fumi varchar(50) NULL,
	fechaInserta_fumi datetime NOT NULL,
	usuarioModifica_fumi varchar(50) NULL,
	fechaModifica_fumi datetime NULL,
	usuarioElimina_fumi varchar(50) NULL,
	fechaElimina_fumi datetime NULL,
	CONSTRAINT fk_fumi_acti FOREIGN KEY (id_acti) REFERENCES ACTIVIDAD(id_acti)
)

CREATE TABLE FUMIGACION_DETALLE(
	id_fumiDet int primary key identity(1,1) not null, 
	cantidad_fumiDet smallint not null, 
	unidadDatoComun_fumiDet int not null,
	id_fumi int not null,
	id_agroqui int not null,
	usuarioInserta_fumiDet varchar(50) NULL,
	fechaInserta_fumiDet datetime NOT NULL,
	usuarioModifica_fumiDet varchar(50) NULL,
	fechaModifica_fumiDet datetime NULL,
	usuarioElimina_fumiDet varchar(50) NULL,
	fechaElimina_fumiDet datetime NULL,
	CONSTRAINT fk_fumiDet_datoComun FOREIGN KEY (unidadDatoComun_fumiDet) REFERENCES DATO_COMUN(id_datoComun),
	CONSTRAINT fk_fumiDet_fumi FOREIGN KEY (id_fumi) REFERENCES FUMIGACION(id_fumi),
	CONSTRAINT fk_fumiDet_agroqui FOREIGN KEY (id_agroqui) REFERENCES AGROQUIMICO(id_agroqui)
)

CREATE TABLE COMPRA_AGROQUIMICO(
	id_compraAgroqui int primary key identity(1,1) not null, 
	fecha_compraAgroqui datetime not null, 
	estado_compraAgroqui bit not null,
	id_soc int null, 
	id_usu int null, 
	usuarioInserta_compraAgroqui  varchar(50) NULL,
	fechaInserta_compraAgroqui  datetime NOT NULL,
	usuarioModifica_compraAgroqui  varchar(50) NULL,
	fechaModifica_compraAgroqui  datetime NULL,
	usuarioElimina_compraAgroqui  varchar(50) NULL,
	fechaElimina_compraAgroqui  datetime NULL,
	CONSTRAINT fk_compraAgroqui_soc FOREIGN KEY (id_soc) REFERENCES SOCIEDAD(id_soc),
	CONSTRAINT fk_compraAgroqui_usu FOREIGN KEY (id_usu) REFERENCES USUARIO(id_usu),
)

CREATE TABLE COMPRA_AGROQUIMICO_DETALLE(
	id_compraAgroquiDet int primary key identity(1,1) not null,
	precio_compraAgroquiDet smallmoney not null,
	cantidad_compraAgroquiDet smallint not null, 
	unidadDatoComun_compraAgroquiDet int not null, 
	id_agroqui int not null, 
	id_compraAgroqui int not null,
	usuarioInserta_compraAgroquiDet  varchar(50) NULL,
	fechaInserta_compraAgroquiDet  datetime NOT NULL,
	usuarioModifica_compraAgroquiDet  varchar(50) NULL,
	fechaModifica_compraAgroquiDet  datetime NULL,
	usuarioElimina_compraAgroquiDet  varchar(50) NULL,
	fechaElimina_compraAgroquiDet  datetime NULL,
	CONSTRAINT fk_compraAgroquiDet_datoComun FOREIGN KEY (unidadDatoComun_compraAgroquiDet) REFERENCES DATO_COMUN(id_datoComun),
	CONSTRAINT fk_compraAgroquiDet_agroqui FOREIGN KEY (id_agroqui) REFERENCES AGROQUIMICO(id_agroqui),
	CONSTRAINT fk_compraAgroquiDet_compraAgroqui FOREIGN KEY (id_compraAgroqui) REFERENCES COMPRA_AGROQUIMICO(id_compraAgroqui),
)

CREATE TABLE ALMACEN_AGROQUIMICO(
	id_almaAgroqui int primary key identity(1,1) not null, 
	stock_almaAgroqui smallint not null, 
	unidadDatoComun_almaAgroqui int not null, 
	estado_agroqui bit not null,
	id_agroqui int not null, 
	id_soc int null, 
	id_usu int null, 
	usuarioInserta_almaAgroqui  varchar(50) NULL,
	fechaInserta_almaAgroqui  datetime NOT NULL,
	usuarioModifica_almaAgroqui  varchar(50) NULL,
	fechaModifica_almaAgroqui  datetime NULL,
	usuarioElimina_almaAgroqui  varchar(50) NULL,
	fechaElimina_almaAgroqui  datetime NULL,
	CONSTRAINT fk_almaAgroqui_soc FOREIGN KEY (id_soc) REFERENCES SOCIEDAD(id_soc),
	CONSTRAINT fk_almaAgroqui_usu FOREIGN KEY (id_usu) REFERENCES USUARIO(id_usu),
	CONSTRAINT fk_almaAgroqui_agroqui FOREIGN KEY (id_agroqui) REFERENCES AGROQUIMICO(id_agroqui),
)

CREATE TABLE ABONO(
	id_abono int primary key identity(1,1) not null, 
	nombre_abono varchar(100) not null, 
	estado_abono bit not null, 
	usuarioInserta_abono  varchar(50) NULL,
	fechaInserta_abono  datetime NOT NULL,
	usuarioModifica_abono  varchar(50) NULL,
	fechaModifica_abono  datetime NULL,
	usuarioElimina_abono  varchar(50) NULL,
	fechaElimina_abono  datetime NULL,
)

CREATE TABLE ABONACION(
	id_abonaci int primary key identity(1,1) not null, 
	cantidad_abonaci smallint not null, 
	unidadDatoComun int not null, 
	id_abono int not null, 
	id_acti bigint not null,
	usuarioInserta_abonaci varchar(50) NULL,
	fechaInserta_abonaci datetime NOT NULL,
	usuarioModifica_abonaci varchar(50) NULL,
	fechaModifica_abonaci datetime NULL,
	usuarioElimina_abonaci varchar(50) NULL,
	fechaElimina_abonaci datetime NULL,
	CONSTRAINT fk_abonaci_acti FOREIGN KEY (id_acti) REFERENCES ACTIVIDAD(id_acti),
	CONSTRAINT fk_abonaci_abono FOREIGN KEY (id_abono) REFERENCES ABONO(id_abono),
)

CREATE TABLE COMPRA_ABONO(
	id_compraAbono int primary key identity(1,1) not null, 
	fecha_compraAbono datetime not null, 
	estado_compraAbono bit not null,
	id_soc int null, 
	id_usu int null, 
	usuarioInserta_compraAbono  varchar(50) NULL,
	fechaInserta_compraAbono  datetime NOT NULL,
	usuarioModifica_compraAbono  varchar(50) NULL,
	fechaModifica_compraAbono  datetime NULL,
	usuarioElimina_compraAbono  varchar(50) NULL,
	fechaElimina_compraAbono  datetime NULL,
	CONSTRAINT fk_compraAbono_soc FOREIGN KEY (id_soc) REFERENCES SOCIEDAD(id_soc),
	CONSTRAINT fk_compraAbono_usu FOREIGN KEY (id_usu) REFERENCES USUARIO(id_usu),
)

CREATE TABLE COMPRA_ABONO_DETALLE(
	id_compraAbonoDet int primary key identity(1,1) not null,
	precio_compraAbonoDet smallmoney not null,
	cantidad_compraAbonoDet smallint not null, 
	unidadDatoComun_compraAbonoDet int not null, 
	id_abono int not null, 
	id_compraAbono int not null,
	usuarioInserta_compraAbonoDet  varchar(50) NULL,
	fechaInserta_compraAbonoDet  datetime NOT NULL,
	usuarioModifica_compraAbonoDet  varchar(50) NULL,
	fechaModifica_compraAbonoDet  datetime NULL,
	usuarioElimina_compraAbonoDet  varchar(50) NULL,
	fechaElimina_compraAbonoDet  datetime NULL,
	CONSTRAINT fk_compraAbonoDet_datoComun FOREIGN KEY (unidadDatoComun_compraAbonoDet) REFERENCES DATO_COMUN(id_datoComun),
	CONSTRAINT fk_compraAbonoDet_abono FOREIGN KEY (id_abono) REFERENCES ABONO(id_abono),
	CONSTRAINT fk_compraAbonoDet_compraAbono FOREIGN KEY (id_compraAbono) REFERENCES COMPRA_ABONO(id_compraAbono),
)

CREATE TABLE ALMACEN_ABONO(
	id_almaAbono int primary key identity(1,1) not null, 
	stock_almaAbono smallint not null, 
	unidadDatoComun_almaAbono int not null, 
	estado_almaAbono bit not null,
	id_abono int not null, 
	id_soc int null, 
	id_usu int null, 
	usuarioInserta_almaAbono  varchar(50) NULL,
	fechaInserta_almaAbono  datetime NOT NULL,
	usuarioModifica_almaAbono  varchar(50) NULL,
	fechaModifica_almaAbono  datetime NULL,
	usuarioElimina_almaAbono  varchar(50) NULL,
	fechaElimina_almaAbono  datetime NULL,
	CONSTRAINT fk_almaAbono_soc FOREIGN KEY (id_soc) REFERENCES SOCIEDAD(id_soc),
	CONSTRAINT fk_almaAbono_usu FOREIGN KEY (id_usu) REFERENCES USUARIO(id_usu),
	CONSTRAINT fk_almaAbono_agroqui FOREIGN KEY (id_abono) REFERENCES ABONO(id_abono),
)

CREATE TABLE MENSAJE_ERROR (
	id_tabMenError int identity (1,1) not null, 
	codigo_tabMenError varchar (300) null, 
	aplicacionGuid_tabMenError uniqueidentifier null, 
	descripcion_tabMenError varchar(150) null, 
	porDefecto_tabMenError bit null
)

insert into TABLA_MENSAJE_ERROR (
	codigo_tabMenError,
	aplicacionGuid_tabMenError,
	descripcion_tabMenError,
	porDefecto_tabMenError
) values 
(1,'2324918B-C528-4741-ACA0-7F014E7DA4C7','Solicitud inválida',1),
(2,'2324918B-C528-4741-ACA0-7F014E7DA4C7','El recurso o entidad no fue encontrado',1),
(3,'2324918B-C528-4741-ACA0-7F014E7DA4C7','El recurso o entidad no fue eliminado',1),
(4,'2324918B-C528-4741-ACA0-7F014E7DA4C7','El servicio {0} respondió con error',1),
(5,'2324918B-C528-4741-ACA0-7F014E7DA4C7','El servicio {0} no respondió',1),
(6,'2324918B-C528-4741-ACA0-7F014E7DA4C7','El codigo guid es obligatorio',0)