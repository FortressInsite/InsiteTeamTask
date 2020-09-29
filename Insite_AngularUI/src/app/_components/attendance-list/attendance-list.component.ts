import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs";

import { DataService } from 'src/app/_services/data.service';
import { Attendance } from 'src/app/_models/attendance';

@Component({
  selector: 'app-attendance-list',
  templateUrl: './attendance-list.component.html',
  styleUrls: ['./attendance-list.component.scss']
})
export class AttendanceListComponent implements OnInit {
  constructor(private dataService: DataService) { }
  attendances: Attendance[] = [];

  ngOnInit(): void {
    this.dataService.attendanceList
      .subscribe((attendances: Attendance[]) => {
        this.attendances = attendances;
      });

    this.dataService.getAttendanceList();
  }

}
