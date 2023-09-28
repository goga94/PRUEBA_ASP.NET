Create database DB_Inventario

use DB_Inventario


create table Inventario(
Clave int identity, 
Nombre nvarchar(50), 
Tipo_de_Producto nvarchar(50), 
Es_Activo nvarchar(30))


insert into Inventario(Nombre,Tipo_de_Producto,Es_Activo) values
('Azucar','Abarrotes','En almacen'),
('Aceite','Abarrrotes','En almacen'),
('Arroz','Abarrotes','Pocas piezas'),
('Cloro','Cuidado del hogar', 'Agotado'),
('Detergente','Cuidado del hogar','En almacen'),
('Desodorante','Cuidado Personal','Pocas piezas'),
('Hilo Dental','Cuidado Personal','En almacen'),
('Leche','Abarrotes','Pocas piezas'),
('Mantequilla','Abarrotes','Agotado'),
('Pan Blanco','Abarrotes','En almacen')


select * from Inventario


create procedure Registrar(
@Nombre nvarchar(50),
@Tipo_de_Producto nvarchar(50),
@Es_Activo nvarchar(30)
)
As 
begin
insert into Inventario(Nombre,Tipo_de_Producto,Es_Activo)values(@Nombre,@Tipo_de_Producto,@Es_Activo)
end

create procedure Editar(
@Clave int,
@Nombre nvarchar(50),
@Tipo_de_Producto nvarchar(50),
@Es_Activo nvarchar(30)
)
As 
begin
Update Inventario set Nombre=@Nombre,Tipo_de_Producto=@Tipo_de_Producto,Es_Activo=@Es_Activo where Clave=@Clave	
end

create procedure Eliminar(
@Clave int
)
As 
begin
delete from Inventario where Clave=@Clave
end