Candidate Management API

A simple API for managing candidates using a four-layer architecture: Core, Application, Infrastructure, and API.

Requirements:
* .NET 8.0 SDK
* Docker Desktop

Ensure Docker Desktop is running.
Clone the repository.
Navigate to the project directory.
Start the application with Docker Compose

Planned Improvements:
* CQRS and Mediator: Implement CQRS (Command Query Responsibility Segregation) along with the Mediator pattern using MediatR for a cleaner and more scalable architecture. This is currently unnecessary due to the project's limited scope but will be considered as the project grows.
* Authentication: Add authentication mechanisms to secure the API endpoints, as the current setup allows unrestricted access to all routes. This could involve using JWT (JSON Web Tokens) or OAuth for secure user authentication and authorization.
* Validation: Implement comprehensive input validation using FluentValidation or a similar library to ensure that all incoming data is properly validated and sanitized.
* Error Handling: Improve error handling by adding global exception handling middleware. This will provide consistent and informative error responses to the clients.
* Logging: Enhance logging using a structured logging framework like Serilog or NLog. This will help in better monitoring and troubleshooting by providing detailed logs of application activities.


Time Spent
Approximately 6 hours.
One day was unavailable due to work commitments.