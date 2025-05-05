import { Routes } from '@angular/router';
import { LoginComponent } from '../components/auth/login/login.component';
import { HomepageComponent } from '../components/homepage/homepage.component';
import { RegisterComponent } from '../components/auth/register/register.component';
import { OverviewComponent } from '../components/admin-dashboard/overview/overview.component';
import { ManageUsersComponent } from '../components/admin-dashboard/manage-users/manage-users.component';
import { ManageExamsComponent } from '../components/exams/manage-exams/manage-exams.component';
import { ReportsComponent } from '../components/admin-dashboard/reports/reports.component';
import { AdminDashboardComponent } from '../components/admin-dashboard/admin-dashboard/admin-dashboard.component';
import { TeacherDashboardComponent } from '../components/teacher/teacher-dashboard/teacher-dashboard.component';
import { HomeComponent } from '../components/teacher/home/home.component';
import { ClassworkComponent } from '../components/teacher/classwork/classwork.component';
import { CourseComponent } from '../components/teacher/course/course.component';
import { NotificationDetailComponent } from '../components/shared/notification/notification-detail/notification-detail.component';

export const routes: Routes = [
  { path: '', component: HomepageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'admin', component: AdminDashboardComponent, children: [
      { path: 'overview', component: OverviewComponent },
      { path: 'manage-users', component: ManageUsersComponent },
      { path: 'manage-exams', component: ManageExamsComponent },
      { path: 'reports', component: ReportsComponent }
    ]
  },
  {
    path: 'teacher',  // This is the path for the teacher dashboard
    component: TeacherDashboardComponent,
    children: [
      { path: 'home', component: HomeComponent },
      { path: 'classwork', component: ClassworkComponent },
      { path: 'course', component: CourseComponent },
      { path: '', redirectTo: 'home', pathMatch: 'full' }
    ]
  },
  {
    path: 'notifications/:id', component: NotificationDetailComponent
  },
  {
    path: "notification-detail", component: NotificationDetailComponent
  }
];
