/* AxaAssistanceTest Database Scripts */


/* Create Database */

CREATE DATABASE AxaAssistanceLibrary;


/* Create Tables */

CREATE TABLE Books
( Id INT PRIMARY KEY IDENTITY(1,1),
  Name NVARCHAR(200) NOT NULL,
  Author NVARCHAR(100) NOT NULL,
  Category NVARCHAR(50),
  PublicationDate DATE,
  CreationTime DATETIME default CURRENT_TIMESTAMP,
  ModificationTime DATETIME
);

CREATE TABLE Customers
( Id VARCHAR(20) PRIMARY KEY, 
  IdType VARCHAR(10) NOT NULL,
  FirstName NVARCHAR(100) NOT NULL,
  LastName NVARCHAR(100) NOT NULL,
  Cellphone VARCHAR(20) NOT NULL,
  Email NVARCHAR(60),
  Address NVARCHAR(100),
  AddressDetail NVARCHAR(150),
  ResidenceCity NVARCHAR(60),
  ResidenceCountry NVARCHAR(60),
  CreationTime DATETIME default CURRENT_TIMESTAMP,
  ModificationTime DATETIME
);

CREATE TABLE Reservation
( Id INT PRIMARY KEY IDENTITY(1,1),
  CustomerId VARCHAR(20),
  ReservationDate DATETIME,
  ReturnDate DATETIME,
  CreationTime DATETIME default CURRENT_TIMESTAMP,
  ModificationTime DATETIME,
  CONSTRAINT FK_Customer_Id FOREIGN KEY (CustomerId)
        REFERENCES [dbo].[Customers] (Id)
        ON UPDATE CASCADE
);

CREATE TABLE ReservedBooks
( Id INT PRIMARY KEY IDENTITY(1,1),
  ReservationId INT,
  BookId INT,
  CreationTime DATETIME default CURRENT_TIMESTAMP,
  ModificationTime DATETIME,
  CONSTRAINT FK_Reservation_Id FOREIGN KEY (ReservationId)
        REFERENCES [dbo].[Reservation] (Id)
        ON UPDATE CASCADE,
  
  CONSTRAINT FK_Book_Id FOREIGN KEY (BookId)
        REFERENCES [dbo].[Books] (Id)
        ON UPDATE CASCADE
);
