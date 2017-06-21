USE master;
IF EXISTS(select * from sys.databases where name='NeasEnergy')
DROP DATABASE NeasEnergy;

CREATE DATABASE NeasEnergy;
GO

USE NeasEnergy;

CREATE TABLE [Shop]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Created] DATETIME NOT NULL, 
    [Updated] DATETIME NOT NULL
);

CREATE TABLE [District]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Created] DATETIME NOT NULL DEFAULT  GETDATE(), 
    [Updated] DATETIME NOT NULL DEFAULT  GETDATE(), 
    [ShopId] INT NOT NULL,
	[DistrictSellerId] INT NOT NULL,
	FOREIGN KEY ([ShopId]) REFERENCES Shop(ID)
);

CREATE TABLE [Seller]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Phone] NVARCHAR(MAX) NOT NULL, 
	[Email] NVARCHAR(MAX) NOT NULL, 
    [Created] DATETIME NOT NULL, 
    [Updated] DATETIME NOT NULL
)

CREATE TABLE [DistrictSeller]
(
	[Id] INT NOT NULL IDENTITY, 
    [Created] DATETIME NOT NULL DEFAULT  GETDATE(), 
    [Updated] DATETIME NOT NULL DEFAULT  GETDATE(), 
	[SellerId] int NOT NULL,
	[DistrictId] int NOT NULL,
	[IsPrimary] bit NOT NULL DEFAULT 0,
	PRIMARY KEY CLUSTERED ( SellerId, DistrictId ),
	FOREIGN KEY ( SellerId ) REFERENCES [Seller] ( Id ),
	FOREIGN KEY ( DistrictId ) REFERENCES [District] ( Id )
);

/* Adding this to ensure there is a primary seller */
ALTER TABLE [District]
ADD CONSTRAINT FK_DistrictSellerId_Id FOREIGN KEY ([DistrictSellerId])
    REFERENCES Shop(id);

GO
