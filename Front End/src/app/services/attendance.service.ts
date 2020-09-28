import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Attendance } from '../models/attendance';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {

  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/attendance/';
  }

  getAttendanceBySeasonAndGame(seasonNumber: number, gameNumber: number): Observable<Attendance[]> {
    const paramStr = `season/${seasonNumber}/game/${gameNumber}`;
    return this.http.get<Attendance[]>(this.myAppUrl + this.myApiUrl + paramStr)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getAttendanceByProduct(productId: string): Observable<Attendance[]> {
    return this.http.get<Attendance[]>(this.myAppUrl + this.myApiUrl + productId)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
