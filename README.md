# Refactor Notes - 2/5/2022
My coding environment is VS2019, so for me to run this project I had to uninstall and install some nuget packages.
So if you are not using VS2019 my modification may not run on your machine. Pardon me for doing that.
I tried to not spend too much time on it so there are still some places that could be refactored more.
For example, I could have added more unit tests for Service class and Repository (Data) class. 
I don't like the piece of getting order list. I know it probably could be written in a more alegent way maybe a stored proc.
But anyways, if I have to deliver the code to production this barely meets my standard. 
Thanks

# BrainWare Order List

This is a very small sample web application written in a very simplistic manner.

Grab the code and refactor it so that it meets your standard for production ready code.

There is no need to add additional functionality and you do not need to keep the existing code or project structure.

The only requirement is that it returns the list of orders and that it meets your standards!

Fork this project to your personal repo and commit all your changes to that branch. 

## Changes for Running Locally

Update the connection string in the class <project root>\Web\Infrastructure\Database.cs.

Change the AttachDbFile name to the full path of the BrainWare.mdf file (located under <project root>\Web\App_Data\).


## Original Output Example
![page image](output.GIF?raw=true)


## Setup

### Database Setup
- Start SQL Server Management Studio as Administrator
- Once connected to your local SQL Server instance
- Right click on the Database node and select Attach
- Select the file BrainWare\Web\App_Data\BrainWare.mdf

- You can also deploy the project ProjectDB to your local SQL Server instance
- Then execute in SQL Server Management Studio the file BrainWare\ProjectDB\PopulateDB.sql

### Visual Studio
- Open solution BrainWare\BrainWare.sln
- Update the database connection string in file Web\Infrastructure\Database.cs
- Set the project Web, as the start up project
- Press F5
- Expected a browser is open with the result of the first order
