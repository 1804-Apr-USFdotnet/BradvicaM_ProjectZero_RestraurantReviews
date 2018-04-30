create database InClass;

create table Products(
ProductId int primary key, 
ProductName varchar(255),
Price varchar(255)
);

create table Customers(
CustomerId int primary key,
FirstName varchar(255),
LastName varchar(255),
CardNumber int
);

create table Orders(
OrderId int primary key,
ProductProductId int,
CustomerCustomerId int,

constraint FK_ProductId foreign key (ProductProductId) references Products(ProductId),
constraint FK_CustomerId foreign key (CustomerCustomerId) references Customers(CustomerId)

);
