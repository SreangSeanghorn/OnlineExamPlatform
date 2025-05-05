import {Injectable} from '@angular/core';
import {NotificationModel} from './notification.model';
import {mockNotificationData} from './mockdata/notification.data';

@Injectable({
  providedIn: 'root'})
export class NotificationService {
  constructor() {
  }

  // get all notifications from mockNotificationData
  getAllNotifications(): Promise<NotificationModel[]> {
    return new Promise((resolve) => {
      setTimeout(() => {
        resolve(mockNotificationData);
      }, 1000);
    });

  }
}
