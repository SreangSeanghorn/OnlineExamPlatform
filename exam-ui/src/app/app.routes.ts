import { Routes } from '@angular/router';
import { LoginComponent } from '../components/auth/login/login.component';
import { HomepageComponent } from '../components/homepage/homepage.component';

export const routes: Routes = [
  { path: '', component: HomepageComponent },
  { path: 'login', component: LoginComponent },
];
