import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

import { LoginToken } from './loginToken';
import { Attendance } from './attendance';
import { Season } from './season';
import { Game } from './game';
import { Product } from './product';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' })
};

@Injectable({
  providedIn: 'root'
})
export class WebapiService {

  constructor(private http: HttpClient) {
    // IRL this would be pulled from the API, but it hasn't been implemented yet
    this.games = [
      { Id: 3, SeasonId: 12, Description: 'Manchester City v Liverpool' },
      { Id: 4, SeasonId: 19, Description: 'Bournemouth v Arsenal' },
      { Id: 5, SeasonId: 19, Description: 'Liverpool vs Aston Villa' },
      { Id: 12, SeasonId: 16, Description: 'Arsenal v Manchester United' },
      { Id: 3, SeasonId: 19, Description: 'Crystal Palace v Everton' },
    ];
  }

  private apiUrl = 'https://localhost:44376/api';
  private games: Game[];
  private token: string;

  login(username: string, password: string): Observable<LoginToken> {
    const loginUrl = this.apiUrl + '/authentication';
    const login = this.http.post<LoginToken>(loginUrl, JSON.stringify({ username, password }), httpOptions);
    // When logged in, save the token string in this class
    // It's better to do this using local storage so you can share the token across services/classes, but since
    // I only have one service I can get away with this
    login.subscribe(
      loginToken => { this.token = loginToken.token; },
      err => { this.logOut(); }
    );
    return login;
  }

  logOut() {
    // Clear token string
    this.token = '';
  }

  getAttendanceForGame(seasonId: number, gameId: number): Observable<Attendance[]> {
    const attendanceUrl = this.apiUrl + `/attendance?seasonId=${seasonId}&gameId=${gameId}`;
    return this.http.get<Attendance[]>(attendanceUrl,{
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + this.token
      })
    });
  }

  getAttendanceForProduct(productId: string): Observable<Attendance[]> {
    const attendanceUrl = this.apiUrl + `/attendance/product?productId=${encodeURIComponent(productId)}`;
    return this.http.get<Attendance[]>(attendanceUrl, {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + this.token
      })
    });
  }

  getGames(seasonId: number): Game[] {
    return this.games.filter(game => {
      return game.SeasonId === seasonId;
    });
  }

  getProducts(): Product[] {
    return [
      { Id: 'MN319A' },
      { Id: 'LV302S' },
      { Id: 'BM1249' },
      { Id: 'AR3942' },
      { Id: 'CH5490' },
      { Id: 'IT20' },
      { Id: 'IT93' },
      { Id: 'IT52' },
      { Id: 'IT49' },
      { Id: 'IT68' }
    ];
  }

  getSeasons(): Season[] {
    // In a real application this would retrieve data from the WebAPI, but since that isn't implemented...
    return [
      { Id: 12 },
      { Id: 16 },
      { Id: 19 }
    ];
  }
}
