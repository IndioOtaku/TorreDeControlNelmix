create database TorreDeControlAerolíneasNelmix

use TorreDeControlAerolíneasNelmix

create table Aeropuerto
(
idAeropuerto int identity(1,1) primary key not null,
nombreAeropuerto nvarchar(50),
límiteAviones int
);

create table Avión
(
idAvión int identity(1,1) primary key not null,
nombreAvión nvarchar(50),
horaDeSalida datetime2,
horaDeLlegada datetime2,
aeropuertoDeSalida nvarchar(50),
aeropuertoDeLlegada nvarchar(50),
límitePasajeros int,
pesoLímite int,
estadoDelAvión nvarchar(26),
FKaeropuerto int,
constraint FK_Avión_Aeropuerto_FKaeropuerto foreign key(FKaeropuerto) references Aeropuerto(idAeropuerto)
);

create table Pasajero
(
idPasajero int identity(1,1) primary key not null,
nombrePasajero nvarchar(250),
pesoPasajero int,
FKavión int,
constraint FK_Pasajero_Avión_FKAvión foreign key(FKavión) references Avión(idAvión)
);

Create index IX_Avión_FKaeropuerto
on Avión(FKaeropuerto)

Create index IX_Pasajero_FKavión
on Pasajero(FKavión)

select * from Aeropuerto