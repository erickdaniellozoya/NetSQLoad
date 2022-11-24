
# NetSQLoad
[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)

Work your queries in a SQL file instead directly in code. This package is based on the Go library of [midir99](https://github.com/midir99) called [sqload](https://github.com/midir99/sqload).

## Installation

Install NetSQLoad with: 

.NET CLI

```bash
dotnet add package NetSQLoad --version 1.1.2
```

Package Manager

```bash
dotnet add package NetSQLoad --version 1.1.2
```

PackageReference

```XML
<PackageReference Include="NetSQLoad" Version="1.1.2" />
```

Paket CLI

```bash
paket add NetSQLoad --version 1.1.2
```

Script & Interactive

```bash
#r "nuget: NetSQLoad, 1.1.2"
```

Cake Addin

```bash
#addin nuget:?package=NetSQLoad&version=1.1.2
```

Cake Tool

```bash
#tool nuget:?package=NetSQLoad&version=1.1.2
```
## Usage/Examples
Importing library:
```csharp
using NetSQLoad;
```

Now we can create an instance of the SQLoad class and pass as an argument the path of an SQL file:
```csharp
SQLoad sqload = new SQLoad(@"C:\fakepath\queries.sql");
```

Our queries.ts looks like this, each query or group of queries must be separted by commets, and comment will be the query name to use in our C# code:
```sql
-- GetActiveEmployees
SELECT * FROM Employees WHERE active = 1;

-- ChangeEmployeeStatus
UPDATE Employees SET active = {0} WHERE id = {1};
```

Now in our C# code we can use de Query function to get the query:
```csharp
string query = sqload.Query("GetActiveEmployees");
Console.WriteLine(query);
//Output: SELECT * FROM Employees WHERE active = 1;
```

Also we can pass other arguments to the Query function to fill the spaces in the query:
```csharp
string query = sqload.Query("ChangeEmployeeStatus", 0, 10);
Console.WriteLine(query);
//Output: UPDATE Employees SET active = 0 WHERE id = 10;
```

Finally if we have a directory with a lot of SQL files and we don't want to import each by each file we can instance the object to load all files:
```csharp
SQLoad sqload = new SQLoad(@"C:\fakepath\sqlqueries\");
```
This will load all files and we will be able to get all queries with the comment name as above.
## Contributing

Contributions are always welcome!

Feel free to use the code as you prefer or send your pull request. Also issues or problems using the package please let me know through [GitHub](https://github.com/erickdaniellozoya/NetSQLoad).


## Authors

- [@erickdaniellozoya](https://github.com/erickdaniellozoya)

