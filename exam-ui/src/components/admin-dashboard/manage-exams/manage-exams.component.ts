import { Component } from '@angular/core';
import {MatCard} from '@angular/material/card';
import {MatToolbar} from '@angular/material/toolbar';
import {MatButton} from '@angular/material/button';
import {MatList, MatListItem} from '@angular/material/list';

@Component({
  selector: 'app-manage-exams',
  imports: [
    MatCard,
    MatToolbar,
    MatButton,
    MatList,
    MatListItem
  ],
  templateUrl: './manage-exams.component.html',
  styleUrl: './manage-exams.component.scss'
})
export class ManageExamsComponent {

}
