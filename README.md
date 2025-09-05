# Account.API

[![Build](https://github.com/giudamico84/Account.API/actions/workflows/dotnet.yml/badge.svg)](https://github.com/giudamico84/Account.API/actions/workflows/dotnet.yml)

# Account Management Service

## Project Description

The **Account Management Service** is a modular and extensible solution built with C# 12 and .NET 8 for managing user accounts, authentication, and authorization.  
The project follows a clean architecture approach, separating concerns into Domain, Application, Infrastructure, and API layers.  
It provides a robust foundation for user registration, login, and role management, with a focus on maintainability and scalability.

### Main Features

- **User Registration:** Securely register new users with hashed passwords.
- **User Authentication:** Login functionality with error handling and validation.
- **Role Management:** Assign and manage user roles.
- **Error Handling:** Centralized error definitions for consistent API responses.
- **Entity Framework Core Integration:** Database access and migrations.
- **Clean Architecture:** Separation of concerns for testability and maintainability.

## Project Structure

- `Account.Domain`: Domain entities, value objects, and business rules.
- `Account.Application`: Use cases, commands, queries, and application services.
- `Account.Infrastructure`: Data access, repositories, and EF Core migrations.
- `Account.Api`: RESTful API endpoints and configuration.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or update the connection string for your DB)
- (Optional) [EF Core CLI Tools](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

### Configuration

1. Update the connection string in `Account.Api/appsettings.json` under the `ConnectionStrings` section.

"ConnectionStrings": { "DefaultConnection": "Server=YOUR_SERVER;Database=AccountDb;Trusted_Connection=True;MultipleActiveResultSets=true" }

2. Ensure the database server is running and accessible.

### Running Database Migrations

Migrations are managed using Entity Framework Core and are located in `Account.Infrastructure/Db/Migrations`.

To apply all migrations and update the database, run the following command from the solution root:

dotnet ef database update --project Account.Infrastructure --startup-project Account.Api

- `--project Account.Infrastructure`: Specifies where the migrations are located.
- `--startup-project Account.Api`: Specifies the startup project for configuration.

#### Creating a New Migration

To add a new migration after updating your models:

dotnet ef migrations add MigrationName --project Account.Infrastructure --startup-project Account.Api

Replace `MigrationName` with a descriptive name for your migration.

### Running the Application

From the solution root, run:

dotnet run --project Account.Api

The API will be available at `https://localhost:5001` (or the port specified in your launch settings).

## Contributing

Feel free to open issues or submit pull requests for improvements and bug fixes.

## License

This project is licensed under the MIT License.
