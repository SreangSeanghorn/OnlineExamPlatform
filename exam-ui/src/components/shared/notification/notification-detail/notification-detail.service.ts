import { Injectable } from '@angular/core';
import { NotificationModel } from '../notification.model';
import { mockNotificationData } from '../mockdata/notification.data';
import { ComponentType } from '@angular/cdk/portal';
import { AssignmentDueNotificationComponent } from '../types/assignment-due-notification/assignment-due-notification.component';
import { BehaviorSubject } from 'rxjs';
import { ClassEnrollmentNotificationComponent } from '../types/class-enrollment-notification/class-enrollment-notification.component';

@Injectable({
  providedIn: 'root'
})
export class NotificationDetailService {
  private selectedNotificationSubject = new BehaviorSubject<NotificationModel | null>(null);
  selectedNotification$ = this.selectedNotificationSubject.asObservable();

  constructor() {
  }
  notifications: NotificationModel[] = mockNotificationData;
  getNotificationById(id: string): NotificationModel {
    const notification = this.notifications.find(notification => notification.id === id);
    if (!notification) {
      throw new Error('Notification not found');
    }
    if (!notification.message) {
      notification.message = ''; // Ensure message is defined
    }
    this.selectedNotificationSubject.next(notification);
    return notification;
  }

}
