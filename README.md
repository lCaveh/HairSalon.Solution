# _Word Counter_

#### _A C# program for Epicodus, 12.14.2018_

#### By _**Kaveh Saleminejad**_

## Description
_A hair salon website that uses a SQL database to keep track of all the specialities,stylists and clients. The user can add some stylists and choose some specialities for them. After that, add some client for each stylist. The user also can delete any client or stylist from the list or edit client's name and phone number. The user can also Delete all clients or stylists as well._


## How To use MySql

_$ Mysql -uroot -uproot -P(insert path) $ CREATE DATABASE (name of database project); $ USE (name of database project); $ CREATE TABLE categories (id serial PRIMARY KEY, name VARCHAR(255)); $ CREATE TABLE tasks (id serial PRIMARY KEY, description VARCHAR(255));_



## Setup/Installation Requirements

1. Clone this repository.
  > $ git clone https://github.com/lCaveh/HairSalon.Solution.git

  2. Start your local server using MAMP or another similar program. Adjust user information and the ports in the DBConfiguration class in HairSalon/Startup.cs if needed.Make sure to use databases in root.
  3. Navigate into the application directory using a terminal program.
  > $ cd HairSalon.Solution/HairSalon
  4. Run the program with the following command.
  > dotnet run
  5. Once it has successfully start, go to the following URL in your browser. Adjust the localhost depending on the information shown to you in the terminal.
  > http://localhost:5000/

## Support and contact details

_Contact Kaveh Saleminejad - lcaveh@gmail.com._

## Technologies Used

* - VS Code
* - C#/.Net Core 1.1
* - MySql
* - MAMP
* - Git
* - GitHub
* - CSS
* - HTML


### License

*This software is licensed under the MIT license.*

Copyright (c) 2018 **_Kaveh Saleminejad_**
