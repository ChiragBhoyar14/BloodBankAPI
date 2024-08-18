# BloodBank API

## Overview

The BloodBank API is a .NET-based application designed to manage blood donor information. It includes functionality for user registration, login, searching available blood donors, and more. This API utilizes JWT for authentication and provides endpoints for various operations related to blood donation.

## Features

- **User Registration**: Allows new blood donors to register.
- **Login**: Authenticates users and generates JWT tokens.
- **Search for Donors**: Searches for available blood donors based on criteria.
- **JWT Authentication**: Secure access to API endpoints using JWT tokens.

## Technologies Used

- **.NET 8**: Framework for building the API.
- **Entity Framework Core**: ORM for data access.
- **JWT**: JSON Web Token for authentication.
- **Microsoft.Extensions.Configuration**: Configuration management.
- **Microsoft.IdentityModel.Tokens**: Token generation and validation.

## Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or compatible database
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Setup

1. **Clone the Repository**

   ```bash
   git clone https://github.com/your-username/your-repository.git
   cd your-repository
