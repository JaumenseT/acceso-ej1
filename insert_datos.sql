USE acceso_apuestas;

INSERT INTO Equipo (Nombre) VALUES 
('Valencia'),
('Espanyol');

INSERT INTO Evento (fechaEvento, idLocal, idVisitante) VALUES (NOW(), 1, 2);

INSERT INTO Mercado (tipoMercado, cuotaOver, cuotaUnder, apuestaOver, apuestaUnder, idEvento) VALUES 
(1.5, 1.43, 2.85, 100, 50, 1),
(2.5, 1.9, 1.9, 100, 100, 1),
(3.5, 2.85, 1.43, 50, 100, 1);

INSERT INTO Usuario (Nombre, Apellidos, Edad, Email) VALUES ('Jaume', 'Navarro', 19, 'acceso@gmail.com');

INSERT INTO Cuenta (saldo, nombreBanco, numTarjeta, idUsuario) VALUES (200, 'FloridaBank', 859632, 1);

INSERT INTO Apuesta (tipoApuesta, cuota, dineroApostado, idMercado, idUsuario) VALUES
('A', 1.43, 150, 1, 1),
('B', 1.9, 100, 2, 1); 