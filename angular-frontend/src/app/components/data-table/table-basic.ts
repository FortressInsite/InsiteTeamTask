import { Component, Input, OnInit, SimpleChange } from '@angular/core';
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
  selectedValue: string;

  constructor(private api: GetApiService) {}

  ngOnInit() {
    this.TotalList();
  }

  TotalList() {
    this.api.GetAll().subscribe((response) => {
      this.dataSource = new MatTableDataSource(response);
    });
  }

  changeSeasonHandler() {
    const SeasonArray = this.selectedValue.split(',');
    if (this.selectedValue == '') {
      this.TotalList();
    } else {
      this.api
        .GetSeasonAndGame(parseInt(SeasonArray[0]), parseInt(SeasonArray[1]))
        .subscribe((data) => (this.dataSource = new MatTableDataSource(data)));
    }
  }

  changeProductHandler() {
    if (this.selectedValue == '') {
      this.TotalList();
    } else {
      this.api.GetProduct(this.selectedValue).subscribe((data) => {
        this.dataSource = new MatTableDataSource(data);
      });
    }
  }
}
