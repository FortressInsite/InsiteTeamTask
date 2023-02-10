import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Attendancedto } from '../models/attendancedto';
import { GameSeasondto } from '../models/gameSeason';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  Url = environment.BASE_URL;
  headers = new HttpHeaders();
  constructor(private http: HttpClient)
  {
    this.headers = this.headers.set('token', '1xbvcnm67yujkihnmn1');
  }
  getAttendance(): Observable<HttpResponse<Attendancedto[]>> {
   
    console.log(this.Url);
    return this.http.get<Attendancedto[]>(`${this.Url}/${Constants.Attendance}`, {
      observe: 'response',
      headers:this.headers
    });
  }
  getAttendanceByProductCode(productCode: string): Observable<HttpResponse<Attendancedto[]>> {
    return this.http.get<Attendancedto[]>(`${this.Url}/${Constants.Attendance}/${productCode}`, {
      observe: 'response',
      headers:this.headers
    });
  }
  getAttendanceBySessionIdAndGameId(sessionId: number, gameId: number): Observable<HttpResponse<Attendancedto[]>> {
    return this.http.get<Attendancedto[]>(`${this.Url}/${Constants.Attendance}/${sessionId}/${gameId}`, {
      observe: 'response',
      headers:this.headers
    });
    }
    getGameSeasons(): Observable<HttpResponse<GameSeasondto[]>> {
      return this.http.get<GameSeasondto[]>(`${this.Url}/${Constants.gameSeason}`, {
        observe: 'response',
        headers:this.headers
      });
  }
}
export class Constants {
  public static Attendance = 'attendance';
  public static gameSeason = 'gameseason';
}