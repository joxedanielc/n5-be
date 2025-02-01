# **N5 Backend - Permission Management API**

The **N5 Backend API** is a **.NET Core Web API** designed to manage user permissions efficiently. This system enables users to **request, update, and retrieve permissions** while integrating **Elasticsearch** for real-time logging and indexing of permission data.

## **🚀 Getting Started**

### **Prerequisites**

To run this application, ensure that you have the following dependencies installed:

- **.NET 9.0** (or the latest compatible version)
- **SQL Server** (or any other compatible relational database)
- **Elasticsearch** (for indexing permission data)

### **Installation Steps**

1. Clone the repository and navigate to the backend folder:
   ```bash
   git clone https://github.com/joxedanielc/n5-be
   cd n5-be
   ```
2. Restore the necessary dependencies:
   ```bash
   dotnet restore
   ```

## **▶ Running the API**

To launch the API locally, execute the following command:

```bash
dotnet clean
dotnet build
dotnet run
```

By default, the API is hosted at **`http://localhost:5155`**.

## **📌 Available API Endpoints**

| Method | Endpoint                    | Description                            |
| ------ | --------------------------- | -------------------------------------- |
| `POST` | `/api/Permisos/request`     | Creates a new permission request       |
| `PUT`  | `/api/Permisos/modify/{id}` | Updates an existing permission         |
| `GET`  | `/api/Permisos`             | Retrieves all permissions              |
| `GET`  | `/api/Permisos/types`       | Fetches all available permission types |

## **🔗 Database Configuration**

To configure the database connection, update the **`appsettings.Development.json`** file with the appropriate credentials:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=N5_DB;User Id=sa;Password=yourpassword;"
}
```

Apply database migrations and update the schema by running:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## **📌 Running Elasticsearch**

**Elasticsearch** is required for indexing permission data. If not already installed, follow the instructions below.

### **Install Elasticsearch Manually (Without Docker)**

#### **For MacOS/Linux:**

```bash
brew install elasticsearch
brew services start elasticsearch
```

#### **For Windows:**

1. Download Elasticsearch from [Elastic's official website](https://www.elastic.co/downloads/elasticsearch)
2. Extract the files and navigate to the `bin` directory
3. Run `elasticsearch.bat`

### **Verify Elasticsearch is Running**

To confirm Elasticsearch is running, visit:

```
http://localhost:9200
```

A successful response will return **JSON-formatted cluster information**.

## **🛠 Backend Testing**

This project includes a dedicated testing project to validate backend functionality. To run tests, navigate to the test project directory and execute:

```
cd n5-be.Tests
dotnet clean
dotnet build
dotnet test
```

This will execute all unit and integration tests to ensure system reliability.

## **🎨 Technology Stack**

This API follows a structured architecture and is built using:

- **.NET Core 9** – Backend framework
- **Entity Framework Core** – ORM for database management
- **SQL Server** – Primary relational database
- **Elasticsearch** – Real-time indexing and search capabilities
- **CQRS & Repository Pattern** – Best practices for clean, scalable architecture

## **📜 License**

This project is licensed under the **MIT License**.
