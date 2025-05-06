🟦 Public Pages
	1.	Home Page
	•	Welcome banner
	•	Login/Register CTA
	•	About Section
	2.	Login / Registration / Forgot Password
	•	Login with Email/Password
	•	Google Login (Social Auth)
	•	Forgot Password (email input)
	•	Register with full name, email, username, gender, school, classroom

⸻

🟩 Authenticated User Dashboard

1. Teacher Dashboard
	•	Top Navigation: Profile, Notifications, Settings, Logout
	•	Tabs: Home, Classwork, Course, Result

Home Section
	•	Weekly schedule display (calendar UI)
	•	Upcoming assignments

Classwork
	•	Create folders (topics)
	•	Assignments under topics
	•	Upload files or add YouTube links
	•	Submit/grade/comment assignments

Course
	•	File listing (tutorials or course resources)
	•	Create folders for organizing content

Result
	•	View student submissions
	•	Grade assignments (points & feedback)
	•	Submission status (on-time/late)

⸻

2. Student Dashboard
	•	Similar layout, but restricted permissions:
	•	Can view, submit classwork/assignments
	•	See grades and feedback
	•	Join class (request flow)

⸻

🟥 Admin Features (optional if you plan to expand)
	•	Manage users (create/disable/delete)
	•	Manage classes/schools
	•	Assign teacher roles

  📁 Folder & Component Mapping (Angular)
  📂 src
├── 📁 app
│   ├── 📁 auth (login, register, reset-password)
│   ├── 📁 dashboard
│   │   ├── 📁 home
│   │   ├── 📁 classwork
│   │   ├── 📁 course
│   │   ├── 📁 result
│   ├── 📁 shared (navbar, sidebar, dialog)
│   └── 📁 core (auth guards, interceptors, services)
