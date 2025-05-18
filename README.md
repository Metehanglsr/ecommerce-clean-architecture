# 🛒 E-Commerce Backend - Clean Architecture

This is a **modular, scalable, and maintainable** e-commerce backend project built with **ASP.NET Core 9**, following the principles of **Clean Architecture** and showcasing a variety of real-world patterns and practices.

It includes a well-structured separation of concerns, a clean domain-driven approach, and production-ready tools like **MediatR**, **Entity Framework Core**, **Generic Repository Pattern**, **CQRS**, **Pagination**, and **Dockerized MySQL** integration with **phpMyAdmin** for development and testing.

---

## 📐 Architecture Overview

The project is structured based on **Clean Architecture**, which promotes independence of frameworks, UI, databases, and external agencies:

- **Core Layer**:  
  - `Domain`: Contains pure domain entities and business rules  
  - `Application`: Houses use cases, service contracts, DTOs, and MediatR request/response models  

- **Infrastructure Layer**:  
  - `Infrastructure`: External services (e.g., file system, email)  
  - `Persistence`: Entity Framework Core configurations, DbContext, and repository implementations  

- **Presentation Layer**:  
  - `WebAPI`: Entry point of the application; contains controllers, filters, dependency injection, and middleware  

---

## 🧰 Core Features

✅ **Clean Architecture**  
✅ **CQRS Pattern** with **MediatR**  
✅ **Generic Repository Pattern**  
✅ **Entity Framework Core**  
✅ **Pagination Support**  
✅ **Dockerized MySQL + phpMyAdmin**  
✅ **Modular & Testable Design**  
🚧 **JWT Authentication** *(planned for future implementation)*

---

## 🗃️ Technologies Used

- **ASP.NET Core 9**
- **Entity Framework Core**
- **MediatR**
- **Docker & Docker Compose**
- **MySQL** (via Docker)
- **phpMyAdmin** (via Docker)

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9.0 SDK]
- [Docker Desktop]

---

### 🐳 Docker Setup for MySQL + phpMyAdmin

1. Run Docker Containers:

```bash
docker run -d --name mysql-container -e MYSQL_ROOT_PASSWORD=1234 -e MYSQL_DATABASE=ECommerceDB -v mysql_data:/var/lib/mysql  -p 3306:3306  mysql:8.0

docker run -d --name phpmyadmin-container -e PMA_HOST=mysql-container -e PMA_PORT=3306 -p 8080:80 --link mysql-container phpmyadmin/phpmyadmin
```

2. Services:

- MySQL running on localhost:3306

- **phpMyAdmin available at: http://localhost:8080**
- **Login credentials:**
    - Server: mysql
    - Username: root
    - Password: 1234

---
```
/ECommerce
│
├── Core/ # Domain models and application logic
│ ├── Domain/ # Entity definitions and domain rules
│ └── Application/ # Use cases, CQRS handlers, DTOs, interfaces
│
├── Infrastructure/ # Implementations of interfaces and external services
│ ├── Infrastructure/ # Services like file handling, emailing, etc.
│ └── Persistence/ # Entity Framework Core, DbContext, repositories
│
└── Presentation/ # WebAPI project (controllers, filters, startup config)

```
---

## 📚 CQRS & MediatR
The project applies Command and Query Responsibility Segregation (CQRS) using MediatR. Commands (write operations) and Queries (read operations) are handled through separate request/response objects to improve clarity and scalability.

- **Examples:**

- **CreateProductCommand**

- **GetAllProductsQuery**

- **Each request is handled by a dedicated handler class in the UseCases layer.**

---

## 🔐 JWT Authentication (Coming Soon)
The system is prepared for JWT-based authentication and role-based authorization. This will secure protected routes and enable user-based access control.

- **Planned Features:

  - User registration & login

  - JWT token issuance & validation

  - Role-based route protection
