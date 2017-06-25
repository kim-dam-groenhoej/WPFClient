use NeasEnergy;

INSERT INTO [Shop] (Name) VALUES ('Bilka');
DECLARE @ShopId INT = SCOPE_IDENTITY();

INSERT INTO [Shop] (Name) VALUES ('Føtex');
DECLARE @ShopId2 INT = SCOPE_IDENTITY();

INSERT INTO [Shop] (Name) VALUES ('Rema');
DECLARE @ShopId3 INT = SCOPE_IDENTITY();

INSERT INTO [Shop] (Name) VALUES ('Super Rema');
DECLARE @ShopId4 INT = SCOPE_IDENTITY();

INSERT INTO [Shop] (Name) VALUES ('Ultimate Rema');
DECLARE @ShopId5 INT = SCOPE_IDENTITY();

INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Jesper Sørensen', '+45 25363897', 'kontakt@email.dk');
DECLARE @SellerId1 INT = SCOPE_IDENTITY();
INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Anders Larsen', '+45 35363897', 'kontakt2@email.dk');
DECLARE @SellerId2 INT = SCOPE_IDENTITY();
INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Peter Jensen', '+45 45363897', 'kontakt3@email.dk');
DECLARE @SellerId3 INT = SCOPE_IDENTITY();
INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Kasper Jensen', '+45 55363897', 'kontakt4@email.dk');
DECLARE @SellerId4 INT = SCOPE_IDENTITY();
INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Per Jensen', '+45 65363897', 'kontakt5@email.dk');
DECLARE @SellerId5 INT = SCOPE_IDENTITY();
INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Morten Jensen', '+45 75363897', 'kontakt6@email.dk');
DECLARE @SellerId6 INT = SCOPE_IDENTITY();

DECLARE @districtIdOut INT;
DECLARE @districtIdOut2 INT;
EXEC InsertDistrict 'Østjylland', @SellerId1, @districtIdOut out;
EXEC InsertDistrict 'Sønderjylland', @SellerId2, @districtIdOut2 out;  

INSERT INTO [DistrictShop] (ShopId, DistrictId) VALUES (@ShopId, @districtIdOut);
INSERT INTO [DistrictShop] (ShopId, DistrictId) VALUES (@ShopId2, @districtIdOut);
INSERT INTO [DistrictShop] (ShopId, DistrictId) VALUES (@ShopId3, @districtIdOut2);
INSERT INTO [DistrictShop] (ShopId, DistrictId) VALUES (@ShopId4, @districtIdOut2);
INSERT INTO [DistrictShop] (ShopId, DistrictId) VALUES (@ShopId5, @districtIdOut2);

INSERT INTO [DistrictSeller] (SellerId, DistrictId) VALUES (@SellerId2, @districtIdOut);
INSERT INTO [DistrictSeller] (SellerId, DistrictId) VALUES (@SellerId3, @districtIdOut);
INSERT INTO [DistrictSeller] (SellerId, DistrictId) VALUES (@SellerId4, @districtIdOut2);
INSERT INTO [DistrictSeller] (SellerId, DistrictId) VALUES (@SellerId5, @districtIdOut2);


GO