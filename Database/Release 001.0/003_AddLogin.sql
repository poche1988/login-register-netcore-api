--run against master
CREATE LOGIN EarthMeUserLogin
   WITH PASSWORD = '1password!'  
GO

--run against EarthMe db
CREATE USER EarthMeUser
        FOR LOGIN EarthMeUserLogin
GO

EXEC sp_addrolemember db_owner, EarthMeUser
GO
