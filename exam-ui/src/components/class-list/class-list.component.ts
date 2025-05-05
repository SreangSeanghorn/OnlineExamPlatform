import {Component, inject} from '@angular/core';
import {ClassService} from '../teacher/teacher-dashboard/services/class.service';
import {ClassModel} from '../teacher/teacher-dashboard/model/class.model';
import {NgForOf, NgIf, NgStyle} from '@angular/common';
import {
  MatCard,
  MatCardActions,
  MatCardContent,
  MatCardHeader,
  MatCardImage, MatCardSubtitle,
  MatCardTitle
} from '@angular/material/card';
import {MatButton, MatIconButton} from '@angular/material/button';

@Component({
  selector: 'app-class-list',
  imports: [
    NgStyle,
    NgIf,
    NgForOf,
    MatCard,
    MatCardContent,
    MatCardImage,
    MatCardHeader,
    MatCardActions,
    MatButton,
    MatCardTitle,
    MatCardSubtitle,
    MatIconButton
  ],
  templateUrl: './class-list.component.html',
  styleUrl: './class-list.component.scss'
})
export class ClassListComponent {
  classService:ClassService = inject(ClassService);
  classes: ClassModel[] = [];
  constructor() {
    this.classService.getClasses().subscribe((data: ClassModel[]) => {
      this.classes = data;
    });
  }

}
