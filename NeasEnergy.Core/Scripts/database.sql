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
    [Created] DATETIME NOT NULL DEFAULT  GETDATE(), 
    [Updated] DATETIME NOT NULL DEFAULT  GETDATE()
);

CREATE TABLE [District]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Created] DATETIME NOT NULL DEFAULT  GETDATE(), 
    [Updated] DATETIME NOT NULL DEFAULT  GETDATE()
);

CREATE TABLE [ShopDistrict]
(
    [Created] DATETIME NOT NULL DEFAULT  GETDATE(), 
    [Updated] DATETIME NOT NULL DEFAULT  GETDATE(), 
	[ShopId] int NOT NULL,
	[DistrictId] int NOT NULL,
	PRIMARY KEY ( ShopId, DistrictId ),
	FOREIGN KEY ( ShopId ) REFERENCES Shop( Id ),
	FOREIGN KEY ( DistrictId ) REFERENCES District( Id )
);

CREATE TABLE [Seller]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Phone] NVARCHAR(MAX) NOT NULL, 
	[Email] NVARCHAR(MAX) NOT NULL, 
    [Created] DATETIME NOT NULL DEFAULT  GETDATE(), 
    [Updated] DATETIME NOT NULL DEFAULT  GETDATE()
)

CREATE TABLE [DistrictSeller]
(
	[Id] uniqueidentifier NOT NULL UNIQUE DEFAULT NEWID(), 
    [Created] DATETIME NOT NULL DEFAULT  GETDATE(), 
    [Updated] DATETIME NOT NULL DEFAULT  GETDATE(), 
	[SellerId] int NOT NULL,
	[DistrictId] int NOT NULL,
	[IsPrimary] bit NOT NULL DEFAULT 0,
	PRIMARY KEY ( SellerId, DistrictId ),
	FOREIGN KEY ( SellerId ) REFERENCES [Seller] ( Id ),
	FOREIGN KEY ( DistrictId ) REFERENCES [District] ( Id )
);
GO

CREATE PROCEDURE InsertDistrict
(
@name NVARCHAR(MAX),                 
@primarySellerId int,
@districtIdOut int out
)
AS
BEGIN
	INSERT INTO [District] (Name) VALUES (@name);
	SET @districtIdOut = SCOPE_IDENTITY();
	INSERT INTO [DistrictSeller] (SellerId, DistrictId, IsPrimary) VALUES (@primarySellerId, @districtIdOut, 1);
END

GO

CREATE PROCEDURE UpdateDistrictSeller
(
@sellerId int,                
@isPrimary int,
@districtId int
)
AS
BEGIN
	DECLARE @count INT = (SELECT COUNT(isPrimary) FROM [DistrictSeller] WHERE isPrimary = 1);
	IF (@count = 1 AND @isPrimary = 0)
		RAISERROR('There must be a primary seller in district',16,1);
	ELSE IF (@count > 1)
		UPDATE [DistrictSeller] SET [IsPrimary] = @isPrimary  WHERE [DistrictId] = @districtId AND [SellerId] = @sellerId;
END

GO

CREATE PROCEDURE DeleteDistrictSeller
(
@sellerId int,                
@districtId int
)
AS
BEGIN
	DECLARE @count INT = (SELECT COUNT(isPrimary) FROM [DistrictSeller] WHERE isPrimary = 1);
	IF (@count = 1)
		RAISERROR('There must be a primary seller in district',16,1);
	ELSE IF (@count > 1)
		DELETE [DistrictSeller] WHERE [DistrictId] = @districtId AND [SellerId] = @sellerId;
END

GO
