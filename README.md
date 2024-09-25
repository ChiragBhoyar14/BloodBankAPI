# BloodDonor API

## Overview

The BloodDonor API is a .NET-based application designed to manage blood donor information. It provides functionality for user registration, login, searching available blood donors, and more. The API uses JWT (JSON Web Tokens) for secure authentication and supports various operations related to blood donation. Caching has been implemented for the `GetState` and `GetBloodGroup` APIs to improve performance.

## Features

- **User Registration**: Allows new blood donors to register with the system.
- **Login**: Authenticates users and generates JWT tokens for secure access.
- **Search for Donors**: Enables searching for available blood donors based on specified criteria.
- **JWT Authentication**: Provides secure access to API endpoints using JWT tokens for authentication.
- **Caching**: Implemented for `GetState` and `GetBloodGroup` APIs to optimize performance by reducing database calls.

## Technologies Used

- **.NET 8**: Framework for building the API.
- **JWT (JSON Web Tokens)**: Used for secure authentication and authorization.
- **ADO.NET**: Used for database connectivity and operations.
- **Microsoft.Extensions.Caching.Memory**: Used to implement in-memory caching for various API endpoints.
- **LazyCache**: A wrapper around `MemoryCache` to provide simple, lazy-loaded caching for ASP.NET applications.
- **Microsoft.Extensions.Configuration**: Manages application configuration.
- **Microsoft.IdentityModel.Tokens**: Handles token generation and validation.

## Architecture

The API is designed using the Three-Tier Architecture, which includes:

1. **Presentation Layer**: Handles user interaction through API endpoints.
2. **Business Logic Layer (BLL)**: Contains core business logic for processing requests and applying business rules.
3. **Data Access Layer (DAL)**: Manages data retrieval and persistence operations, now enhanced with caching for optimized performance.

## Design Patterns

- **Repository Pattern**: Abstracts the data access layer, providing a collection-like interface for accessing domain objects.
- **Caching**: Reduces the load on the database by storing the results of frequently requested data, specifically for the `GetState` and `GetBloodGroup` APIs.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/)
- **NuGet Packages**:
  - `Microsoft.Extensions.Caching.Memory`
  - `LazyCache.AspNetCore`

### Setup

1. **Clone the Repository**

   ```bash
   git clone https://github.com/your-username/your-repository.git
   cd your-repository
