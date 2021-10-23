# Library

#### A library application that allows librarians to add books and user to checkout books

#### Created By: Chynna Lew and Ben Dunham

## Technologies Used

* C#
* .NET 5
* NuGet
* ASP.NET Core
* Entity Framework Core
* ASP.NET MVC Identity
* MySql
* MySql Workbench

## Description

This project was created for Epicodus bootcamp to show proficiency in Authentication with Identity. This application is for a Library, allowing the libaraian to log different books and general users to check out those books.

Authentication Features:
- Anyone can access the index and details views
- Only authenticated users can access the YourBooks view
- Only the Librarian role Create, Update, Delete views
- The buttons on the navbar, Details and Index pages change depending on authentication status

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
  - dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.0
* Create a file named "appsettings.json" in the Library directory
  - add the following code to the appsettings.json file:
  ```
  {
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=library;uid=root;pwd=[YOUR-PASSWORD-HERE];"
    }
  }
  ```
  - replace [YOUR-PASSWORD-HERE] with your unique MySql password
* Launch the MySql server:
  - In the terminal, run the command "$ mySql -uroot -p[YOUR-PASSWORD-HERE]", replacing [YOUR-PASSWORD-HERE] with your unique MySql password
* To Import the required database:
   - In the terminal, navigate to Library.Solution/Library and run the command:
    - dotnet ef database update
* To Make Changes to the Database:
  - If you would like to change the database, make changes in the proper models files, then run the following commands in the terminal navigated to Library.Solution/Library:
    - "dotnet ef migrations add YourDescriptionHere"
    - "dotnet ef database update"
* To Restore, build, and run the project:
  - Navigate to the Library.Solutions/Library folder in the command line or terminal
    - Run the command "$ dotnet restore" to restore the project dependencies
    - Run the command "$ dotnet build" to build and compile the project
    - Run the command "$ dotnet run" to build and compile the project
* To Edit Permissions:
  - Register a user on the Account/Register page
  - Navigate to http://localhost:5000/Role/Create in the browser
  - Add the roles: "Librarian" and "User"
  - Navigate to http://localhost:5000/Role/Update in the browser
  - Assign roles to users using the update form

## Known Bugs

* none at this time

### License

[MIT License](https://opensource.org/licenses/MIT)
Copyright 2021 Chynna Lew

## Support and contact details

* [Chynna Lew](github.com/chynnalew) <ChynnaLew@yahoo.com>
* [Ben Dunham](https://github.com/bendunhampdx)<bendunhampdx@gmail.com>