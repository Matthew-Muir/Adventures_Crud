SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE AddToAddress 
	
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
