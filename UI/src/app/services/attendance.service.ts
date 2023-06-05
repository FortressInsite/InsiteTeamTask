import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Attendance } from '../interfaces/attendance';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {
  headers = new HttpHeaders();

  constructor(private http: HttpClient) {
    this.headers = this.headers.set('X-API-Key', 'encriptyed_api_key_from_session_or_localStorage');
  }




  getAttendance(): Observable<Attendance[]> {
    return this.http
      .get<Attendance[]>(
        `${environment.baseUrl}attendance`, { headers: this.headers }
      );
  }

  getAttendanceForProduct(productCode: string): Observable<Attendance[]> {
    return this.http
      .get<Attendance[]>(
        `${environment.baseUrl}attendance/${productCode}`, { headers: this.headers }
      )
      .pipe();
  }

  getAttendanceForGame(seasonId: number, gameNumber: number): Observable<Attendance[]> {
    return this.http
      .get<Attendance[]>(
        `${environment.baseUrl}attendance/${seasonId}/${gameNumber}`, { headers: this.headers }
      )
      .pipe();
  }
}
