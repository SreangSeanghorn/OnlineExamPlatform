import { Component } from '@angular/core';
import {MatSidenav, MatSidenavContainer} from '@angular/material/sidenav';
import {MatToolbar} from '@angular/material/toolbar';
import {MatListItem, MatNavList} from '@angular/material/list';
import {RouterLink, RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  imports: [
    MatSidenavContainer,
    MatToolbar,
    MatNavList,
    RouterOutlet,
    MatListItem,
    RouterLink,
    MatSidenav
  ],
  styleUrl: './admin-dashboard.component.scss'
})
export class AdminDashboardComponent {

}
