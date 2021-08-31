import { Component, OnInit } from "@angular/core";
import { Attendance } from "../attendance";
import { AttendanceService } from "../attendance.service";
import { Game } from "../game";
import { Season } from "../season";

@Component({
  selector: "app-attendance",
  templateUrl: "./attendance.component.html",
  styleUrls: ["./attendance.component.scss"],
})
export class AttendanceComponent implements OnInit {
  seasons: Season[] = [];
  games: Game[] = [];
  productCodes: string[] = [];

  gameNumber = -1;
  seasonId = -1;
  productCode = "0";

  displayedColumns: string[] = ["attendanceType", "memberId", "barcode"];
  dataSource: Attendance[] = [];

  constructor(private attendanceService: AttendanceService) {}

  ngOnInit() {
    this.attendanceService
      .getAllGames()
      .subscribe((data) => (this.games = data));
    this.attendanceService
      .getAllSeasons()
      .subscribe((data) => (this.seasons = data));
    this.attendanceService
      .getAllProductCodes()
      .subscribe((data) => (this.productCodes = data));
    this.attendanceService
      .getAttendance(this.productCode, this.seasonId, this.gameNumber)
      .subscribe((data) => (this.dataSource = data));
  }

  gameChanged(value: number) {
    this.gameNumber = value;
    this.productCode = "0";
    this.attendanceService
      .getAttendance(this.productCode, this.seasonId, this.gameNumber)
      .subscribe((data) => (this.dataSource = data));
  }

  seasonChanged(value: number) {
    this.seasonId = value;
    this.productCode = "0";
    this.attendanceService
      .getAttendance(this.productCode, this.seasonId, this.gameNumber)
      .subscribe((data) => (this.dataSource = data));
  }

  productCodeChanged(value: string) {
    this.productCode = value;
    this.seasonId = this.gameNumber = -1;
    this.attendanceService
      .getAttendance(this.productCode, this.seasonId, this.gameNumber)
      .subscribe((data) => (this.dataSource = data));
  }
}
