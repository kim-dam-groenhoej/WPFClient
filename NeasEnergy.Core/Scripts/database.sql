USE master;
IF EXISTS(select * from sys.databases where name='TestCompany')
alter database TestCompany set single_user with rollback immediate
DROP DATABASE TestCompany;

CREATE DATABASE TestCompany;
GO

USE TestCompany;

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

CREATE TABLE [DistrictShop]
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
@isPrimary bit,
@districtId int
)
AS
BEGIN
	DECLARE @count INT = (SELECT COUNT(isPrimary) FROM [DistrictSeller] WHERE isPrimary = 1 AND DistrictId = @districtId);
	DECLARE @districtSellerId INT = (SELECT SellerId FROM [DistrictSeller] WHERE isPrimary = 1 AND DistrictId = @districtId AND sellerId = @sellerId);
	IF (@count = 1 AND @isPrimary = 0 AND @districtSellerId = @sellerId)
		RAISERROR('There must be a primary seller in district',16,1);
	ELSE IF (@count > 0)
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
	DECLARE @count INT = (SELECT COUNT(*) FROM [DistrictSeller] WHERE isPrimary = 1 AND DistrictId = @districtId);
	DECLARE @districtSellerId INT = (SELECT SellerId FROM [DistrictSeller] WHERE isPrimary = 1 AND DistrictId = @districtId AND [SellerId] = @sellerId);
	IF (@count = 1 AND @districtSellerId = @sellerId)
		RAISERROR('There must be a primary seller in district',16,1);
	ELSE IF (@count > 0)
		DELETE [DistrictSeller] WHERE [DistrictId] = @districtId AND [SellerId] = @sellerId;
END

GO
