import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { GetApiService } from 'src/service/get-api.service';
import { Attendance } from 'src/Model/Attendance';

@Component({
  selector: 'table-basic',
  styleUrls: ['table-basic.css'],
  templateUrl: 'table-basic.html',
})
export class TableBasic implements OnInit {
  dataSource;
  displayedColumns: string[] = ['memberId', 'barcode'];

  constructor(private api: GetApiService) {}

  ngOnInit() {
    this.api.apiCall().subscribe((response) => {
      this.dataSource = new MatTableDataSource(response);
    });
  }
}
