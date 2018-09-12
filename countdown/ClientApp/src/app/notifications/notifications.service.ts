import { HttpClient } from '@angular/common/http';
import { Notification } from 'notification'

export class NotificationService
{
  private baseUrl = 'api/notifications';

  constructor(private http: HttpClient) { }

  createNotification(Notification notification)
  {
    let me = this;
    me.http.post(baseUrl, notification);

  }
}
