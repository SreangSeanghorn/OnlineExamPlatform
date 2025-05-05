import { Component, Input } from '@angular/core';
import { NotificationModel } from '../../notification.model';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-assignment-due-notification',
  templateUrl: './assignment-due-notification.component.html',
  imports: [
    NgIf
  ],
  styleUrls: ['./assignment-due-notification.component.css']
})
export class AssignmentDueNotificationComponent {
  @Input() notification!: NotificationModel; // Ensure notification is passed and defined
}
