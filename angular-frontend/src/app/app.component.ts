import { Component } from '@angular/core';
import { GetApiService } from 'src/service/get-api.service';

// called the decorator and it includes metadata for the
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'angular-frontend';

  constructor(private api: GetApiService) {}
}
