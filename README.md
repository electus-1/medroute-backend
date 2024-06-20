# MedRoute Backend

This repository contains the backend code for a Health Tourism app, MedRoute. This project was developed as part of a school assignment and the backend was solely developed by me.

## Table of Contents
- [Introduction](#introduction)
- [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
    - [Database Setup](#database-setup)
    - [Running Migrations](#running-migrations)
    - [Building the Project](#building-the-project)
    - [Launching the Application](#launching-the-application)
- [Project Structure](#project-structure)
- [Known Issues](#known-issues)
- [Future Improvements](#future-improvements)
- [Credits](#credits)
- [License](#license)

## Introduction

MedRouter is a Health Tourism app aimed at providing users with a seamless experience in managing their health tourism needs. This repository contains the backend code developed in .NET Core, which handles all the server-side logic, database interactions, and API endpoints.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

### Installation

1. Clone the repository:

    ```sh
    git clone https://github.com/electus-1/medroute-backend.git
    cd medrouter-backend
    ```

2. Install the required .NET Core packages:

    ```sh
    dotnet restore
    ```

### Database Setup

1. Create a PostgreSQL database named `medrouterdb`.

2. Update the `appsettings.json` file with your PostgreSQL connection string:

    ```json
    "ConnectionStrings": {
      "MedrouterConnection": "User ID={your_id};Password={your_password};Server=localhost;Port=5432;Database=medrouterdb;Integrated Security=true;Pooling=true;"
    }
    ```

3. Provide your JWT settings in the `appsettings.json` file:

    ```json
    "JWT": {
      "Key": "{your_key}",
      "Issuer": "CoreIdentity",
      "Audience": "CoreIdentityUser",
      "DurationInMinutes": 3600
    }
    ```

### Running Migrations

Run the following commands to apply migrations and update the database:

```sh
dotnet ef migrations add "{migration_name}" --project MedRouter.WebApi/MedRouter.WebApi.csproj --context UserDbContext
dotnet ef migrations add "{migration_name}" --project MedRouter.WebApi/MedRouter.WebApi.csproj --context ApplicationDbContext

dotnet ef database update --project MedRouter.WebApi/MedRouter.WebApi.csproj --context UserDbContext
dotnet ef database update --project MedRouter.WebApi/MedRouter.WebApi.csproj --context ApplicationDbContext
```

### Building the Project

Build the solution with Debug or Release options according to your choice:

```sh
dotnet build
```

### Launching the Application

To launch the web application from the console, use:

```sh
dotnet run --project MedRouter.WebApi/MedRouter.WebApi.csproj
```

This will start the application and you should be able to access it at the displayed port.

## Project Structure

```
MedRouter
├── MedRouter.Core
│   ├── Behaviours
│   ├── DTOs
│   ├── Entities
│   ├── Enums
│   ├── Exceptions
│   ├── Features
│   ├── IdentityData
│   ├── Interfaces
│   ├── Mappings
│   ├── Parameters
│   ├── ServiceRegistration
│   ├── Settings
│   └── Wrappers 
├── MedRouter.Infrastructure
│   ├── Contexts
│   ├── Helpers
│   ├── Repositories
│   └── Services
└── MedRouter.WebApi
    ├── Controllers
    ├── Migrations
    ├── Properties
    ├── appsettings.json
    └── Program.cs
```

## Known Issues

- Validators are not implemented, which could lead to potential validation issues.

## Future Improvements

- Implement validators for better data validation.
- Enhance error handling and logging mechanisms.
- Optimize database queries and improve performance.

## Credits

This backend project was developed by me as part of a school assignment.
