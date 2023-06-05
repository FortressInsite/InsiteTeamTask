import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MdbTablePaginationComponent, MdbTableDirective } from 'angular-bootstrap-md';
import { Attendance } from '../interfaces/attendance';
import { AttendanceService } from '../services/attendance.service';
import { NotificationService } from '../services/notification.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.scss']
})
export class AttendanceComponent implements OnInit, AfterViewInit {
  @ViewChild(MdbTablePaginationComponent, { static: true }) mdbTablePagination: MdbTablePaginationComponent;
  @ViewChild(MdbTableDirective, { static: true }) mdbTable: MdbTableDirective
  previous: any = [];

  attendance: Attendance[] = [];
  total: number = 0;

  SearchForm = this.fb.group({
    code: ['', Validators.required],
  });

  SearchGameForm = this.fb.group({
    seasonId: ['', Validators.required],
    gameNumber: ['', Validators.required],
  });

  displayedColumns: string[] = ['barcode', 'attendanceType', 'memberId'];
  dataSource = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  constructor(private fb: FormBuilder,
    private cdRef: ChangeDetectorRef,
    private service: AttendanceService,
    private notifyService: NotificationService) { }

  ngOnInit(): void {
    this.GetAttendance();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }


  GetAttendance() {
    this.service.getAttendance().subscribe((data) => {
      this.setGridDatasource(data);

    });
  }

  GetAttendanceForProduct(productCode: string) {
    this.service.getAttendanceForProduct(productCode).subscribe((data) => {
      this.setGridDatasource(data);
    });
  }

  GetAttendanceForGame(seasonId: number, gameNumber: number) {
    this.service.getAttendanceForGame(seasonId, gameNumber).subscribe((data) => {
      this.setGridDatasource(data);
    });
  }

  setGridDatasource(data: any) {
    this.dataSource = new MatTableDataSource<any>(data);;
    this.dataSource.paginator = this.paginator;
  }


  Search() {
    if (!this.SearchForm.valid) {

      this.Invalid();
      return;
    }
    this.GetAttendanceForProduct(this.SearchForm?.value?.code);

  }

  SearchGame() {
    if (!this.SearchGameForm.valid) {
      this.Invalid();
      return;
    }
    const seasonId = this.SearchGameForm.value.seasonId;
    const gameNumber = this.SearchGameForm.value.gameNumber;
    
    this.GetAttendanceForGame(seasonId, gameNumber);

  }

  clearAll() {
    this.SearchForm.reset();
    this.SearchGameForm.reset();
    this.GetAttendance();
  }
  Invalid() {
    this.notifyService.showError("", "Enter search data");
  }

}
