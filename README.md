
# NetSQLoad
[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
Work your queries in a SQL file instead directly in code.

## Installation

Install NetSQLoad with: 

.NET CLI

```bash
dotnet add package NetSQLoad --version 1.0.0
```

Package Manager

```bash
dotnet add package NetSQLoad --version 1.0.0
```

PackageReference

```XML
<PackageReference Include="NetSQLoad" Version="1.0.0" />
```

Paket CLI

```bash
paket add NetSQLoad --version 1.0.0
```

Script & Interactive

```bash
#r "nuget: NetSQLoad, 1.0.0"
```

Cake Addin

```bash
#addin nuget:?package=NetSQLoad&version=1.0.0
```

Cake Tool

```bash
#tool nuget:?package=NetSQLoad&version=1.0.0
```
## Usage/Examples
Importing library.
```csharp
using NetSQLoad;
```

Now we can create an instance of the SQLoad class and pass as an argument the path of an SQL file.
```csharp
SQLoad sqload = new SQLoad(@"C:\fakepath\queries.sql");
```

Our queries.ts looks like this, each query or group of queries must be separted by commets, and comment will be the query name to use in our C# code.
```sql
-- GetActiveEmployees
SELECT * FROM Employees WHERE active = 1;

-- ChangeEmployeeStatus
UPDATE Employees SET active = {0} WHERE id = {1};
```

Now in our C# code we can use de Query function to get teh query.
```csharp
string query = sqload.Query("GetActiveEmployees");
Console.WriteLine(query);
//Output: SELECT * FROM Employees WHERE active = 1;
```
## Authors

- [@erickdaniellozoya](https://github.com/erickdaniellozoya)

