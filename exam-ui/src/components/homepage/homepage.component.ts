import { Component } from '@angular/core';
import {MatCard} from '@angular/material/card';
import {MatIcon} from '@angular/material/icon';

@Component({
  selector: 'app-homepage',
  imports: [
    MatCard,
    MatIcon
  ],
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss','src/theme.scss']
})
export class HomepageComponent {

}
