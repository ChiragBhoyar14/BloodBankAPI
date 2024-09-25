# BloodDonor API

## Overview

The BloodBank API is a .NET-based application designed to manage blood donor information. It provides functionality for user registration, login, searching available blood donors, and more. The API uses JWT (JSON Web Tokens) for secure authentication and supports various operations related to blood donation.

## Features

- **User Registration**: Allows new blood donors to register with the system.
- **Login**: Authenticates users and generates JWT tokens for secure access.
- **Search for Donors**: Enables searching for available blood donors based on specified criteria.
- **JWT Authentication**: Provides secure access to API endpoints using JWT tokens for authentication.

## Technologies Used

- **.NET 8**: Framework for building the API.
- **JWT (JSON Web Tokens)**: Used for secure authentication and authorization.
- **ADO.NET**: Used for database connectivity and operations.
- **Microsoft.Extensions.Configuration**: Manages application configuration.
- **Microsoft.IdentityModel.Tokens**: Handles token generation and validation.

## Architecture

The API is designed using the Three-Tier Architecture, which includes:

1. **Presentation Layer**: Handles user interaction through API endpoints.
2. **Business Logic Layer (BLL)**: Contains core business logic for processing requests and applying business rules.
3. **Data Access Layer (DAL)**: Manages data retrieval and persistence operations.

## Design Patterns

- **Repository Pattern**: Abstracts the data access layer, providing a collection-like interface for accessing domain objects.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/)

### Setup

1. **Clone the Repository**

   ```bash
   git clone https://github.com/your-username/your-repository.git
   cd your-repository