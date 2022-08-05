# Independent Project #9: Dr. Sillystringz's Factory
<!-- ![a picture of the factory's header](Factory/wwwroot/img/header1.jpg) -->

#### Contributors: _**Claire Thorington**_

## Technologies Used

* Markdown
* HTML
* CSS
* C#
* .NET
* ASP.NET Core MVC
* Razor
* MySQL
* MySQL Workbench
* EF Core

## Description

The home page welcomes Dr. Sillystringz and displays an index of engineers and machines at his factory. He can see a list of engineers working at the factory, and for each engineer, add machines that engineer is licensed to repair. Conversely, if a machine is viewed, it has a list of engineers who are licensed to repair that machine. He should be able to add and remove both the machine or the engineer from any entry.

<!-- ![a picture of the program's schema](Factory/wwwroot/img/schema.jpg) -->

## Setup/Installation Requirements

* Clone repository to desktop
* To run this program, you will need to import the _claire_thorington.sql_ file into MySQL Workbench and create a new schema named _claire_thorington_
* Next, create an _appsettings.json_ file in the __Factory__ directory and copy in the following:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=claire_thorington;uid=root;pwd=epicodus;"
  }
}
```

* Navigate to the __Factory__ directory in your terminal and type _$ dotnet restore_ and then _$ dotnet run_ 

* A note to whoever is grading this: The .sql file I exported included both the structure and some filler data, on purpose


## Known Bugs

* None


## License

[<a href=LICENSE>MIT</a>]

Copyright (c) _2022_ _Claire Thorington_

