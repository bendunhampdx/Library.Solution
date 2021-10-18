# Project name

#### short description

#### Created By: Chynna Lew

## Technologies Used

* C#
* .NET 5
* NuGet
* ASP.NET Core
* Entity Framework Core
* MySql
* MySql Workbench

## Description

description here

## Setup and Usage Instructions

### Technology Requirements

* Download and install [.NET 5](https://dotnet.microsoft.com/download/dotnet/5.0)
* Download and install a code text editor. Ex: [VS Code](https://code.visualstudio.com/)
* Download, install, and complete setup for [MySql Community Server](https://dev.mysql.com/downloads/file/?id=484914) and [MySql Workbench](https://dev.mysql.com/downloads/file/?id=484391).

### Installation

* Clone [this](https://github.com/chynnalew/Library.Solution) repository, or download and open the Zip on your local machine
* Open the Library.Solutions folder in your preferred text editor
* To install required packages, navigate to Library.Solutions/Library in the terminal and type the following commands:
  - dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0
  - dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2
  - dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0
  - dotnet tool install --global dotnet-ef --version 3.0.0
* Create a file named "appsettings.json" in the Library directory
  - add the following code to the appsettings.json file:
  ```
  {
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=database_name;uid=root;pwd=[YOUR-PASSWORD-HERE];"
    }
  }.
  ```
  - replace [YOUR-PASSWORD-HERE] with your unique MySql password
* Launch the MySql server:
  - In the terminal, run the command "$ mySql -uroot -p[YOUR-PASSWORD-HERE]", replacing [YOUR-PASSWORD-HERE] with your unique MySql password
* To Import the required database:
  - Open MySql Workbench
  - Select your preferred server(default is root)
  - In the "Navigator > Administration" window, select "Data Import/ Restore"
  - In "Import Options", select "Import From Self-Contained File"
  - Navigate to "Library.Solutions/database_name.sql" in the search input
  - Under "Default Schema to be Imported to" select the "New" button
  - Enter "database_name" and click "OK"
  - Navigate to the "Import Progress" tab and click "Start Import" in the bottom right corner of the window
  - Reopen the "Navigator>Schemas" tab, Right click and select "refresh all" to see the imported database
* To Restore, build, and run the project:
  - Navigate to the Library.Solutions/Library folder in the command line or terminal
    - Run the command "$ dotnet restore" to restore the project dependencies
    - Run the command "$ dotnet build" to build and compile the project
    - Run the command "$ dotnet run" to build and compile the project

## Known Bugs

* none at this time

### License

[MIT License](https://opensource.org/licenses/MIT)
Copyright 2021 Chynna Lew

## Support and contact details

* [Chynna Lew](github.com/chynnalew) 
* <ChynnaLew@yahoo.com>