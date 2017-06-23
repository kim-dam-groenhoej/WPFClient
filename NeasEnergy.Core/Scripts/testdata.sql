use NeasEnergy;

INSERT INTO [Shop] (Name) VALUES ('Bilka');
DECLARE @ShopId INT = SCOPE_IDENTITY();

INSERT INTO [Shop] (Name) VALUES ('F�tex');
DECLARE @ShopId2 INT = SCOPE_IDENTITY();

INSERT INTO [Shop] (Name) VALUES ('Rema');
DECLARE @ShopId3 INT = SCOPE_IDENTITY();

INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Jesper S�rensen', '+45 25363897', 'kontakt@email.dk');
DECLARE @SellerId1 INT = SCOPE_IDENTITY();
INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Anders Larsen', '+45 35363897', 'kontakt2@email.dk');
DECLARE @SellerId2 INT = SCOPE_IDENTITY();
INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Peter Jensen', '+45 45363897', 'kontakt3@email.dk');
DECLARE @SellerId3 INT = SCOPE_IDENTITY();

DECLARE @districtIdOut INT;
DECLARE @districtIdOut2 INT;
EXEC InsertDistrict '�stjylland', @SellerId1, @districtIdOut out;
EXEC InsertDistrict 'S�nderjylland', @SellerId2, @districtIdOut2 out;  

INSERT INTO [DistrictShop] (ShopId, DistrictId) VALUES (@ShopId, @districtIdOut);
INSERT INTO [DistrictShop] (ShopId, DistrictId) VALUES (@ShopId2, @districtIdOut);
INSERT INTO [DistrictShop] (ShopId, DistrictId) VALUES (@ShopId3, @districtIdOut2);

INSERT INTO [DistrictSeller] (SellerId, DistrictId) VALUES (@SellerId2, @districtIdOut);
INSERT INTO [DistrictSeller] (SellerId, DistrictId) VALUES (@SellerId3, @districtIdOut);



GO