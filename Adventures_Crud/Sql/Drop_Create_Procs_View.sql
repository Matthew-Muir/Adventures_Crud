USE [AdventureWorksLT2019]
GO

DROP VIEW [dbo].[ProductView]
GO

/****** Object:  View [dbo].[ProductView]    Script Date: 2/6/2022 5:22:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ProductView] AS
SELECT * FROM SalesLT.Product;
GO

DROP PROCEDURE [dbo].[AddToAddress]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddToAddress] 

	@AddressLine1 nvarchar(60) = 'Elm Street',
	@AddressLine2 nvarchar(60) = null,
	@City nvarchar(30) = 'Centralia',
	@StateProvince nvarchar(50) = 'WA',
	@CountryRegion nvarchar(50) = 'USA',
	@PostalCode nvarchar(15) = '98531'

AS
BEGIN
	SET NOCOUNT ON;
INSERT INTO [SalesLT].[Address]
           ([AddressLine1]
           ,[AddressLine2]
           ,[City]
           ,[StateProvince]
           ,[CountryRegion]
           ,[PostalCode])
     VALUES
           (@AddressLine1
           ,@AddressLine2
           ,@City
           ,@StateProvince
           ,@CountryRegion
           ,@PostalCode)

END
GO

DROP PROCEDURE [dbo].[AddToAddressHelper]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddToAddressHelper] 

	@address01 nvarchar(60) = 'Elm Street',
	@addres02 nvarchar(60) = null,
	@city nvarchar(30) = 'Centralia',
	@state nvarchar(50) = 'WA',
	@country nvarchar(50) = 'USA',
	@zip nvarchar(15) = '98531',
	@newID int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
INSERT INTO [SalesLT].[Address]
           ([AddressLine1]
           ,[AddressLine2]
           ,[City]
           ,[StateProvince]
           ,[CountryRegion]
           ,[PostalCode])
     VALUES
           (@address01
           ,@addres02
           ,@city
           ,@state
           ,@country
           ,@zip)
SET @newID = SCOPE_IDENTITY();
END
GO

DROP PROCEDURE [dbo].[AddToCustomer]
GO

/****** Object:  StoredProcedure [dbo].[AddToCustomer]    Script Date: 2/6/2022 5:12:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddToCustomer] 
	-- Add the parameters for the stored procedure here
	@CustomerID int = 1,
	@NameStyle [dbo].[NameStyle] = 0,
	@Title nvarchar(8) = null,
	@FirstName nvarchar(50) = 'lola',
	@MiddleName nvarchar(50) = null,
	@LastName nvarchar(50) = 'bola',
	@Suffix nvarchar(10) = null,
	@CompanyName nvarchar(128) = null,
	@SalesPerson nvarchar(256) = null,
	@EmailAddress nvarchar(50) = null,
	@Phone nvarchar(25) = null,
	@PasswordHash varchar(128) = 'abcdefg123',
	@PasswordSalt varchar(10) = '1q2w3e4r'
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [SalesLT].[Customer]
           ([NameStyle]
           ,[Title]
           ,[FirstName]
           ,[MiddleName]
           ,[LastName]
           ,[Suffix]
           ,[CompanyName]
           ,[SalesPerson]
           ,[EmailAddress]
           ,[Phone]
           ,[PasswordHash]
           ,[PasswordSalt])
     VALUES
           (@NameStyle
           ,@Title
           ,@FirstName
           ,@MiddleName
           ,@LastName
           ,@Suffix
           ,@CompanyName
           ,@SalesPerson
           ,@EmailAddress
           ,@Phone
           ,@PasswordHash
           ,@PasswordSalt)

END
GO

DROP PROCEDURE [dbo].[AddToCustomerAddress]
GO

/****** Object:  StoredProcedure [dbo].[AddToCustomerAddress]    Script Date: 2/6/2022 5:12:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddToCustomerAddress]
	@CustomerID int = 1,
	@AddressID int = 1,
	@AddressType nvarchar(50) = 'Main Office'
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @CustomerExists int;
	DECLARE @AddressExists int;

	SELECT @CustomerExists = COUNT(CustomerID) FROM SalesLT.Customer WHERE CustomerID = @CustomerID;
	SELECT @AddressExists = COUNT(AddressID) FROM SalesLT.Address WHERE AddressID = @AddressID;

	IF @CustomerExists > 0
	BEGIN
		IF @AddressExists > 0
		BEGIN
			INSERT INTO [SalesLT].[CustomerAddress]
					   ([CustomerID],
					   [AddressID]
					   ,[AddressType])
           
				 VALUES
					   (@CustomerID,
					   @AddressID,
					   @AddressType)
END
END
END
GO

DROP PROCEDURE [dbo].[DeleteFromAddress]
GO

/****** Object:  StoredProcedure [dbo].[DeleteFromAddress]    Script Date: 2/6/2022 5:13:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteFromAddress] 
		@AddressID int = 1
	AS
BEGIN
	DECLARE @CustomerID int;
	SELECT @CustomerID = CustomerID from SalesLT.CustomerAddress WHERE AddressID = @AddressID;
	SET NOCOUNT ON;
	EXECUTE DeleteFromCustomerAddress @CustomerID = @CustomerID;
    -- Insert statements for procedure here
	DELETE FROM SalesLT.Address
	WHERE AddressID = @AddressID;
END
GO

DROP PROCEDURE [dbo].[DeleteFromCustomer]
GO

/****** Object:  StoredProcedure [dbo].[DeleteFromCustomer]    Script Date: 2/6/2022 5:13:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
CREATE PROCEDURE [dbo].[DeleteFromCustomer] 
	-- Add the parameters for the stored procedure here
	@CustomerID int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	EXEC DeleteFromCustomerAddress @CustomerID = @CustomerID;
	DELETE FROM [SalesLT].[Customer]
	WHERE CustomerID = @CustomerID;
END
GO

DROP PROCEDURE [dbo].[DeleteFromCustomerAddress]
GO

/****** Object:  StoredProcedure [dbo].[DeleteFromCustomerAddress]    Script Date: 2/6/2022 5:14:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteFromCustomerAddress] 
	-- Add the parameters for the stored procedure here
	@CustomerID int = 1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
		DELETE FROM [SalesLT].[CustomerAddress]
      WHERE CustomerID = @CustomerID;
END
GO


DROP PROCEDURE [dbo].[EditAddress]
GO

/****** Object:  StoredProcedure [dbo].[EditAddress]    Script Date: 2/6/2022 5:14:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditAddress]
	@AddressID int = 1,
	@AddressLine1 nvarchar(60) = NULL,
	@AddressLine2 nvarchar(60) = NULL,
	@City nvarchar(30) = NULL,
	@StateProvince nvarchar(50) = NULL,
	@CountryRegion nvarchar(50) = NULL,
	@PostalCode nvarchar(15) = NULL
AS
BEGIN

	SET NOCOUNT ON;
		IF @AddressLine1 IS NULL SELECT @AddressLine1 = AddressLine1 FROM SalesLT.Address WHERE AddressID = @AddressID;
		IF @AddressLine2 IS NULL SELECT @AddressLine2 = AddressLine2 FROM SalesLT.Address WHERE AddressID = @AddressID;
		IF @City IS NULL SELECT @City = City FROM SalesLT.Address WHERE AddressID = @AddressID;
		IF @StateProvince IS NULL SELECT @StateProvince = StateProvince FROM SalesLT.Address WHERE AddressID = @AddressID;
		IF @CountryRegion IS NULL SELECT @CountryRegion = CountryRegion FROM SalesLT.Address WHERE AddressID = @AddressID;
		IF @PostalCode IS NULL SELECT @PostalCode = PostalCode FROM SalesLT.Address WHERE AddressID = @AddressID;
		DECLARE @ModifiedDate DATE;
		SELECT @ModifiedDate = GETDATE();

		
		UPDATE [SalesLT].[Address]
		SET 
			AddressLine1 = @AddressLine1,
			AddressLine2 = @AddressLine2,
			City = @City,
			StateProvince = @StateProvince,
			CountryRegion = @CountryRegion,
			PostalCode = @PostalCode,
			ModifiedDate = @ModifiedDate
			WHERE AddressID = @AddressID;
END
GO

DROP PROCEDURE [dbo].[EditCustomer]
GO

/****** Object:  StoredProcedure [dbo].[EditCustomer]    Script Date: 2/6/2022 5:15:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[EditCustomer]
	-- Add the parameters for the stored procedure here
	@CustomerID int = 1,
	@NameStyle int = NULL,
	@Title nvarchar(8) = NULL,
	@FirstName nvarchar(50) = NULL,
	@MiddleName nvarchar(50) = NULL,
	@LastName nvarchar(50) = NULL,
	@Suffix nvarchar(10) = NULL,
	@CompanyName nvarchar(128) = NULL,
	@SalesPerson nvarchar(256) = NULL,
	@EmailAddress nvarchar(50) = NULL,
	@Phone nvarchar(25) = NULL


AS
BEGIN

	SET NOCOUNT ON;
	IF @NameStyle IS NULL SELECT @NameStyle = NameStyle FROM SalesLT.Customer WHERE CustomerID = @CustomerID;
	IF @Title IS NULL SELECT @Title = Title FROM SalesLT.Customer WHERE CustomerID = @CustomerID;
	IF @FirstName IS NULL SELECT @FirstName = FirstName From SalesLT.Customer WHERE CustomerID = @CustomerID;
    IF @MiddleName IS NULL SELECT @MiddleName = MiddleName FROM SalesLT.Customer WHERE CustomerID = @CustomerID;
	IF @LastName IS NULL SELECT @LastName = LastName FROM SalesLT.Customer WHERE CustomerID = @CustomerID;
	IF @Suffix IS NULL SELECT @Suffix = Suffix FROM SalesLT.Customer WHERE CustomerID = @CustomerID;
	IF @CompanyName IS NULL SELECT @CompanyName = CompanyName FROM SalesLT.Customer WHERE CustomerID = @CustomerID;
	IF @SalesPerson IS NULL SELECT @SalesPerson = SalesPerson FROM SalesLT.Customer WHERE CustomerID = @CustomerID;
	IF @EmailAddress IS NULL SELECT @EmailAddress = EmailAddress FROM SalesLT.Customer WHERE CustomerID = @CustomerID;
	IF @Phone IS NULL SELECT @Phone = Phone FROM SalesLT.Customer WHERE CustomerID = @CustomerID;
	DECLARE @ModifiedDate DATE;
	SELECT @ModifiedDate = GETDATE();
	
	-- Insert statements for procedure here
	UPDATE [SalesLT].[Customer]
	SET Title = @Title,
		FirstName = @FirstName,
		MiddleName = @MiddleName,
		LastName = @LastName,
		Suffix = @Suffix,
		CompanyName = @CompanyName,
		SalesPerson = @SalesPerson,
		EmailAddress = @EmailAddress,
		Phone = @Phone,
		ModifiedDate = @ModifiedDate
		WHERE CustomerID = @CustomerID;
END
GO


DROP PROCEDURE [dbo].[EditCustomerAddress]
GO

/****** Object:  StoredProcedure [dbo].[EditCustomerAddress]    Script Date: 2/6/2022 5:16:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditCustomerAddress]
	@CustomerID int = 1,
	@AddressID int = NULL,
	@AddressType nvarchar(50) = NULL

AS
BEGIN
	IF @AddressID IS NULL SELECT @AddressID = AddressID FROM SalesLT.CustomerAddress WHERE CustomerID = @CustomerID;
	IF @AddressType IS NULL SELECT @AddressType = AddressType FROM SalesLT.CustomerAddress WHERE CustomerID = @CustomerID;
	DECLARE @AddressIDCheck int;
	SELECT @AddressIDCheck = COUNT(AddressID) FROM SalesLT.Address WHERE AddressID = @AddressID;
	IF @AddressIDCheck < 1 SELECT @AddressID = AddressID FROM SalesLT.CustomerAddress WHERE CustomerID = @CustomerID;
	DECLARE @DateModified DATE;
	SELECT @DateModified = GETDATE();
	SET NOCOUNT ON;

    UPDATE [SalesLT].[CustomerAddress]
   SET 
	  AddressID = @AddressID,
      AddressType = @AddressType,
	  ModifiedDate = @DateModified
	WHERE CustomerID = @CustomerID;

END
GO

DROP PROCEDURE [dbo].[GetTableAddress]
GO

/****** Object:  StoredProcedure [dbo].[GetTableAddress]    Script Date: 2/6/2022 5:16:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTableAddress] 

AS
BEGIN

	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT AddressID,AddressLine1,AddressLine2,City,StateProvince,CountryRegion,PostalCode,rowguid,ModifiedDate  FROM SalesLT.Address;
END
GO

DROP PROCEDURE [dbo].[GetTableCustomer]
GO

/****** Object:  StoredProcedure [dbo].[GetTableCustomer]    Script Date: 2/6/2022 5:17:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTableCustomer] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CustomerID, NameStyle, Title, FirstName, MiddleName,LastName,Suffix,CompanyName,SalesPerson,EmailAddress,Phone,PasswordHash,PasswordSalt,rowguid,ModifiedDate FROM SalesLT.Customer;
END
GO

DROP PROCEDURE [dbo].[GetTableCustomerAddress]
GO

/****** Object:  StoredProcedure [dbo].[GetTableCustomerAddress]    Script Date: 2/6/2022 5:17:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTableCustomerAddress]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CustomerID,AddressID,AddressType,rowguid,ModifiedDate FROM SalesLT.CustomerAddress;
END
GO

DROP PROCEDURE [dbo].[GetTableProduct]
GO

/****** Object:  StoredProcedure [dbo].[GetTableProduct]    Script Date: 2/6/2022 5:17:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTableProduct] 
	-- Add the parameters for the stored procedure here
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

    -- Insert statements for procedure here
	SELECT DISTINCT ProductID, [Name], ProductNumber, Color, StandardCost, ListPrice,Size,[Weight],ProductCategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,ThumbNailPhoto,ThumbnailPhotoFileName,rowguid,ModifiedDate  FROM [ProductView];
END
GO

DROP PROCEDURE [dbo].[GetTableProductCategory]
GO

/****** Object:  StoredProcedure [dbo].[GetTableProductCategory]    Script Date: 2/6/2022 5:18:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetTableProductCategory]
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT ProductCategoryID,ParentProductCategoryID,[Name],rowguid,ModifiedDate  FROM SalesLT.ProductCategory;
END
GO

DROP PROCEDURE [dbo].[GetTableProductDescription]
GO

/****** Object:  StoredProcedure [dbo].[GetTableProductDescription]    Script Date: 2/6/2022 5:18:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetTableProductDescription]
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM SalesLT.ProductDescription;
END
GO

DROP PROCEDURE [dbo].[GetTableProductModel]
GO

/****** Object:  StoredProcedure [dbo].[GetTableProductModel]    Script Date: 2/6/2022 5:19:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetTableProductModel]
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT ProductModelID,[Name],CatalogDescription,rowguid,ModifiedDate FROM SalesLT.ProductModel;
END
GO

DROP PROCEDURE [dbo].[GetTableProductModelProductDescription]
GO

/****** Object:  StoredProcedure [dbo].[GetTableProductModelProductDescription]    Script Date: 2/6/2022 5:19:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetTableProductModelProductDescription]
	
AS
BEGIN
	SET NOCOUNT ON;
	SELECT ProductModelID,ProductDescriptionID,Culture,rowguid,ModifiedDate FROM SalesLT.ProductModelProductDescription;
END
GO

GRANT EXECUTE ON SCHEMA::dbo
	TO CentraliaUser2021;
GO
