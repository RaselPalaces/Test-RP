/*

create database upd_database

use upd_database


USUARIOS
CATEGORIA_PRODUCTO
PRODUCTO
DETALLE_CARRITO
CARRITO_COMPRA

DROP TABLE USUARIOS;
DROP TABLE CATEGORIA_PRODUCTO;
DROP TABLE PRODUCTO;
DROP TABLE DETALLE_CARRITO;
DROP TABLE CARRITO_COMPRA;


*/


--/////////////////////////USUARIOS///////////////////////////////////////////

IF OBJECT_ID('USUARIOS', 'U') IS NOT NULL 
  DROP TABLE USUARIOS; 
GO

CREATE TABLE USUARIOS
(
  "ID"                          INT IDENTITY(1,1),
  "USER_NAME"                   VARCHAR(40) NOT NULL,
  "NOMBRE_COMPLETO"             VARCHAR(100) NOT NULL,
  "PASSWORD"		            VARCHAR(100) NOT NULL,
  "USUARIO_REGISTRO"            VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"				INT DEFAULT 1 NOT NULL, 
  CONSTRAINT USUARIOS_PK		PRIMARY KEY (ID)
);

--/////////////////////////CATEGORIA_PRODUCTO///////////////////////////////////////////

IF OBJECT_ID('CATEGORIA_PRODUCTO', 'U') IS NOT NULL 
  DROP TABLE CATEGORIA; 
GO

CREATE TABLE CATEGORIA_PRODUCTO
(
  "ID"								INT IDENTITY(1,1),
  "NOMBRE"							VARCHAR(100) NOT NULL,
  "USUARIO_REGISTRO"				VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"					DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"					INT DEFAULT 1 NOT NULL, 
  CONSTRAINT CATEGORIA_PRODUCTO_PK	PRIMARY KEY (ID)
);

--/////////////////////////PRODUCTO///////////////////////////////////////////

IF OBJECT_ID('PRODUCTO', 'U') IS NOT NULL 
  DROP TABLE PRODUCTO; 
GO

CREATE TABLE PRODUCTO
(
  "ID"                          INT IDENTITY(1,1),
  "NOMBRE"						VARCHAR(100) NOT NULL,
  "ID_CATEGORIA"				INT NOT NULL,
  "USUARIO_REGISTRO"            VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"				INT DEFAULT 1 NOT NULL, 
  CONSTRAINT PRODUCTO_PK		PRIMARY KEY (ID)
);

ALTER TABLE PRODUCTO
  ADD CONSTRAINT "FK_PRODUCTO_TO_CATEGORIA_PRODUCTO" 
  FOREIGN KEY(ID_CATEGORIA)
  REFERENCES CATEGORIA_PRODUCTO("ID");
  
  
--/////////////////////////CARRITO_COMPRA///////////////////////////////////////////

IF OBJECT_ID('CARRITO_COMPRA', 'U') IS NOT NULL 
  DROP TABLE CARRITO_COMPRA; 
GO

CREATE TABLE CARRITO_COMPRA
(
  "ID"                          INT IDENTITY(1,1),
  "FECHA"						DATETIME NOT NULL,
  "ID_USUARIO"					INT NOT NULL,
  "USUARIO_REGISTRO"            VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"				INT DEFAULT 1 NOT NULL, 
  CONSTRAINT CARRITO_COMPRA_PK		PRIMARY KEY (ID)
);

ALTER TABLE CARRITO_COMPRA
  ADD CONSTRAINT "FK_CARRITO_COMPRA_TO_USUARIO" 
  FOREIGN KEY("ID_USUARIO")
  REFERENCES USUARIOS("ID");


--/////////////////////////DETALLE_CARRITO///////////////////////////////////////////

IF OBJECT_ID('DETALLE_CARRITO', 'U') IS NOT NULL 
  DROP TABLE DETALLE_CARRITO; 
GO

CREATE TABLE DETALLE_CARRITO
(
  "ID"								INT IDENTITY(1,1),
  "CANTIDAD"						INT NOT NULL,
  "ID_PRODUCTO"						INT NOT NULL,
  "ID_CARRITO_COMPRA"				INT NOT NULL,
  "USUARIO_REGISTRO"				VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"					DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"					INT DEFAULT 1 NOT NULL, 

  CONSTRAINT DETALLE_CARRITO_PK		PRIMARY KEY (ID)
);

ALTER TABLE DETALLE_CARRITO
  ADD CONSTRAINT "FK_DETALLE_CARRITO_TO_PRODUCTO" 
  FOREIGN KEY("ID_PRODUCTO")
  REFERENCES PRODUCTO("ID");

ALTER TABLE DETALLE_CARRITO
  ADD CONSTRAINT "FK_DETALLE_CARRITO_TO_CARRITO_COMPRA" 
  FOREIGN KEY("ID_CARRITO_COMPRA")
  REFERENCES CARRITO_COMPRA("ID");


--/////////////////////////EQUIPO_MEDICO/////////////////////////////////////////// 

IF OBJECT_ID('EQUIPO_MEDICO', 'U') IS NOT NULL 
  DROP TABLE EQUIPO_MEDICO; 
GO

CREATE TABLE EQUIPO_MEDICO
(
  "ID"                            INT IDENTITY(1,1),
  "NOMBRE_EQUIPO"                 VARCHAR(100) NOT NULL,
  "DESCRIPCION_PROBLEMA"          VARCHAR(500),
  "ESTADO_REPARACION"             VARCHAR(50) NOT NULL,
  "USUARIO_REGISTRO"          VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"            DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"				    INT DEFAULT 1 NOT NULL,

  CONSTRAINT EQUIPO_MEDICO_PK   PRIMARY KEY (ID)
);


--/////////////////////////ORDEN_REPARACION///////////////////////////////////////////

IF OBJECT_ID('ORDEN_REPARACION', 'U') IS NOT NULL 
  DROP TABLE ORDEN_REPARACION; 
GO

CREATE TABLE ORDEN_REPARACION
(
  "ID"                                 INT IDENTITY(1,1),
  "NUMERO_ORDEN"                       VARCHAR(20) NOT NULL,
  "COSTO_ESTIMADO"                     DECIMAL(10, 2),
  "ID_EQUIPO_MEDICO"                   INT NOT NULL,
  "ID_USUARIO"					               INT NOT NULL,
  "USUARIO_REGISTRO"            VARCHAR(50) DEFAULT SYSTEM_USER NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"				      INT DEFAULT 1 NOT NULL,

  CONSTRAINT ORDEN_REPARACION_PK       PRIMARY KEY (ID),
  
);

ALTER TABLE ORDEN_REPARACION
  ADD CONSTRAINT "FK_ORDEN_REPARACION_TO_USUARIO" 
  FOREIGN KEY("ID_USUARIO")
  REFERENCES USUARIOS("ID");

ALTER TABLE ORDEN_REPARACION
  ADD CONSTRAINT "FK_ORDEN_REPARACION_TO_EQUIPO_MEDICO" 
  FOREIGN KEY("ID_EQUIPO_MEDICO")
  REFERENCES EQUIPO_MEDICO("ID");








/*


select * from USUARIOS //Backend
select * from CATEGORIA_PRODUCTO //Backend
select * from PRODUCTO //Backend
select * from CARRITO_COMPRA //Backend
select * from DETALLE_CARRITO




INSERT INTO [dbo].[USUARIOS]([USER_NAME], [NOMBRE_COMPLETO], [PASSWORD]) VALUES ('jorge.c', 'Jorge Campos', '2023') 




INSERT INTO [dbo].[CATEGORIA_PRODUCTO]([NOMBRE]) VALUES ('Limpieza') 


INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES ('Producto 1', 1) 
INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES ('Producto 2', 1) 
INSERT INTO [dbo].[PRODUCTO]([NOMBRE], [ID_CATEGORIA]) VALUES ('Producto 3', 1) 



INSERT INTO [dbo].[CARRITO_COMPRA]([FECHA], [ID_USUARIO]) VALUES (getdate(), 1) 


INSERT INTO [dbo].[DETALLE_CARRITO]([CANTIDAD], [ID_PRODUCTO], [ID_CARRITO_COMPRA]) VALUES (10, 1, 1) 
INSERT INTO [dbo].[DETALLE_CARRITO]([CANTIDAD], [ID_PRODUCTO], [ID_CARRITO_COMPRA]) VALUES (5, 2, 1) 
INSERT INTO [dbo].[DETALLE_CARRITO]([CANTIDAD], [ID_PRODUCTO], [ID_CARRITO_COMPRA]) VALUES (1, 3, 1) 



















 "USUARIO_REGISTRO" -> UsuariosRegistro



*/