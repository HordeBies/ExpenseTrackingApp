# Expense Tracking API

Expense Tracking Application is a web-based application developed using ASP.NET Core 8 and C# 12. It follows the principles of clean architecture, implementing the repository pattern, unit of work and services for efficient data access and business logic. The application incorporates various technologies and libraries to provide a comprehensive expense tracking solution.

[Click Here for Demo And ScreenShots](./Demo)

## Features

The Expense Tracking Application offers the following features:

- **Expense Tracking**: Allows users to track their expenses, including the date, description, and amount.
- **Expense Reports**: Enables users to generate expense reports in Excel format using EPPlus.
- **Email Notifications**: Sends email notifications to users for various events using MimeKit and MailKit.
- **Authentication and Authorization**: Implements JWT Token-based authentication and .NET Identity for user management.
- **Background Jobs**: Utilizes HangFire for executing background jobs, such as sending daily/weekly/monthly reports in excel format.
- **Logging** (Optional): Integrates Serilog for structured logging to facilitate easier debugging and analysis.

## Technologies Used

The Expense Tracking Application utilizes the following technologies and libraries:

- ASP.NET Core 8
- C# 12
- Entity Framework Core (EF Core)
- MsSql for database
- Web API with Swagger documentation
- AutoMapper for object-to-object mapping
- EPPlus for Excel file generation
- MimeKit and MailKit for email functionality
- JWT Token for secure authentication
- .NET Identity for user management
- HangFire for background jobs
- (Optional) Serilog for structured logging

## Folder Structure

The application follows a clean architecture structure with the following folders:

- **Core**: Contains core entities and interfaces.
- **Domain**: Includes domain logic and business rules.
- **Infrastructure**: Provides data access and external service implementations.
- **Web.Api**: Represents the ASP.NET Core Web API project.

## Explore REST APIs

### User Authentication

| Method | URL                   | Description              | Return                  |
| ------ | --------------------- | ------------------------ | ----------------------- |
| POST   | api/auth/register     | Registers a new user     | Registration Result     |
| POST   | api/auth/token        | Generates a JWT Token    | User Token              |

### Transactions

| Method | URL                               | Description                                    | Return                     |
| ------ | --------------------------------- | ---------------------------------------------- | -------------------------- |
| GET    | api/transaction                    | Retrieves all transactions for the user        | Array of Transactions     |
| GET    | api/transaction/{id}               | Retrieves a transaction by ID for the user     | Single Transaction        |
| POST   | api/transaction                    | Creates a new transaction for the user         | Created Transaction       |
| PUT    | api/transaction/{id}               | Updates a transaction for the user             | Success (No content)      |
| DELETE | api/transaction/{id}               | Deletes a transaction for the user             | Success (No content)      |

### User Preferences

| Method | URL                               | Description                                    | Return                     |
| ------ | --------------------------------- | ---------------------------------------------- | -------------------------- |
| GET    | api/user/preferences              | Retrieves the preferences of the current user  | UserPreferences            |
| PUT    | api/user/preferences              | Updates the preferences of the current user    | Success (No content)       |


## Getting Started

To run the Expense Tracking Application locally, follow these steps:

1. Install Visual Studio Preview with .NET 8 and C# 12
2. Clone the repository.
3. Set up the required dependencies, including EF Core, Database Connections and migrations, and other libraries.
4. Build and run the application.

## Feedback and Contributions

Feedback and contributions are welcome! If you have any questions, suggestions, or bug reports, please reach out to us. Contributions to enhance the application are highly appreciated.

## License

The Expense Tracking Application is open-source and released under the MIT License.
