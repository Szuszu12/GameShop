## GAMEDLE - Game Shop Application
Welcome to GAMEDLE, a comprehensive game shop application designed for gaming enthusiasts. This application allows users to manage categories, clients, games, orders, and producers efficiently. Below is a guide on how to navigate and utilize the features of GAMEDLE.

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

# Project Structure:
The project follows a structured approach with separate components for each feature:

Controllers: Handle incoming requests and execute appropriate actions.
DTOs (Data Transfer Objects): Define data structures for communication between client and server.
Interfaces: Define contracts for repository classes.
Models: Represent entities in the application.
Repositories: Implement data access logic.
Views: User interfaces for interacting with different entities.

# How to Use:
Clone the repository to your local machine.
Set up the backend API by running the appropriate server application.
Open the frontend application and navigate to the desired section (categories, clients, games, orders, or producers).
Use the provided UI to view, add, edit, or delete records as needed.

# Project Components:
Backend: The backend is developed using ASP.NET Core Web API.
Frontend: The frontend is built using WPF (Windows Presentation Foundation) for the user interface.
API Communication: HTTP requests are used for communication between the frontend and backend using JSON data format.
Database: The application interacts with a database to store and retrieve information about categories, clients, games, orders, and producers.

# Additional Information:
Technology Stack: C#, ASP.NET Core, WPF, Entity Framework Core, AutoMapper, HttpClient.
Dependencies: AutoMapper is used for mapping DTOs to entity models and vice versa. HttpClient is used for making HTTP requests to the backend API.
Error Handling: The application handles errors gracefully and provides appropriate error messages to the user.
Validation: Input data is validated both on the client side and server side to ensure data integrity.
Security: The application follows security best practices to prevent common vulnerabilities such as SQL injection and cross-site scripting (XSS).
Getting Started:
To get started with GAMEDLE, follow these steps:

## Usage
Clone the repository to your local machine.
Set up the backend server application and ensure it's running.
Launch the frontend application and start exploring the features.
Refer to the documentation and comments in the codebase for more detailed information about each component.

```bash
git clone https://github.com/Szuszu12/GameShop.git
