import { Component } from '@angular/core';
import {MatCard, MatCardTitle} from '@angular/material/card';

@Component({
  selector: 'app-exam-list',
  imports: [
    MatCard,
    MatCardTitle
  ],
  templateUrl: './exam-list.component.html',
  styleUrl: './exam-list.component.scss'
})
export class ExamListComponent {

}
