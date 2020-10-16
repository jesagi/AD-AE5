#Creamos y ponemos en uso la BD.
CREATE DATABASE PlaceMyBet;

USE PlaceMyBet;

#Creamos las tablas.
CREATE TABLE APUESTAS(
idapuesta INT NOT NULL AUTO_INCREMENT,
idmercado INT NOT NULL,
tipoapuesta VARCHAR(45) NOT NULL,
cuota DOUBLE NOT NULL,
dineroapostado DOUBLE NOT NULL,
fecha DATE NOT NULL,
refevento INT NOT NULL,
refusuario VARCHAR(45) NOT NULL,
KEY (idapuesta));

CREATE TABLE EVENTOS(
idevento INT NOT NULL AUTO_INCREMENT,
equipoLocal VARCHAR(45) NOT NULL,
equipoVisitante VARCHAR(45) NOT NULL,
refmercado INT NOT NULL,
fecha DATE NOT NULL,
KEY (idevento));

CREATE TABLE MERCADOS(
idmercado INT NOT NULL AUTO_INCREMENT,
tipoMercado DOUBLE NOT NULL,
cuotaOver DOUBLE NOT NULL,
cuotaUnder DOUBLE NOT NULL,
dineroOver DOUBLE NOT NULL,
dineroUnder DOUBLE NOT NULL,
KEY (idmercado));

CREATE TABLE USUARIOS(
email VARCHAR(45) NOT NULL,
nombre VARCHAR(45) NOT NULL,
apellidos VARCHAR(45) NOT NULL,
edad INT NOT NULL,
refcuentabancaria INT NOT NULL,
KEY (email));

CREATE TABLE CUENTASBANCARIAS(
numtarjeta INT NOT NULL,
saldo double NOT NULL,
nombrebanco VARCHAR(45) NOT NULL,
KEY (numtarjeta));

#Cambiamos las tablas para añadir foreign keys y relaciones
ALTER TABLE APUESTAS ADD FOREIGN KEY (refevento) REFERENCES EVENTOS(idevento);
ALTER TABLE APUESTAS ADD FOREIGN KEY (refusuario) REFERENCES USUARIOS(email);
ALTER TABLE APUESTAS ADD FOREIGN KEY (idmercado) REFERENCES MERCADOS(idmercado);
ALTER TABLE EVENTOS ADD FOREIGN KEY (refmercado) REFERENCES MERCADOS(idmercado);
ALTER TABLE USUARIOS ADD FOREIGN KEY (refcuentabancaria) REFERENCES CUENTASBANCARIAS(numtarjeta);

#Añadimos valores a las tablas
INSERT INTO MERCADOS VALUES (1,1.5, 1.50, 1.20, 100, 100);
INSERT INTO MERCADOS VALUES (2,2.5, 2, 1, 500, 50);
INSERT INTO EVENTOS VALUES (1,'Valencia', 'Español', 1, '2020/02/20');
INSERT INTO EVENTOS VALUES (2,'Madrid', 'Barcelona', 2, '2020/03/30');
INSERT INTO CUENTASBANCARIAS VALUES (1000, 5000, 'Bankia');
INSERT INTO CUENTASBANCARIAS VALUES (1001, 7050, 'Santander');
INSERT INTO USUARIOS VALUES ('correo1@gmail.com', 'Pepe', 'Gutierrez', 30, 1000);
INSERT INTO USUARIOS VALUES ('correo2@gmail.com', 'Juan', 'Salvador', 20, 1001);
INSERT INTO APUESTAS VALUES (1, 1, 'Under', 1.45, 50, '2020/02/19', 1, 'correo1@gmail.com');
INSERT INTO APUESTAS VALUES (2, 2, 'Over', 2.50, 100, '2020/02/20', 2, 'correo2@gmail.com');