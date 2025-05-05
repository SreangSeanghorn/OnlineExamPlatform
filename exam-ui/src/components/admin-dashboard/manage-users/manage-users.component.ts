import { Component } from '@angular/core';
import {MatCard} from '@angular/material/card';
import {MatToolbar} from '@angular/material/toolbar';
import {MatButton} from '@angular/material/button';
import {MatTable} from '@angular/material/table';

@Component({
  selector: 'app-manage-users',
  imports: [
    MatCard,
    MatToolbar,
    MatButton,
    MatTable
  ],
  templateUrl: './manage-users.component.html',
  styleUrl: './manage-users.component.scss'
})
export class ManageUsersComponent {

}
