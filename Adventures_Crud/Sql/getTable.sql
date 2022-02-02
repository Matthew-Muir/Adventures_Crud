ALTER PROCEDURE getTable
    @TableName nvarchar(MAX)
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX)
    SET @sql = N'SELECT * FROM SalesLT.' + QUOTENAME(@TableName)

PRINT @sql
EXEC sp_executesql @sql
END

