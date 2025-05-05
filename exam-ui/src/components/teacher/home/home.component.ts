import {Component, inject, OnInit} from '@angular/core';
import {ScheduleModel} from '../teacher-dashboard/model/schedule.model';
import {ScheduleService} from '../teacher-dashboard/services/schedule.service';
import {DAYS} from '../teacher-dashboard/mockdatas/schedule.data';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import {interval} from 'rxjs';
import {MatFormField} from '@angular/material/form-field';
import {MatOption, MatSelect} from '@angular/material/select';
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderCellDef,
  MatHeaderRow, MatHeaderRowDef, MatRow, MatRowDef,
  MatTable
} from '@angular/material/table';
import {MatCalendar, MatDatepicker} from '@angular/material/datepicker';
import {ClassListComponent} from '../../class-list/class-list.component';
import {NgForOf, NgIf} from '@angular/common';
import {MatNativeDateModule} from '@angular/material/core';
import {SidebarComponent} from '../../shared/sidebar/sidebar.component';

@Component({
  selector: 'app-home',
  imports: [
    MatFormField,
    MatSelect,
    MatOption,
    MatTable,
    MatColumnDef,
    MatHeaderCell,
    MatCell,
    MatHeaderCellDef,
    MatCellDef,
    MatHeaderRow,
    MatRow,
    MatCalendar,
    ClassListComponent,
    MatHeaderRowDef,
    MatRowDef,
    NgForOf,
    NgIf,
    HttpClientModule,
    MatNativeDateModule,
    SidebarComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  schedules: ScheduleModel[] = [];
  currentDay: string = '';
  scheduleservice: ScheduleService = inject(ScheduleService);
  days: string[] = DAYS;
  displayedColumns: string[] = ['class','time', 'subject'];

  selectedTabIndex = 0;
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
