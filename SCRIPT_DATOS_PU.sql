use master
go

Create database  DBRegistrados
go

use DBRegistrados
go

Create table  Registrados
(
    IdRegistrado  int primary key identity(1,1),
    Identificacion varchar(20),
    Nombres varchar(200),
    Apellidos varchar(200),
    NombresCompletos varchar(400)
)

/*
insert into DBRegistrados..Registrados(Identificacion, Nombres, Apellidos, NombresCompletos)
VALUES ('0919172551', 'Victor Daniel', 'Portugal Gorozabel', 'Victor Daniel Portugal Gorozabel')
insert into DBRegistrados..Registrados(Identificacion, Nombres, Apellidos, NombresCompletos)
VALUES ('0919172551001', 'CUVIC', 'S.A.S', 'CUVIC S.A.S')
insert into DBRegistrados..Registrados(Identificacion, Nombres, Apellidos, NombresCompletos)
VALUES ('0924258130', 'Marla Elina', 'Arellano Jimenez', 'Marla Elina Arellano Jimenez')
*/

select * from DBRegistrados..Registrados
