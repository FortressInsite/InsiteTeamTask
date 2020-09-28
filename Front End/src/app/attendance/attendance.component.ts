import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AttendanceService } from '../services/attendance.service';
import { Attendance } from '../models/attendance';
import { DataFilterService } from '../services/datafilter.service';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.scss']
})
export class AttendanceComponent implements OnInit {
  attendance: Attendance[];
  resultsExists = false;
  searchAction: string;

  allSeasons: number[];
  allGames: number[];
  allProducts: string[];

  attendanceSeasonGameForm: FormGroup;
  formSeasonNumber: string;
  formGameNumber: string;

  attendanceProductForm: FormGroup;
  formProductId: string;

  constructor(private formBuilder: FormBuilder, private attendanceService: AttendanceService,
              private dataFilterService: DataFilterService) {
    this.formSeasonNumber = 'seasonNumber';
    this.formGameNumber = 'gameNumber';
    this.formProductId = 'productId';

    this.attendanceSeasonGameForm = this.formBuilder.group(
      {
        seasonNumber: [''],
        gameNumber: ['']
      }
    );

    this.attendanceProductForm = this.formBuilder.group(
      {
        productId: ['']
      }
    );
  }

  ngOnInit(): void {
    this.dataFilterService.getSeasons().subscribe((data) => {
      this.allSeasons = data.sort((n1, n2) => n1 - n2);
    });
    this.dataFilterService.getGames().subscribe((data) => {
      this.allGames = data.sort((n1, n2) => n1 - n2);
    });
    this.dataFilterService.getProducts().subscribe((data) => {
      this.allProducts = data;
    });
  }

  onSeasonGameSubmit(): void {
    const seasonNumber = this.seasonNumber.value;
    const gameNumber = this.gameNumber.value;
    this.searchAction = `Season: ${seasonNumber}, Game: ${gameNumber}`;

    this.attendanceService.getAttendanceBySeasonAndGame(Number(seasonNumber), Number(gameNumber)).subscribe((data) => {
      this.attendance = data;
      this.resultsExists = data.length > 0;
    });
    console.log(this.attendanceSeasonGameForm.value);
  }

  onProductSubmit(): void {
    const productId = this.productId.value;
    this.searchAction = `Product ID: ${productId}`;

    this.attendanceService.getAttendanceByProduct(productId).subscribe((data) => {
      this.attendance = data;
      this.resultsExists = data.length > 0;
    });
  }

  get seasonNumber() { return this.attendanceSeasonGameForm.get(this.formSeasonNumber); }
  get gameNumber() { return this.attendanceSeasonGameForm.get(this.formGameNumber); }
  get productId() { return this.attendanceProductForm.get(this.formProductId); }
}
