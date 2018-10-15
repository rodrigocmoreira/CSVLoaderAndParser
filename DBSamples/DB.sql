create database _shop_task
go

use _shop_task
go

create table theBigStorage(
RecordId bigint identity (1,1),
ShopCode varchar(3) not null,
ItemId int not null,
ItemName varchar(50) not null,
PricePerItem decimal(10,2) not null,
CountOfIems int not null,
TotalPrice decimal (10,2) not null,
TransactionDate datetime not null
) on [primary]
go