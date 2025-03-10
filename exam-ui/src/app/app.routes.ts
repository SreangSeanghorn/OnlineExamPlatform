import { Routes } from '@angular/router';
import { LoginComponent } from '../components/auth/login/login.component';
import { HomepageComponent } from '../components/homepage/homepage.component';
import {RegisterComponent} from '../components/auth/register/register.component';

export const routes: Routes = [
  { path: '', component: HomepageComponent },
  { path: 'login', component: LoginComponent },
  { path:'register',component:RegisterComponent},
];
