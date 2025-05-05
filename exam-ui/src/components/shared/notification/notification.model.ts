export class NotificationModel {
  constructor(
    public id: string,
    public title: string,
    public type: string,
    public message: string,
    public date: Date,
    public isRead: boolean,
    public senderName: string,
    public details: string,
    public senderImageUrl: string
  ) {
    this.id = id;
    this.title = title;
    this.type = type;
    this.message = message;
    this.date = date;
    this.isRead = isRead;
    this.senderName = senderName;
    this.details = details;
    this.senderImageUrl = senderImageUrl;
  }
}
