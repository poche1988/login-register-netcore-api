--[ENG] on SQL MANAGEMENT Run against master - For consistency, replace "NameOfYourDb" with the name of your DB. The user created and the password will be part of the connection string in appsettings.json
--[ESP] En SQL Management correr las siguientes 3 lineas contra master. Reemplazar "NameOfYourDb" con el nombre de tu base de datos. El LOGIN creado y el password van a ser parte de la connection string en appsettings.json

CREATE LOGIN NameOfYourDbUserLogin
   WITH PASSWORD = '1password!' -- Set a better password LOL 
GO

--[ENG] Run against db created in script 001
--[ESP] Correr el siguiente db contra db creada en script 001
CREATE USER NameOfYourDbUser
        FOR LOGIN NameOfYourDbLogin
GO

EXEC sp_addrolemember db_owner, NameOfYourDbUser
GO
