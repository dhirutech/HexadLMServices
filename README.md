# HexadLMServices
Library Management Services with .Net Core 3.1

### Prerequisite 
.Net Core 3.1<br />
PostgreSQL 12.2<br />

### Setup Project
git clone https://github.com/dhirutech/HexadLMServices.git

### execute sql schemas to restore PostgreSQL DB(hdb)
Create a database name "hdb"<br />
Execute the sql scripts(avaiable inside project folder) to apply schema changes<br />
Replace entity framework connection string pointing to PostgreSQL server

### restore dotnet nuget pakages
dotnet restore

### run project
dotnet run

### test project
dotnet test
