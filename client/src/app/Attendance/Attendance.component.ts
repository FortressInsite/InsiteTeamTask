import { Component, OnInit } from '@angular/core';
import { Attendance } from '../_models/attendance';
import { AttendanceService } from '../_services/attendance.service';

@Component({
  selector: 'app-Attendance',
  templateUrl: './Attendance.component.html',
  styleUrls: ['./Attendance.component.css']
})
export class AttendanceComponent implements OnInit {
attendance: Attendance[];

  constructor(private attendaceService: AttendanceService) { }

  ngOnInit() {
  }

  getAttendance(){
    this.attendaceService.getAttendance().subscribe(attendance =>
      {
        this.attendance = attendance;
      })
  }

}
