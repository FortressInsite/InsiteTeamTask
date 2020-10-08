import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Attendance } from "./interfaces/Attendance";
import { Observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {
  
  private attendaceUrl = '/api/attendance';

  constructor(private http: HttpClient) { }

  getAttendanceGameAndSeason(game: number, season: number): Observable<Attendance> {
    return this.http.get<Attendance>(this.attendaceUrl + "/get/" + game + "/" + season).pipe(
      catchError(this.handleError<Attendance>('Get')));
  }

  getAttendanceProduct(product: string): Observable<Attendance> {
    return this.http.get<Attendance>(this.attendaceUrl + "/get/" + product);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);

      return of(result as T);
    }
  }
}
