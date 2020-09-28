import { Component, Input, OnChanges } from '@angular/core';
import { Attendance } from '../models/attendance';

@Component({
  selector: 'insite-team-attendances',
  templateUrl: './attendances.component.html',
  styleUrls: ['./attendances.component.css']
})
export class AttendancesComponent implements OnChanges {

  @Input() attendances: Attendance[] = [];
  displayedColumns: string[] = ['memberId','barcode']
  constructor() { }

  ngOnChanges(): void {
  }
}
