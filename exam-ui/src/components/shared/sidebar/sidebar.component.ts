import { Component, Input, OnInit } from '@angular/core';
import { ScheduleModel } from '../../teacher/teacher-dashboard/model/schedule.model';
import { DAYS } from '../../teacher/teacher-dashboard/mockdatas/schedule.data';
import { ScheduleService } from '../../teacher/teacher-dashboard/services/schedule.service';
import { MatFormField } from '@angular/material/form-field';
import { MatOption, MatSelect } from '@angular/material/select';
import { NgForOf, NgIf } from '@angular/common';
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderCellDef,
  MatHeaderRow, MatHeaderRowDef, MatRow, MatRowDef,
  MatTable
} from '@angular/material/table';
import { MatCalendar } from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  imports: [
    MatFormField,
    MatSelect,
    MatOption,
    NgForOf,
    MatTable,
    MatColumnDef,
    MatHeaderCell,
    MatHeaderCellDef,
    MatCell,
    MatCellDef,
    MatHeaderRow,
    MatHeaderRowDef,
    MatRowDef,
    MatRow,
    NgIf,
    MatCalendar
  ],
  providers: [provideNativeDateAdapter()],
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  @Input() schedules: ScheduleModel[] = [];
  @Input() displayedColumns: string[] = ['class', 'time', 'subject'];
  currentDay: string = '';
  days: string[] = DAYS;


  constructor(private scheduleService: ScheduleService) { }

  ngOnInit() {
    this.getCurrentDay();
    this.fetchSchedules();
  }

  getCurrentDay() {
    const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    const now = new Date();
    this.currentDay = days[now.getDay()];
  }

  fetchSchedules(): void {
    this.scheduleService.getSchedule(this.currentDay).subscribe((schedules: ScheduleModel[]) => {
      this.schedules = schedules;
      console.log('Fetched schedules:', this.schedules);
    });
  }

  onDayChange() {
    this.scheduleService.getSchedule(this.currentDay).subscribe((schedules: ScheduleModel[]) => {
      this.schedules = schedules;
    });
  }
}
