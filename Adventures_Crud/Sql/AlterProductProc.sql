USE [AdventureWorksLT2019]
GO
/****** Object:  StoredProcedure [dbo].[GetReadOnlyProduct]    Script Date: 1/27/2022 9:42:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetReadOnlyProduct] 
	-- Add the parameters for the stored procedure here
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	

    -- Insert statements for procedure here
	SELECT * FROM [ProductView];
END
