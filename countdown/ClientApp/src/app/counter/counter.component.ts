import { Component, Input, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { interval } from 'rxjs';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {  

  @Input() inputMinutes = 2;
  totalSeconds: number;
  minutesLeft: number;
  secondsLeft: number;
  private counter: object;
  private step = 10;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
  }

  public start() {
    console.log("start");

    let me = this;

    me.totalSeconds = me.inputMinutes * 60;

    let minuteCounter = 0;

    me.counter = interval(1000).subscribe(val =>
    {
      me.totalSeconds = me.totalSeconds - me.step;
      minuteCounter += me.step;

      if (minuteCounter == 60)
      {
        minuteCounter = 0;
        console.log("send notification");
      }

      me.minutesLeft = Math.floor(me.totalSeconds / 60);
      me.secondsLeft = me.totalSeconds % 60;

      if (me.totalSeconds < 1) {
        me.counter.unsubscribe();
      }
    });
  }

  public stop()
  {    
    let me = this;
    me.counter.unsubscribe();
  }

  private sendNotification()
  {
    let me = this;
    me.http.post(me.baseUrl + 'api/notifications')
  }
}
