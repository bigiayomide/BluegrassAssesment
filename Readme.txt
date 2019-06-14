Requirements:
1) SQL Server localDB/ Express
2) .NET Core 2.2

Instructions:

1) clone the repo from: https://gitlab.com/Innocentz/addressbook.git
2) Create an BluegrassMenuDB database on localDB/ or any sql instance.
3) Restore the test database from the BluegrassMenuDB.bak included in the source files
4) open the Bluegrass.Menu.API project and change the connection string to your database's connection.
5) Run the API locally
6) navigate to http://localhost:56452/ the app will show a swagger UI to test the API.



