import { Component, inject, OnInit } from '@angular/core';
import { MatIconButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { NgForOf, NgIf } from '@angular/common';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { NotificationService } from './notification.service';
import { NotificationDetailService } from './notification-detail/notification-detail.service'; // Import NotificationDetailService
import { NotificationModel } from './notification.model';
import { formatDistanceToNow } from 'date-fns';
import { Router } from '@angular/router';

@Component({
  selector: 'app-notification',
  imports: [
    MatIconButton,
    MatIcon,
    NgIf,
    MatMenuTrigger,
    MatMenu,
    NgForOf
  ],
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.scss'
})
export class NotificationComponent implements OnInit {
  hasNotification = true;
  notificationService: NotificationService = inject(NotificationService);
  notificationDetailService: NotificationDetailService = inject(NotificationDetailService); // Use NotificationDetailService
  notifications: NotificationModel[] = [];
  router: Router = inject(Router);

  ngOnInit(): void {
    this.notificationService.getAllNotifications().then((notifications) => {
      this.hasNotification = notifications.length > 0;
      this.notifications = notifications;
    });
  }

  formatTime(timestamp: string | Date): string {
    return formatDistanceToNow(new Date(timestamp), { addSuffix: true });
  }

  goToDetail(notification: NotificationModel): void {
    this.notificationDetailService.getNotificationById(notification.id);
    this.router.navigate(['/notification-detail']);
  }
}
