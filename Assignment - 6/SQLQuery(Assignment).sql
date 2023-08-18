create database ProductInventoryDB
use ProductInventoryDB

create table Products(
ProductId int primary key,
ProductName nvarchar(50)not null,
Price decimal(7,2),
Quantity int,
MfDate date,
ExpDate date)

insert into Products values (1,'Face wash',150,2,'06/05/2022','10/05/2024'),
(3,'Soap',80,4,'11/08/2019','05/05/2023'),
(6,'Wash Basin',4800,1,'12/01/2016','07/05/2024'),
(2,'Perfume',400,3,'10/02/2022','05/08/2024'),
(14,'Sunscreen',699,2,'05/06/2020','07/02/2023')

select * from Products