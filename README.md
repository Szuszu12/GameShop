## GAMEDLE - Game Shop Application
Welcome to GAMEDLE, a comprehensive game shop application designed for gaming enthusiasts. This application allows users to manage categories, clients, games, orders, and producers efficiently. Below is a guide on how to navigate and utilize the features of GAMEDLE.

# Description
GAMEDLE is a project developed for academic purposes. It's an application to streamline various aspects of managing a gaming store, including categories, clients, games, orders, and producers. The application provides a simple, user-friendly interface for viewing, adding, editing, and deleting records in each category.

# Features:
- Categories Management:
View existing categories.
Add new categories.
Edit or delete existing categories.

- Clients Management:
View client information.
Add new clients.
Edit or delete existing clients.

- Games Management:
View available games.
Add new games.
Edit or delete existing games.

- Orders Management:
View order details.
Add new orders.
Edit or delete existing orders.

- Producers Management:
View producer information.
Add new producers.
Edit or delete existing producers.

# Technologies Used
- C#
- ASP.NET Core
- WPF (Windows Presentation Foundation)
- Entity Framework Core
- AutoMapper
- HttpClient
- MS SQL Server

# Project Structure:
The project follows a structured approach with separate components for each feature:

- Controllers: Handle incoming requests and execute appropriate actions.
- DTOs (Data Transfer Objects): Define data structures for communication between client and server.
- Interfaces: Define contracts for repository classes.
- Models: Represent entities in the application.
- Repositories: Implement data access logic.
- Views: User interfaces for interacting with different entities.

# Project Components:
- Backend: The backend is developed using ASP.NET Core Web API.
- Frontend: The frontend is built using WPF (Windows Presentation Foundation) for the user interface.
- API Communication: HTTP requests are used for communication between the frontend and backend using JSON data format.
- Database: The application interacts with a database to store and retrieve information about categories, clients, games, orders, and producers.

# Additional Information:
- Technology Stack: C#, ASP.NET Core, WPF, Entity Framework Core, AutoMapper, HttpClient.
- Dependencies: AutoMapper is used for mapping DTOs to entity models and vice versa. HttpClient is used for making HTTP requests to the backend API.
- Error Handling: The application handles errors gracefully and provides appropriate error messages to the user.
- Validation: Input data is validated both on the client side and server side to ensure data integrity.
  
# Getting Started:
To get started with GAMEDLE, follow these steps:

# How to Use:
Clone the repository to your local machine.
Be sure to activate Multiple Startup Projects
Launch application
In the frontend application, go to the selected section (categories, customers, games, orders or manufacturers).
Use the provided UI to view, add, edit, or delete records as needed.
If you want to edit/delete data, click on the selected record and then click on the selected method.

```
git clone https://github.com/Szuszu12/GameShop.git
```
