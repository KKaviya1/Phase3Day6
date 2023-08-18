create database EmpsDb
use EmpsDb

create table Emps
(Id int primary key,
Fname nvarchar(50) not null,
Lname nvarchar(50) not null,
Designation nvarchar(50),
Salary float)

insert into Emps values (6,'Sam','Dicosta','Manager',90000.90),
(4,'Raj','Kumar','Developer',90000.90),
(3,'Ravi','Singh','Tester',90000.90),
(2,'Priya','Garg','Developer',90000.90)

insert into Emps(Id,Fname,Lname,Salary) values (5,'Raj','kiran',88000.50)
insert into Emps values (12,'Deep','Dicosta','Manager',90000.90)
insert into Emps(Id,Fname,Lname,Designation,Salary) values (13,'Raj','kiran','Manager',88000.50)
insert into Emps values (15,'Aishu','Divi','HR',76000.90)

delete from Emps where Id>=13
select * from Emps