#Creamos y ponemos en uso la BD.
CREATE DATABASE PlaceMyBet;

USE PlaceMyBet;

#Creamos las tablas.
CREATE TABLE Apuestas(
IdApuestas INT NOT NULL,
Mercado DOUBLE NOT NULL,
TipoApuesta DOUBLE NOT NULL,
Cuota DOUBLE NOT NULL,
DineroApostado DOUBLE NOT NULL,
Fecha DATE NOT NULL,
Evento INT NOT NULL,
Usuario VARCHAR(45) NOT NULL,
KEY (IdApuestas));

CREATE TABLE Evento(
IdEvento INT NOT NULL,
EquipoLocal VARCHAR(45) NOT NULL,
EquipoVisitante VARCHAR(45) NOT NULL,
Mercado INT NOT NULL,
Fecha DATE NOT NULL,
KEY (IdEvento));

CREATE TABLE Mercados(
IdMercado INT NOT NULL,
TipoMercado DOUBLE NOT NULL,
CuotaOver DOUBLE NOT NULL,
CuotaUnder DOUBLE NOT NULL,
DineroOver DOUBLE NOT NULL,
DineroUnder DOUBLE NOT NULL,
KEY (IdMercado));

CREATE TABLE Usuarios(
Email VARCHAR(45) NOT NULL,
Nombre VARCHAR(45) NOT NULL,
Apellidos VARCHAR(45) NOT NULL,
Edad INT NOT NULL,
CuentaBancaria INT NOT NULL,
KEY (Email));

CREATE TABLE CuentaBancaria(
NumTarjeta INT NOT NULL,
Saldo double NOT NULL,
NombreBanco VARCHAR(45) NOT NULL,
KEY (NumTarjeta));

#Cambiamos las tablas para añadir foreign keys y relaciones
ALTER TABLE Apuestas ADD FOREIGN KEY (Evento) REFERENCES Evento(IdEvento);
ALTER TABLE Apuestas ADD FOREIGN KEY (Usuario) REFERENCES Usuarios(Email);
ALTER TABLE Evento ADD FOREIGN KEY (Mercado) REFERENCES Mercados(IdMercado);
ALTER TABLE Usuarios ADD FOREIGN KEY (CuentaBancaria) REFERENCES CuentaBancaria(NumTarjeta);

#Añadimos valores a las tablas
INSERT INTO mercados VALUES (1,1.5, 1.50, 1.20, 100, 100);
INSERT INTO mercados VALUES (2,2.5, 2, 1, 500, 50);
INSERT INTO evento VALUES (1,'Valencia', 'Español', 1, '2020/02/20');
INSERT INTO evento VALUES (2,'Madrid', 'Barcelona', 2, '2020/03/30');
INSERT INTO cuentabancaria VALUES (1000, 5000, 'Bankia');
INSERT INTO cuentabancaria VALUES (1001, 7050, 'Santander');
INSERT INTO usuarios VALUES ('correo1@gmail.com', 'Pepe', 'Gutierrez', 30, 1000);
INSERT INTO usuarios VALUES ('correo2@gmail.com', 'Juan', 'Salvador', 20, 1001);
INSERT INTO Apuestas VALUES (1, 1.5, 'Under', 1.45, 50, '2020/02/19', 1, 'correo1@gmail.com');
INSERT INTO Apuestas VALUES (2, 3.5, 'Over', 2.50, 100, '2020/02/20', 2, 'correo2@gmail.com');