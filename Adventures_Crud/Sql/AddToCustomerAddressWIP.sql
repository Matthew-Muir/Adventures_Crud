SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE AddToCustomerAddress
	@customerId int = 1,
	@addressID int = 1,
	@addressType nvarchar(50) = 'Main Office'
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @idInAddressTable int;
	select @idInAddressTable = COUNT(AddressID) from SalesLT.Address WHERE AddressID = @addressID;
	IF @idInAddressTable = 0 
	BEGIN
		EXEC AddToAddress @newID = @addressID OUTPUT;
	END

INSERT INTO [SalesLT].[CustomerAddress]
           ([CustomerID],
		   [AddressID]
           ,[AddressType])
           
     VALUES
           (@customerId,
		   @addressID,
		   @addressType)
END
GO

EXEC AddToCustomerAddress;
