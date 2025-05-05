import {Component, inject, Inject, Injectable, OnInit} from '@angular/core';
import {MatToolbar} from '@angular/material/toolbar';
import {MatIcon} from '@angular/material/icon';
import {MatMenu, MatMenuItem, MatMenuTrigger} from '@angular/material/menu';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {interval} from 'rxjs';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import {MatCalendar, MatDatepicker} from '@angular/material/datepicker';
import {MatAnchor, MatButton, MatIconButton} from '@angular/material/button';
import {MatInput} from '@angular/material/input';
import {BrowserModule} from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatNativeDateModule, MatOption} from '@angular/material/core';
import {ScheduleService} from './services/schedule.service';
import {NgForOf, NgIf, NgStyle} from '@angular/common';
import {ClassService} from './services/class.service';
import {ClassModel} from './model/class.model';
import {ClassListComponent} from '../../class-list/class-list.component';
import {ScheduleModel} from './model/schedule.model';
import {MatSelect} from '@angular/material/select';
import {DAYS} from './mockdatas/schedule.data';
import {MatCard, MatCardContent, MatCardHeader, MatCardTitle} from '@angular/material/card';
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderCellDef, MatHeaderRow, MatHeaderRowDef,
  MatRow, MatRowDef,
  MatTable
} from '@angular/material/table';
import {FormsModule} from '@angular/forms';
import {MatGridList} from '@angular/material/grid-list';
import {MatTab, MatTabContent, MatTabGroup} from '@angular/material/tabs';
import {ClassworkComponent} from '../classwork/classwork.component';
import {CourseComponent} from '../course/course.component';
import {HomeComponent} from '../home/home.component';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';
import {UserProfileComponent} from '../../shared/user-profile/user-profile.component';
import {NotificationComponent} from '../../shared/notification/notification.component';
import {UserSettingsComponent} from '../../shared/user-settings/user-settings.component';
import { ToolbarComponent } from "../../shared/toolbar/toolbar.component";

@Component({
  selector: 'app-teacher-dashboard',
  imports: [
    MatToolbar,
    MatIcon,
    MatMenu,
    MatMenuTrigger,
    MatFormField,
    MatCalendar,
    MatIconButton,
    MatMenuItem,
    MatAnchor,
    HttpClientModule,
    MatNativeDateModule,
    NgForOf,
    NgIf,
    MatSelect,
    MatOption,
    MatTable,
    MatCell,
    MatColumnDef,
    MatRow,
    MatHeaderCell,
    MatHeaderRow,
    FormsModule,
    ClassListComponent,
    MatHeaderCellDef,
    MatCellDef,
    MatHeaderRowDef,
    MatRowDef,
    MatTabGroup,
    MatTab,
    MatTabContent,
    ClassworkComponent,
    CourseComponent,
    HomeComponent,
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    UserProfileComponent,
    NotificationComponent,
    UserSettingsComponent,
    ToolbarComponent
],
  templateUrl: './teacher-dashboard.component.html',
  styleUrl: './teacher-dashboard.component.scss'
})
export class TeacherDashboardComponent implements OnInit {


  schedules: ScheduleModel[] = [];
  currentDay: string = '';
  scheduleservice: ScheduleService = inject(ScheduleService);
  days: string[] = DAYS;
  displayedColumns: string[] = ['class','time', 'subject'];
  searchTerm: string = '';
  tabs = [
    { label: 'Home', link: '/teacher/home' },
    { label: 'Classwork', link: '/teacher/classwork' },
    { label: 'Course', link: '/teacher/course' }
  ];

  selectedTabIndex = 0; // 0 = Home, 1 = Classwork, 2 = Course

  switchTab(index: number) {
    this.selectedTabIndex = index;
  }

  constructor(private http: HttpClient) {
  }

  ngOnInit() {
    this.getCurrentDay();
  }

  getCurrentDay() {
    const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    const now = new Date();
    this.currentDay = days[now.getDay()];
  }



}
