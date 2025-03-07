import { Component } from '@angular/core';
import {MatCard} from '@angular/material/card';
import {MatIcon} from '@angular/material/icon';
import {RouterLink} from '@angular/router';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-homepage',
  imports: [
    MatCard,
    MatIcon,
    RouterLink,
    MatButton
  ],
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss','src/theme.scss']
})
export class HomepageComponent {

}
