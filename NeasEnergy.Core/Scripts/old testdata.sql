use NeasEnergy;

INSERT INTO [Company] (Name) VALUES ('Bilka');
DECLARE @CompanyId INT = SCOPE_IDENTITY();

INSERT INTO [Company] (Name) VALUES ('Føtex');

INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Jesper Sørensen', '+45 25363897', 'kontakt@email.dk');
DECLARE @SellerId1 INT = SCOPE_IDENTITY();
INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Anders Larsen', '+45 35363897', 'kontakt2@email.dk');
DECLARE @SellerId2 INT = SCOPE_IDENTITY();
INSERT INTO [Seller] (Name, Phone, Email) VALUES ('Peter Jensen', '+45 45363897', 'kontakt3@email.dk');
DECLARE @SellerId3 INT = SCOPE_IDENTITY();

BEGIN TRY
    BEGIN TRANSACTION 
        DECLARE @DistrictSellerId1 uniqueidentifier = NEWID();
		DECLARE @DistrictSellerId2 uniqueidentifier = NEWID();

		INSERT INTO [District] (Name, CompanyId, DistrictSellerId) VALUES ('Østjylland', @CompanyId, @DistrictSellerId1);
		DECLARE @OestJyllandId INT = SCOPE_IDENTITY();
		INSERT INTO [District] (Name, CompanyId, DistrictSellerId) VALUES ('Sønderjylland', @CompanyId, @DistrictSellerId2);
		DECLARE @SoenderJyllandId INT = SCOPE_IDENTITY();

		INSERT INTO [DistrictSeller] (Id, SellerId, DistrictId) VALUES (@DistrictSellerId1, @SellerId1, @OestJyllandId);
		DECLARE @DistrictSellerId_Scope INT = SCOPE_IDENTITY();

		INSERT INTO [DistrictSeller] (SellerId, DistrictId) VALUES (@SellerId2, @OestJyllandId);

    COMMIT
END TRY
BEGIN CATCH
	DECLARE @err_msg VARCHAR(MAX) = ERROR_MESSAGE();
	PRINT @err_msg;
    IF @@TRANCOUNT > 0
        ROLLBACK
END CATCH


GO