import { Component } from '@angular/core';
import {MatIcon} from '@angular/material/icon';
import {MatCard} from '@angular/material/card';
import {MatIconButton} from '@angular/material/button';

@Component({
  selector: 'app-classwork',
  imports: [
    MatIcon,
    MatCard,
    MatIconButton
  ],
  templateUrl: './classwork.component.html',
  styleUrl: './classwork.component.scss'
})
export class ClassworkComponent {
  folders = [
    { name: 'Topic1: Introduction' },
    { name: 'Topic2: Getting Started' },
    { name: 'Topic3: Practice' }
  ];

  tasks = [
    {
      title: 'JAVA assignment1',
      description: 'Create first project Java Using IntelliJ',
      due: '31 June 2022 13:00'
    },
    {
      title: 'JAVA assignment1',
      description: 'Create first project Java Using IntelliJ',
      due: '31 June 2022 13:00'
    }
  ];
}
