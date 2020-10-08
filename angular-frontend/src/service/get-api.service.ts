import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Attendance } from 'src/Model/Attendance';

@Injectable({
  providedIn: 'root',
})
export class GetApiService {
  constructor(private http: HttpClient) {}

  // api call function
  apiCall(): Observable<Attendance[]> {
    const headerDict = {
      apiKey: 'yNvknZnTsO',
    };

    const requestOptions = { headers: new HttpHeaders(headerDict) };

    return this.http.get<Attendance[]>(
      'https://localhost:44353/api/Attendance',
      requestOptions
    );
  }
}
