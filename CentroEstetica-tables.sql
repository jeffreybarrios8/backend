Create database CentroEstetica
use CentroEstetica
go
create table Cliente (
IdCliente int identity (1,1) primary key,
PrimerNombre nvarchar(20) not null,
SegundoNombre nvarchar(20),
PrimerApellido nvarchar(20) not null,
SegundoApellido nvarchar(20),
Celular char(8),
FechaCreacion date
)
go

create table Empleado (
IdEmpleado int identity (1,1) primary key,
PrimerNombre nvarchar(20) not null,
SegundoNombre nvarchar(20),
PrimerApellido nvarchar(20) not null,
SegundoApellido nvarchar(20),
Direccion nvarchar(50) not null,
Cedula nvarchar(14) not null,
Celular char(8),
privilegio bit not null,
IdEstadoEmpleado nvarchar(30),
FechaCreacion date
)
go
create table Servicio(
IdServicio int identity (1,1) primary key,
NombreServicio nvarchar(50) not null,
Precio float not null,
FechaCreacion date,
Duracion int
)
go
create table Reservacion(
IdReservacion int identity (1,1) primary key,
IdCliente int foreign key references Cliente (IdCliente),
IdPago nvarchar(20),
IdEstadoReservacion nvarchar(20),
FechaCreacion date,
FechaAgendada datetime,
Mes nvarchar(15),
Dia nvarchar(2)
)

create table DetalleReservacion(
IdDetalleReservacion int identity (1,1) primary key,
IdEmpleado int foreign key references Empleado (IdEmpleado),
IdServicio int foreign key references Servicio (IdServicio),
IdReservacion int foreign key references Reservacion(IdReservacion) ,
FechaCreacion datetime
)

Create table Usuario(
IdRegistrarUsuario  int identity (1,1) primary key,
Nombre nvarchar(20) not null,
Apellido nvarchar(20) not null,
Usuario nvarchar(15) not null,
Contraseña nvarchar(30) not null,
Privilegio nvarchar(10)
)

create table Acceder(
IdAcceder  int identity (1,1) primary key,
Usuario nvarchar(15) not null,
Contraseña nvarchar(30) not null
)
go

insert into Servicio values
('Limpieza facial profunda				   ' ,30	,getDate(), 60  ),
('Limpieza espalda						    ',30	,getdate(), 60),
('Limpieza facial adolescente				',15	,getdate(), 60),
('Dermoabrasión								',30	,getdate(), 60),
('Facil Spa+ BBGLOW							',55	,getdate(), 60),
('Fibroblast									',35,getdate(), 60),
('Dermapen									',45	,getdate(), 60),
('Peeling contorno ojos						',25	,getdate(), 60),
('Hidratación facial							',20,getdate(), 60),
('Facial con lonización						',20	,getdate(), 60),
('Facial con ultransonido					',20	,getdate(), 60),
('Aclaramiento en glúteos					',25	,getdate(), 60),
('Aclaramiento axilas						',20	,getdate(), 60),
('Avlaramiento entrepiernas					',20	,getdate(), 60),
('Botox full face							',300	,getdate(), 60),
('Baby botox									',300,getdate(),120),
('Lifting facial con botox full face			',00,getdate(), 120),
('Relleno con ácido hialorónico por área		',35,getdate(), 120),
('Masaje relajante cuerpo completo			',28	,getdate(), 120),
('Masaje desconcracturante					',35	,getdate(), 60),
('Masaje piernas cansadas,					',35	,getdate(), 60),
('Masaje relajante, hidratación facial		',35	,getdate(), 60),
('Peeling Quimico							',35	,getdate(), 60),
('Limpieza facial profunda					',30	,getdate(), 60),
('Limpieza espalda							',30	,getdate(), 60),
('Limpieza facial adolesce					',15	,getdate(), 60),
('Dermoabrasión								',30	,getdate(), 60),
('Facil Spa+ BBGLOW							',55	,getdate(), 60),
('Fibroblast									',35,getdate(), 60),
('Dermapen									',45	,getdate(), 60),
('Peeling contorno ojos						',25	,getdate(), 60),
('Hidratación facial							',20,getdate(), 60),
('Facial con lonización						',20	,getdate(), 60),
('Facial con ultransonido					',20	,getdate(), 60),
('Aclaramiento en glúteos					',25	,getdate(), 60),
('Aclaramiento axilas						',20	,getdate(), 60),
('Avlaramiento entrepierna					',20	,getdate(), 60), 
('Botox full face	      					',300	,getdate(), 60),
('Baby botox	          						',300,getdate(),20),
('Lifting facial con botox					',500	,getdate(), 120),
('Relleno con ácido hialor					',35	,getdate(), 120),
('Masaje relajante cuerpo 					',28	,getdate(), 60),
('Masaje desconcracturante					',35	,getdate(), 60),
('Masaje piernas cansadas 					',35	,getdate(), 60),
('Masaje relajante, hidrat					',35	,getdate(), 60),
('Peeling Quimico							',35	,getdate(), 60)
