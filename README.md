# Introduction 
API to register or login with Net Core 5, jwt.  
Client App repo consuming this API : https://github.com/poche1988/login-register-react-redux-client  

# Requirements 
Visual Studio or another IDE    
NET Core 5 SDK  
SQL Management  

# Details
Net Core 5 API  
Entity Framework Core  
SQL Server  

# Setup
Run scripts on project "Database" in SQL Management.  
Replace "nameofyourdb" with your own db name.  
Update connection string in API/appsettings.json
Make sure project API is set up as startup project

# Projects in solution
API - Main Project. It contains the api controllers.    
Database - Scripts to be run in SQL Management  
Domain - It contains the entities  
Models - It contains view models  
Repository - It contains the Data context neccesary for Entity Framework. If you apply the repository and the Unit of work patterns, the correspondent interfaces and classes should be here.  

