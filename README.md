In the repo, I have created a CRUD application backend using the Dotnet core framework as a WebAPI and have used Dapper as the micro-ORM and have using the PostgreSQL database.

To run the project, first create a new table on PostgreSQL, using the below script,

CREATE TABLE customers (
    id SERIAL PRIMARY KEY,
    firstname VARCHAR(100) NOT NULL,
    lastname VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    dateofbirth VARCHAR(10) NOT NULL
);

Update the connection string in the appsettings.json

and run the project

