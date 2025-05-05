import { Component } from '@angular/core';
import {MatCard} from '@angular/material/card';
import {MatIcon} from '@angular/material/icon';
import {RouterLink} from '@angular/router';
import {MatAnchor, MatButton} from '@angular/material/button';
import {MatToolbar} from '@angular/material/toolbar';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {FormsModule} from '@angular/forms';

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
    FormsModule
  ],
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss','src/theme.scss']
})
export class HomepageComponent {

  username='';
  password='';
  onLogin(){

  }
  loginValidation(username:string,password:string){
    // validate login
    if (username === '' || password === ''){

    }
  }
}
