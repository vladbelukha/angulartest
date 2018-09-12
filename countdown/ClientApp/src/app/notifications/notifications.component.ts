import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public notifications: Notification[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Notification[]>(baseUrl + 'api/notifications').subscribe(result => {
      this.notifications = result;
    }, error => console.error(error));
  }
}
