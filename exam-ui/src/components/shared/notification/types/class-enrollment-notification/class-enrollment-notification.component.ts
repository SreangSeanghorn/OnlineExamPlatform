import { Component, Input, ViewEncapsulation } from '@angular/core';
import {CommonModule, NgIf} from '@angular/common';
import {formatDistanceToNow} from 'date-fns';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { NotificationModel } from '../../notification.model';

@Component({
  standalone: true,
  selector: 'app-class-enrollment-notification',
  templateUrl: './class-enrollment-notification.component.html',
  encapsulation: ViewEncapsulation.None,
  imports: [
    NgIf,
    CommonModule,
    MatButtonModule
  ],
  styleUrls: ['./class-enrollment-notification.component.css']
})
export class ClassEnrollmentNotificationComponent {
  @Input() notification!: NotificationModel;
  getTimeAgo() {
    if (this.notification && this.notification.date) {
      return formatDistanceToNow(new Date(this.notification.date), { addSuffix: true });
    }
    return "";
  }

  acceptClassEnrollment(notification: NotificationModel) {

  }

  rejectClassEnrollment(notification: NotificationModel) {

  }
}
