import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Attendance } from '../_models/attendance';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAttendance() {
    return this.http.get<Attendance[]>(this.baseUrl + 'attendance');
  }
}
