CREATE DATABASE acceso_apuestas;

USE acceso_apuestas;

CREATE TABLE Equipo
(idEquipo integer AUTO_INCREMENT PRIMARY KEY,
Nombre VARCHAR(45) not null);

CREATE TABLE Usuario
(idUsuario integer AUTO_INCREMENT PRIMARY KEY,
Nombre VARCHAR(45) not null,
Apellidos VARCHAR(45) not null,
Edad integer not null,
Email VARCHAR(45) not null);

CREATE TABLE Evento
(idEvento integer AUTO_INCREMENT PRIMARY KEY,
fechaEvento datetime,
idLocal integer not null,
idVisitante integer not null,
FOREIGN KEY(idLocal) REFERENCES Equipo(idEquipo),
FOREIGN KEY(idVisitante) REFERENCES Equipo(idEquipo));

CREATE TABLE Cuenta
(idCuenta integer AUTO_INCREMENT PRIMARY KEY,
saldo DECIMAL(10,2) not null,
nombreBanco VARCHAR(45) not null,
numTarjeta integer not null,
idUsuario integer not null,
FOREIGN KEY(idUsuario) REFERENCES Usuario(idUsuario));  

CREATE TABLE Mercado
(idMercado integer AUTO_INCREMENT PRIMARY KEY,
tipoMercado DECIMAL(10,2) not null,
cuotaOver DECIMAL(10,2) not null,
cuotaUnder DECIMAL(10,2) not null,
apuestaOver DECIMAL(10,2) not null,
apuestaUnder DECIMAL(10,2) not null,
idEvento integer not null,
FOREIGN KEY(idEvento) REFERENCES Evento(idEvento));

CREATE TABLE Apuesta
(idApuesta integer AUTO_INCREMENT PRIMARY KEY,
tipoApuesta VARCHAR(1) not null, -- A = Alta, B = Baja
cuota DECIMAL(10,2) not null,
dineroApostado DECIMAL(10,2) not null,
idMercado integer not null,
idUsuario integer not null,
FOREIGN KEY(idMercado) REFERENCES Mercado(idMercado),
FOREIGN KEY(idUsuario) REFERENCES Usuario(idUsuario));

