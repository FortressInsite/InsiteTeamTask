import { Component, OnInit } from '@angular/core';
import { WebapiService } from './webapi-service/webapi.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FGB Insite Team Task';
  currentUser = '';
  errorMessage = '';

  // Import WebAPI service
  constructor(private webapiService: WebapiService) { }

  loggedIn = false;

  // Called when clicking the login button
  validateLogin(username: string, password: string) {
    // Check fields are populated
    if (username.length === 0 || password.length === 0) {
      this.errorMessage = 'Please fill out both fields';
      return;
    }

    // Attempt to log in
    this.webapiService.login(username, password)
      .subscribe(
        login => {
          this.errorMessage = '';
          this.loggedIn = login.token.length > 0;
          this.currentUser = username;
        },
        err => {
          this.errorMessage = 'Login Failed';
        });
  }

  logOut() {
    // Reset login data
    this.webapiService.logOut();
    this.loggedIn = false;
    this.currentUser = '';
  }

  timedOut() {
    // Log out and inform user of timeout
    this.errorMessage = 'Session timed out';
    this.logOut();
  }
}
