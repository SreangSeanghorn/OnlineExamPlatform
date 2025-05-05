
📘 Exam Management System

A cloud-ready, scalable Exam Management System built with microservices architecture, following Domain-Driven Design (DDD) and Clean Architecture principles. This system enables user authentication, exam creation, question management, submission, grading, and real-time notifications — with an Angular-based frontend and secure, decoupled backend services.

⸻

📦 Tech Stack

🔧 Backend Services
	•	.NET 8, ASP.NET Core Web API
	•	CQRS + MediatR pattern
	•	PostgreSQL, MongoDB
	•	Kafka  for event-driven communication
	•	JWT & OAuth2 authentication
	•	Docker & Docker Compose
	•	MassTransit (for Kafka/RabbitMQ abstraction)

🎨 Frontend
	•	Angular 16+
	•	Angular Material
	•	RxJS
	•	JWT Auth with route guards

⸻

🧱 Project Structure

📂 ExamManagementSystem
│
├── 📂 Services                # Microservices
│   ├── 📂 IdentityService        # Auth, user management, role/permissions
│   ├── 📂 ExamService            # Exams, schedules, assignments
│   ├── 📂 QuestionService        # Questions, topics, formats
│   ├── 📂 SubmissionService      # Answer submissions, validations
│   ├── 📂 ResultService          # Grading, results, stats
│   ├── 📂 NotificationService    # Real-time/user notifications
│
├── 📂 Shared                 # Shared libraries, DTOs, base classes
├── 📂 API Gateway            # Central gateway, routing, request aggregation
├── 📂 Frontend               # Angular frontend project
├── 📂 Infrastructure         # Kafka, DB setup, authentication logic
├── 📂 Docker                 # Dockerfiles and docker-compose.yml



⸻

✨ Features
	•	✅ User registration and login (JWT or OAuth2)
	•	✅ Role-based access and permission assignment
	•	✅ Exam creation with scheduling and topic categorization
	•	✅ Dynamic question authoring with multiple formats
	•	✅ Real-time notifications (exam reminders, result alerts)
	•	✅ Grading and result reporting
	•	✅ Modular microservices with decoupled responsibilities
	•	✅ Reusable shared libraries and events
	•	✅ Fully dockerized for deployment and scaling

⸻

🚀 Getting Started

Prerequisites
	•	.NET 8 SDK
	•	Node.js
	•	Angular CLI
	•	Docker

Clone the Repository

git clone https://github.com/SreangSeanghorn/OnlineExamPlatform.git
cd Examination

Run with Docker Compose

docker-compose up --build

This will:
	•	Start all backend services
	•	Spin up PostgreSQL/MongoDB/Kafka containers
	•	Serve the Angular frontend
	•	Route requests via the API Gateway

⸻

🔐 Authentication
	•	JWT for stateless authentication
	•	OAuth2/OpenID Connect (e.g., Auth0/Google) support
	•	Claims-based authorization with support for scopes and permissions

⸻

📨 Communication
	•	Kafka event bus for inter-service messaging
	•	MassTransit integration to abstract messaging layer

⸻

📈 Future Enhancements
	•	Admin dashboard analytics
	•	Exam auto-proctoring integration
	•	Full CI/CD using GitHub Actions
	•	Multi-language support
	•	Mobile-first responsive UI

⸻

🧑‍💻 Author

Seanghorn Sreang – @seanghorn-sreang
.NET Full Stack Developer | Microservices | DDD | Angular

