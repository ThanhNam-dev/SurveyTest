# SurveyTest Technical Testing
Technologies used:
* .NET 6 MVC
* EntityFrameworkCore
* SignalR (Real-time data receiving process)

### How to build
1. Change `ConnectionString` in `appsettings.json`
2. Execute this PM `update-database`
3. Run App and config

## Note : 
Database Restore : 
1. Change text file extension to ".bak"
2. Open SQL Server Management Studio vesion up to 18
3. Connect Local Server
4. Right-click and select "Restore Database", then choose the .bak file with the file extension that you just changed above.
5. Restore Database Success

### Features

* **Login with returnURL**: Users can log in and return to the page they were on before logging in.

* **Admin page for creating surveys**: Admins can create new surveys by navigating to the "Admin" page.

* **Authentication for surveys**: Surveys can be set to require authentication, but this feature is not yet implemented.

* **Real-time data with SignalR**: SignalR is used to reference data in real-time. Open two tabs to see the real-time updates.

* **Entity Framework Core**: The application primarily uses Entity Framework Core.

* **Bug fixes**: Basic issues with surveys have been fixed, but there are still some outstanding cases.

* **Smooth operation**: The application runs smoothly and performs well.



### Project references
User Logon

| # |   IDSV   | Password  |
|---|----------|-----------|
| 1 |   12345  | Abc@12345 |
| 1 |   44444  | Abc@12345 |
| 1 |   55555  | Abc@12345 |


### DEMO
