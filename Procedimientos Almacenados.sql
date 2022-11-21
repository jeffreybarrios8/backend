use Centro
go

------------------------------------------------------------Servicios-------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

Create Procedure sp_AgregarServicio
@NombreServicio nvarchar(70),
@Precio float,
@Duracion int
As
Begin
 Declare @FechaCreacion datetime;
 Select @FechaCreacion= GETDATE();

 If(@NombreServicio='' or @Precio='' or @Duracion='')
 Begin
  Print 'Estos campos no pueden estar vacíos'
 End
 Else
 Begin
  Insert into Servicio values (@NombreServicio,@Precio,@FechaCreacion,@Duracion)
 End
End
go

Create procedure sp_EliminarServicio
@IdServicio int
As
Begin
 Delete serv
 from Servicio serv
 Where serv.IdServicio= @IdServicio
End
go
create procedure sp_ActualizarServicio
@IdServicio int,
@NombreServicio nvarchar(70),
@Precio float,
@Duracion int
as
Begin
 Update Servicio set NombreServicio=@NombreServicio, Precio=@Precio, Duracion=@Duracion
 where IdServicio=@IdServicio
End
go

------------------------------------------------------------Clientes-------------------------------------------------
---------------------------------------------------------------------------------------------------------------------
create procedure sp_RegistrarCliente 
@PrimerNombre nvarchar(20),
@SegundoNombre nvarchar(20),
@PrimerApellido nvarchar(20),
@SegundoApellido nvarchar(20),
@Celular char(8)
as
Begin
 declare @FechaCreacion date;
 select @FechaCreacion= GETDATE();
 declare @pd as char(1)
 set @pd=(select SUBSTRING(@Celular,1,1))
 if(@PrimerNombre='' or @PrimerApellido='' or @Celular='')
 begin
  select -5004 as ErrorCode
 end
 else
 begin
  if(@pd='2' or @pd='5' or @pd='7' or @pd='8')
  begin
    Insert into Cliente (PrimerNombre, SegundoNombre, PrimerApellido,
	SegundoApellido,Celular,FechaCreacion) values (@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,@Celular,@FechaCreacion)
  end
  else
  begin
    select -5005 as ErrorCode
  end
 end
 end
 go

Create procedure sp_ListarCliente
as
Begin
 Select * from Cliente
End
go

Create procedure sp_EliminarCliente
@IdCliente int
as
Begin
 delete Cliente
 where IdCliente=@IdCliente
End
go

Create procedure sp_ActualizarCliente
@IdCliente int,
@Celular char(8)
as
Begin
 Declare @FechaCreacion date;
 select @FechaCreacion= GETDATE();
 update Cliente set Celular=@Celular, FechaCreacion=@FechaCreacion
 where IdCliente=@IdCliente
End
go


---------------------------------------Empleados----------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------
create procedure sp_RegistrarEmpleado
@PrimerNombre nvarchar(20),
@SegundoNombre nvarchar(20),
@PrimerApellido nvarchar(20),
@SegundoApellido nvarchar(20),
@Direccion nvarchar(50),
@Cedula nvarchar(14),
@Celular char(8),
@Privilegio bit,
@IdEstadoEmpleado nvarchar(30) 
as
Begin
 declare @FechaCreacion date;
 select @FechaCreacion= GETDATE();
 declare @pd as char(1)
 set @pd=(select SUBSTRING(@Celular,1,1))

 If(@PrimerNombre='' or @PrimerApellido='' or @Direccion='' or @Cedula='' or @Celular='' 
  or @IdEstadoEmpleado='')
 Begin
  Print 'Está dejando campos vacíos'
 End
 Else
 Begin
   if(@pd='2' or @pd='5' or @pd='7' or @pd='8')
   Begin
    Insert into Empleado (PrimerNombre, SegundoNombre,
	PrimerApellido,SegundoApellido, Direccion, Cedula,Celular,privilegio,
	IdEstadoEmpleado, FechaCreacion) 
	values (@PrimerNombre,@SegundoNombre,@PrimerApellido,@SegundoApellido,@Direccion,
	@Cedula,@Celular,@Privilegio,@IdEstadoEmpleado,@FechaCreacion)
   End
   Else
   Begin
    Print 'Número de celular no válido'
   End
 End
End
go
  
create procedure sp_EliminarEmpleado
@IdEmpleado int
as
Begin
 if exists (select IdEmpleado from Empleado where IdEmpleado=@IdEmpleado )
 Begin
 delete Empleado from Empleado emp
 where IdEmpleado=@IdEmpleado
 End
 else
 Begin
  print 'Empleado no existe'
 end
End
go

create procedure sp_ListarEmpleado
as
Begin
 Select e.IdEmpleado, e.PrimerNombre, e.SegundoNombre, e.PrimerApellido, e.SegundoApellido,
 e.Direccion, e.Cedula,e.Celular, e.privilegio,e.IdEstadoEmpleado, e.FechaCreacion 
 from Empleado e 
End
go

create procedure sp_ActualizarEmpleado
@IdEmpleado int,
@Direccion nvarchar(50),
@Celular char(8),
@Privilegio bit,
@IdEstadoEmpleado nvarchar(30) 
as
Begin
 update Empleado set Direccion=@Direccion, Celular=@Celular,privilegio=@Privilegio,IdEstadoEmpleado=@IdEstadoEmpleado
 where IdEmpleado=@IdEmpleado
End
go

---------------------------------------------------Reservacion-------------------------------------------
---------------------------------------------------------------------------------------------------------
create procedure sp_RegistrarReservacion 
@IdCliente int ,
@IdPago nvarchar(20) ,
@IdEstadoReservacion nvarchar(20) ,
@FechaAgendada datetime
as
Begin
 declare @FechaCreacion date;
 select @FechaCreacion= GETDATE();
 declare @Mes nvarchar(15);
 declare @Dia nvarchar(2);
 select @Mes = DATENAME(MONTH, @FechaAgendada);
 select @Dia= DATENAME(WEEKDAY, @FechaAgendada);

 if exists (select IdCliente from Cliente where IdCliente= @IdCliente)
	Begin
	 insert into Reservacion values (@IdCliente,@IdPago,@IdEstadoReservacion,@FechaCreacion, @FechaAgendada,@Mes, @Dia)
	End
	else
	Begin
	 print 'Id de referencia no existe'
	End
End
go



create procedure sp_EliminarReservacion
@IdReservacion int
as
Begin
 delete Reservacion from Reservacion res
 inner join Cliente c on c.IdCliente = res.IdCliente
 where IdReservacion = @IdReservacion
End
go

create procedure sp_ActualizarReservacion
@IdReservacion int,
@IdPago nvarchar(20),
@IdEstadoReservacion nvarchar(20)
as
Begin
 update Reservacion set IdPago=@IdPago, IdEstadoReservacion=@IdEstadoReservacion
 where IdReservacion=@IdReservacion
End
go

create procedure  ListarReservacion
as
Begin
 Select re.IdReservacion,c.IdCliente, re.IdPago, re.IdEstadoReservacion, c.PrimerNombre, c.PrimerApellido,c.Celular,
 re.FechaCreacion, re.FechaAgendada,re.Mes, re.Dia from Reservacion re
 inner join Cliente c on c.IdCliente=re.IdCliente
End
go

select getdate()
---------------------------------------------------DetalleReservacion----------------------------------
-------------------------------------------------------------------------------------------------------
select * from Empleado
select * from Servicio
select *from Reservacion
select *from DetalleReservacion
go
create procedure sp_AgregarDetalleReservacion
@IdEmpleado int,
@IdServicio int,
@IdReservacion int
as
Begin
 declare @FechaCreacion datetime;
 select @FechaCreacion = GetDate();
 if exists (select IdEmpleado from Empleado where IdEmpleado=@IdEmpleado ) and
    exists (select IdServicio from Servicio where IdServicio = @IdServicio) and
	exists (select IdReservacion from Reservacion where IdReservacion = @IdReservacion)
	Begin
	 Insert into DetalleReservacion (IdEmpleado,IdServicio,IdReservacion,
	 FechaCreacion) values (@IdEmpleado, @IdServicio, @IdReservacion,@FechaCreacion)
	End
	else
	Begin
	 Select -5004 as ErrorCode
	 return;
	End
End
go

create procedure sp_EliminarDetalleReservacion
@IdDetalleReservacion int
as
Begin
 if exists (select IdDetalleReservacion from DetalleReservacion where IdDetalleReservacion=@IdDetalleReservacion )
 begin
  delete DetalleReservacion  from DetalleReservacion dr
  inner join Servicio s on s.IdServicio=dr.IdServicio
  inner join Empleado emp on emp.IdEmpleado=dr.IdEmpleado
  inner join Reservacion res on res.IdReservacion= dr.IdServicio
  where IdDetalleReservacion=@IdDetalleReservacion
 end
 else
 begin
   Select -5004 as ErrorCode
 end
End
go

create procedure sp_ListarDetalleReservacion 
as
Begin
Select dr.IdDetalleReservacion, res.IdReservacion,c.PrimerNombre as 'NombreCliente', c.PrimerApellido as
'ApellidoCliente',emp.PrimerNombre as 'NombreEmpleado',emp.PrimerApellido as 'ApellidoEmpleado',ser.NombreServicio,
ser.Precio,ser.Duracion, c.Celular,res.IdPago, FORMAT(res.FechaCreacion,'yyyy-MM-dd') as FechaCreacion,FORMAT(res.FechaAgendada,'yyyy-MM-dd') as FechaAgendada, 
res.IdEstadoReservacion,res.Mes,res.dia
from DetalleReservacion dr 
inner join Reservacion res on res.IdReservacion=dr.IdReservacion
inner join Empleado emp on emp.IdEmpleado= dr.IdEmpleado
inner join Servicio ser on ser.IdServicio=dr.IdServicio
inner join Cliente c on c.IdCliente = res.IdCliente
where res.IdEstadoReservacion='Activa'
End
go

create procedure sp_ListarDetalleReservacionFinalizada
as
Select dr.IdDetalleReservacion, res.IdReservacion,c.PrimerNombre as 'NombreCliente', c.PrimerApellido as
'ApellidoCliente',emp.PrimerNombre as 'NombreEmpleado',emp.PrimerApellido as 'ApellidoEmpleado',ser.NombreServicio,
ser.Precio,ser.Duracion, c.Celular,res.IdPago, FORMAT(res.FechaCreacion,'yyyy-MM-dd') as FechaCreacion,
FORMAT(res.FechaAgendada,'yyyy-MM-dd') as FechaAgendada, res.IdEstadoReservacion,
datename (MONTH,res.FechaAgendada) as mes,datename (DAY,res.FechaAgendada)  as dia
from DetalleReservacion dr
inner join Reservacion res on res.IdReservacion=dr.IdReservacion
inner join Empleado emp on emp.IdEmpleado= dr.IdEmpleado
inner join Servicio ser on ser.IdServicio=dr.IdServicio
inner join Cliente c on c.IdCliente = res.IdCliente
where res.IdEstadoReservacion='Finalizada'
--------------------------------------------------RegistrarUsuario-----------------------------------------------
-----------------------------------------------------------------------------------------------------------------
go
create procedure sp_RegistrarUsuario
@Nombre nvarchar(20),
@Apellido nvarchar(20),
@Usuario nvarchar(15),
@Contraseña nvarchar(30),
@Privilegio nvarchar(10)
as
Begin
 if(@Nombre='' or @Apellido='' or @Usuario='' or @Contraseña='')
 begin
  select -5005 as ErrorCode
 end
 else
 begin
  if exists (select Usuario from Usuario where Usuario=@Usuario)
  begin
   select -5004 as ErrorCode
   print 'usuario ya existe'
  end
  else
  begin
   insert into Usuario values (@Nombre,@Apellido,@Usuario,@Contraseña,@Privilegio)
  end
 end
End
go

exec sp_RegistrarUsuario 'Jeffrey','Barrios', '4012306991002P','12345',1

go
create procedure ActualizarUsuario
@IdRegistrarUsuario int,
@Contraseña nvarchar(30)
as
Begin
 if exists (select IdRegistrarUsuario from Usuario where IdRegistrarUsuario=@IdRegistrarUsuario)
 Begin
   update Usuario set Contraseña = @Contraseña
   where IdRegistrarUsuario = @IdRegistrarUsuario
 End
 else
 Begin 
   select -5004 as ErrorCode
 End
End
go

create procedure sp_EliminarUsuario
@IdRegistrarUsuario int
as
Begin
 if exists (select IdRegistrarUsuario from Usuario where IdRegistrarUsuario=@IdRegistrarUsuario)
 Begin
  delete Usuario where 
  IdRegistrarUsuario =@IdRegistrarUsuario
 End
 else
 Begin 
   select -5004 as ErrorCode
 End
End
go

Create procedure ListarUsuario
as
begin
 select * from Usuario
end
go



---------------------------------------------------Acceder--------------------------------------------------
----------------------------------------------------------------------------------------------------------
create procedure sp_AccederUsuario (
@Usuario nvarchar(15),
@Contraseña nvarchar(30)
)
as
begin
 if exists (select IdRegistrarUsuario from Usuario where Usuario = @Usuario and Contraseña=@Contraseña)
	begin
	print 'Concedido' 
	end
	else
	begin
	 select -5005 as codigoError
	end
end
go

exec sp_AccederUsuario '400120919962008', '12345'
----------------------------------------------
