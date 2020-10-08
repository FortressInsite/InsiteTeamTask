import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Attendance } from 'src/Model/Attendance';
import { $ } from 'protractor';

@Injectable({
  providedIn: 'root',
})
export class GetApiService {
  constructor(private http: HttpClient) {}

  headerDict = {
    apiKey: 'yNvknZnTsO',
  };

  // api call function
  GetAll(): Observable<Attendance[]> {
    const requestOptions = { headers: new HttpHeaders(this.headerDict) };

    return this.http.get<Attendance[]>(
      'https://localhost:44353/api/Attendance',
      requestOptions
    );
  }

  GetProduct(Product: string): Observable<Attendance[]> {
    const requestOptions = { headers: new HttpHeaders(this.headerDict) };

    return this.http.get<Attendance[]>(
      `https://localhost:44353/api/Attendance/ProductCode/${Product}`,
      requestOptions
    );
  }

  GetSeasonAndGame(Season: number, Game: number) {
    const requestOptions = { headers: new HttpHeaders(this.headerDict) };

    return this.http.get<Attendance[]>(
      `https://localhost:44353/api/Attendance/SeasonAndGame/${Season}/${Game}`,
      requestOptions
    );
  }
}
