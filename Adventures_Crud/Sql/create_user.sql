CREATE LOGIN CentraliaUser2021  
    WITH PASSWORD = 'IT410User2021';  
GO  

-- Creates a database user for the login created above.  
CREATE USER CentraliaUser2021 FOR LOGIN CentraliaUser2021;  
GO  