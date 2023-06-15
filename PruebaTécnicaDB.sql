create database TorreDeControlAerol�neasNelmix

use TorreDeControlAerol�neasNelmix

create table Aeropuerto
(
idAeropuerto int identity(1,1) primary key not null,
nombreAeropuerto nvarchar(50),
l�miteAviones int
);

create table Avi�n
(
idAvi�n int identity(1,1) primary key not null,
nombreAvi�n nvarchar(50),
horaDeSalida datetime2,
horaDeLlegada datetime2,
aeropuertoDeSalida nvarchar(50),
aeropuertoDeLlegada nvarchar(50),
l�mitePasajeros int,
pesoL�mite int,
estadoDelAvi�n nvarchar(26),
FKaeropuerto int,
constraint FK_Avi�n_Aeropuerto_FKaeropuerto foreign key(FKaeropuerto) references Aeropuerto(idAeropuerto)
);

create table Pasajero
(
idPasajero int identity(1,1) primary key not null,
nombrePasajero nvarchar(250),
pesoPasajero int,
FKavi�n int,
constraint FK_Pasajero_Avi�n_FKAvi�n foreign key(FKavi�n) references Avi�n(idAvi�n)
);

Create index IX_Avi�n_FKaeropuerto
on Avi�n(FKaeropuerto)

Create index IX_Pasajero_FKavi�n
on Pasajero(FKavi�n)

select * from Aeropuerto