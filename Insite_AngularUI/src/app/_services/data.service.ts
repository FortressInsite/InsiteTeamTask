import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject } from "rxjs";
import { map } from "rxjs/operators";

import { Attendance } from "../_models/attendance";

@Injectable({ providedIn: "root" })
export class DataService {
  constructor(private http: HttpClient) {}

  attendanceList: BehaviorSubject<Attendance[]> = new BehaviorSubject<
    Attendance[]
  >([]);

  getAttendanceList(): Promise<any> {
    return new Promise((resolve, reject) => {
      this.http
        .get("https://localhost:44376/api/values", {
          headers: { "X-Requested-With": "XMLHttpRequest" },
        })
        .subscribe(
          (data: Attendance[]) => this.attendanceList.next(data),
          (error) => console.log("Error: ", error)
        );
    });
  }
}
