import { Component } from '@angular/core';
import {MatCard, MatCardContent, MatCardTitle} from '@angular/material/card';
import {timer} from 'rxjs';
import {MatRadioButton, MatRadioGroup} from '@angular/material/radio';
import {MatFormField} from '@angular/material/form-field';

@Component({
  selector: 'app-take-exam',
  imports: [
    MatCard,
    MatCardTitle,
    MatCardContent,
    MatRadioGroup,
    MatRadioButton,
    MatFormField
  ],
  templateUrl: './take-exam.component.html',
  styleUrl: './take-exam.component.scss'
})
export class TakeExamComponent {

  protected readonly timer = timer;
}
