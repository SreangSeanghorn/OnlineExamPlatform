import { Component } from '@angular/core';
import {MatCard} from '@angular/material/card';
import {MatIcon} from '@angular/material/icon';
import {RouterLink, RouterModule} from '@angular/router';
import {MatAnchor, MatButton} from '@angular/material/button';
import {MatToolbar} from '@angular/material/toolbar';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {FormsModule} from '@angular/forms';
import { LoginComponent } from "../auth/login/login.component";
import { NgForOf } from '@angular/common';
import { RegisterComponent } from '../auth/register/register.component';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-homepage',
  imports: [
    MatCard,
    MatIcon,
    RouterLink,
    MatButton,
    MatToolbar,
    MatFormField,
    MatInput,
    MatAnchor,
    MatLabel,
    FormsModule,
    LoginComponent,
    RouterLink,
    RouterModule,
    NgForOf
],
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss']
})
export class HomepageComponent {
  tabs = [
    { name: 'Home', route: '/home' },
    { name: 'About', route: '/about' },
    { name: 'Register', route: null },
  ];

  username='';
  password='';
  constructor(private dialog: MatDialog) {}
  loginValidation(username:string,password:string){
    // validate login
    if (username === '' || password === ''){

    }
  }
  openRegister(event: Event): void {
    event.preventDefault(); // prevent default navigation behavior
    this.dialog.open(RegisterComponent, {
      width: '500px',
      autoFocus: false,
      disableClose: false
    });
  }
}
