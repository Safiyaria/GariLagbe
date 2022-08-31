create database garilagbe
use garilagbe

SELECT * FROM [Admin];
SELECT * FROM [Customer];
SELECT * FROM [Category];
SELECT * FROM [OrderM];

--Category Table--
CREATE TABLE [dbo].[Category]
(
	--Primary Key--
	[Category_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Category_Name] NVARCHAR(100) NOT NULL,
)

--Vehicle Table--
CREATE TABLE [dbo].[Vehicle]
(
	--Primary Key--
	[Vehicle_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	--Foreign Key--
	[Category_ID] INT NOT NULL FOREIGN KEY REFERENCES Category(Category_ID),
	[Vehicle_Name] NVARCHAR(100) NOT NULL,
	[Vehicle_LicenseNO] INT NOT NULL,
	[Vehicle_Status] VARCHAR(24) NOT NULL,
	[Vehicle_Image] Varchar(Max) NULL,
	[Vehicle_Engine] VARCHAR(50) NOT NULL,
	[Vehicle_Price] FLOAT,
)

--User Table--
CREATE TABLE [dbo].[Customer]
(
	--Primary Key--
	[Customer_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Customer_Name] NVARCHAR(100) NOT NULL,
	[Customer_Email] NVARCHAR(50) NOT NULL UNIQUE,
	[Customer_PhoneNO] NVARCHAR(50) NOT NULL,
	[Customer_Address] NVARCHAR(100) NOT NULL,
	[Customer_Password] NVARCHAR(100) NOT NULL,
)

--Contact US Table--
CREATE TABLE [dbo].[ContactUS]
(
	--Primary Key--
	[ContactUS_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[ContactUS_Name] NVARCHAR(100) NOT NULL,
	[ContactUS_PhoneNo] INT NOT NULL,
	[ContactUS_Email] NVARCHAR(50) NOT NULL,
	[ContactUS_Message] NVARCHAR(1000) NOT NULL,
)

--Order Table--
CREATE TABLE [dbo].[OrderM]
(
	--Primary Key--
	[Order_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	--Foreign Key--
	[Customer_ID] INT NOT NULL FOREIGN KEY REFERENCES Customer(Customer_ID),
	--Foreign Key--
	[Vehicle_ID] INT NOT NULL FOREIGN KEY REFERENCES Vehicle(Vehicle_ID),
	[Order_RentHour] INT,
	[Order_FromLocation] VARCHAR(200),
	[Order_ToLocation] VARCHAR(200),
	[Order_TotalPrice] FLOAT,
)

--Payment Table--
CREATE TABLE [dbo].[Payment]
(
	[Payment_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	--Foreign Key--
	[Order_ID] INT NOT NULL FOREIGN KEY REFERENCES OrderM(Order_ID),
	[Payment_Total] FLOAT,
	[Payment_Advance] FLOAT,
	[Payment_Due] FLOAT,
)

--Admin Table--
CREATE TABLE [dbo].[Admin]
(
	[Admin_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Admin_Name] NVARCHAR(100) NOT NULL,
	[Admin_Email] NVARCHAR(50) NOT NULL UNIQUE,
	[Admin_PhoneNO] NVARCHAR(50) NOT NULL,
	[Admin_Address] NVARCHAR(100) NOT NULL,
	[Admin_Password] NVARCHAR(100) NOT NULL,
	
)



CREATE TABLE [dbo].[CustomerStatus]
(
	[Status_ID] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	--Foreign Key--
	[Customer_ID] INT NOT NULL FOREIGN KEY REFERENCES Customer(Customer_ID),
	[Status_Time] VARCHAR(100),
	[Satus_Date] VARCHAR(100),
	[Status] VARCHAR(1000),
)

insert into Category ( Category_Name ) values ('car'),
('bike'),
('microbus');
select* from Category

select * from Customer;

select * from Admin