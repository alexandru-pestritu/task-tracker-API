# Task Tracker API
A RESTful API built with ASP.NET Core, providing backend support for the [TaskTracker](https://github.com/alexandru-pestritu/task-tracker) web application. TaskTracker API utilizes MongoDB as its database system, ensuring reliable and efficient data storage for your task management needs.

## Features
- **RESTful API**: Provides endpoints for task management operations such as adding, editing, and deleting tasks.
- **MongoDB Integration**: Utilizes MongoDB for data storage, ensuring scalability and flexibility.
- **ASP.NET Core Framework**: Built with ASP.NET Core for high-performance and cross-platform compatibility.
- **Swagger Documentation**: Includes Swagger documentation for easy API exploration and testing.

## Getting Started
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/alexandru-pestritu/task-tracker-API.
   ```
2. **Install Dependencies**: Ensure you have .NET Core SDK installed. Navigate to the project directory and run ```dotnet restore``` to install all necessary dependencies.
3. **Set Up MongoDB**: Ensure MongoDB is installed and running locally or configure connection strings accordingly.
4. **Run the Application**: Use ```dotnet run``` to run the API locally. The API will be accessible at ```http://localhost:5000/```.
5. **Explore API Endpoints**: Visit ```http://localhost:5000/swagger``` to explore the API endpoints using Swagger documentation.
