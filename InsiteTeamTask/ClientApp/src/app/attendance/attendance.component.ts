import { Component, OnInit } from '@angular/core';
import { AttendanceService } from '../attendance.service';
import { Attendance } from "../interfaces/Attendance";
import { ListService } from '../list.service';
import { Product, Season, Game } from "../interfaces/List";

@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.css']
})
export class AttendanceComponent implements OnInit {

  attendances: Attendance;
  attendancesProduct: Attendance;
  game: number;
  season: number;
  product: string;

  products: Product[];
  seasons: Season[];
  games: Game[];

  constructor(private attendanceService: AttendanceService, private listService: ListService) {

  }

  getAttendanceGameAndSeason(): void {
    this.attendanceService.getAttendanceGameAndSeason(this.game, this.season).subscribe(x => this.attendances = x);
  }

  getAttendanceProduct(): void {
    this.attendanceService.getAttendanceProduct(this.product).subscribe(x => this.attendancesProduct = x);
  }

  setSeason(value: number) {
    this.season = value;
  }

  setGame(value: number) {
    this.game = value;
  }

  setProduct(value: string) {
    this.product = value;
  }

  ngOnInit() {
    this.listService.getProducts().subscribe(x => this.products = x);
    this.listService.getSeasons().subscribe(x => this.seasons = x);
    this.listService.getGames().subscribe(x => this.games = x);
  }
}
