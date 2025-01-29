# Digital Wallet API

## Overview
The Digital Wallet API is a RESTful service designed to manage digital wallets and financial transactions. It provides functionalities for user authentication, wallet management, and transaction processing. This API is built using C# with .NET Core and utilizes PostgreSQL as the relational database.

## Features
- User Authentication with JWT
- Create and manage user accounts
- Check wallet balance
- Add funds to wallets
- Transfer funds between users
- List transfers with optional date filtering

## Technologies Used
- C# with .NET Core
- PostgreSQL for the database
- Entity Framework Core for data access
- Swagger for API documentation and testing

## Getting Started

### Prerequisites
- .NET SDK (latest version)
- PostgreSQL database server
- An IDE or text editor (e.g., Visual Studio Code)

### Setup
1. Clone the repository:
   ```
   git clone https://github.com/yourusername/DigitalWalletAPI.git
   cd DigitalWalletAPI
   ```

2. Update the `appsettings.json` file with your PostgreSQL connection string.

3. Run the database migrations:
   ```
   dotnet ef database update
   ```

4. Seed the database with initial data:
   ```
   dotnet run
   ```

### Running the Application
To run the application, use the following command:
```
dotnet run
```

### Accessing the API
Once the application is running, you can access the API at `http://localhost:5000`. Swagger UI can be accessed at `http://localhost:5000/swagger` for testing the API endpoints.

## API Endpoints
- **Authentication**
  - POST `/api/auth/login` - Login and receive a JWT token.

- **User Management**
  - POST `/api/users` - Create a new user.
  - GET `/api/users/{id}` - Retrieve user details.

- **Wallet Management**
  - GET `/api/wallets/{userId}/balance` - Check wallet balance.
  - POST `/api/wallets/{userId}/add` - Add funds to wallet.

- **Transfer Management**
  - POST `/api/transfers` - Create a transfer between users.
  - GET `/api/transfers/{userId}` - List transfers for a user with optional date filtering.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any suggestions or improvements.

## License
This project is licensed under the MIT License. See the LICENSE file for details.