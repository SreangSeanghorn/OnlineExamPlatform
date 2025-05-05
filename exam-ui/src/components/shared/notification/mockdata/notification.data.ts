import {NotificationModel} from '../notification.model';
export const mockNotificationData = [
  new NotificationModel(
    "2",
    "New Assignment",
    "assignment-due",
    "You have a new assignment due next week.",
    new Date("2025-04-11T10:00:00"),
    false,
    "Michael Smith",
    "Please check the assignment portal for more details.",
    "./assets/images/user1.jpg"
  ),
  new NotificationModel(
    "3",
    "New Student Enrolled",
    "class-enrollment",
    "A new student has enrolled in your class.",
    new Date("2025-04-11T10:00:00"),
    false,
    "Emily Davis",
    "Please check the enrollment portal for more details.",
    "./assets/images/userprofile.jpg"
  ),
];
