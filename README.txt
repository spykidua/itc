UI:
- Angular 16
- ng-cli
- ngx-spinner

To run UI use following commands:
  - Open beetbox-app directory.
  - Install packages by running npm i.
  - Ensure API can be reached (choose one of the options):
       (local API) Run locally deployed backend server (port 5000)
       (remote API) Update the value of api.url in environment.ts file (set the server URL)
  - Run a dev server: ng serve - if you have locally deployed backend server (port 7198)
  - Navigate to http://localhost:4200/. The app will automatically reload if you change any of the source files.

  - For simulation of server slow responce I've added setTimeOut for some components
  - Tax Band consistancy moved to separate page, managing don't implemented

API: Simple solution based on:
  - .Net 6 (LTS)
  - ASP.Net API
  - EF Core 6 with Migrations
  - MS SQL Servers

To run API use following commands:
  - Build it to restore the Nuget packages
  - Check connection string in appsetting.Local.json go to 'ITC.API\ITC.DataAccess', open terminal and run this command 'dotnet ef database update' or 'Update-Database'(if it's PM Terminal)
  - Select ITC.API project as StartUp
  - click on 'Start Debugging' button

  - Data consistency validation can be implemented using patterns like Pipeline or something like this, but I decided use plaint solution