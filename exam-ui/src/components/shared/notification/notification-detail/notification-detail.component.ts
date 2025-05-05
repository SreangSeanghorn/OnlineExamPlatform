import { Component, inject, OnInit, Injector, Type } from '@angular/core';
import { NotificationDetailService } from './notification-detail.service';
import { NotificationModel } from '../notification.model';
import { ComponentType } from '@angular/cdk/portal';
import { AssignmentDueNotificationComponent } from '../types/assignment-due-notification/assignment-due-notification.component';
import { tabsData } from '../../constants/tabs.data';
import { ToolbarComponent } from '../../toolbar/toolbar.component';
import { SidebarComponent } from '../../sidebar/sidebar.component';
import { formatDistanceToNow } from 'date-fns';
import { NgComponentOutlet, NgIf, NgSwitch, NgSwitchCase } from '@angular/common';
import { ClassEnrollmentNotificationComponent } from '../types/class-enrollment-notification/class-enrollment-notification.component';

@Component({
  selector: 'app-notification-detail',
  templateUrl: './notification-detail.component.html',
  imports: [
    ToolbarComponent,
    SidebarComponent,
    NgIf,
    ClassEnrollmentNotificationComponent,
    AssignmentDueNotificationComponent,
    NgSwitch,
    NgSwitchCase
  ],
  styleUrls: ['./notification-detail.component.scss']
})
export class NotificationDetailComponent implements OnInit {
  notification?: NotificationModel & { actions?: any } | null = null;

  notificationDetailService: NotificationDetailService = inject(NotificationDetailService);
  tabs = tabsData;

  ngOnInit(): void {
    this.notificationDetailService.selectedNotification$.subscribe((notification) => {
      this.notification = notification;
    });
  }

  getTimeAgo() {
    if (this.notification && this.notification.date) {
      return formatDistanceToNow(new Date(this.notification.date), { addSuffix: true });
    }
    return '';
  }
}
