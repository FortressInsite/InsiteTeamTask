import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Attendance } from '../webapi-service/attendance';
import { WebapiService } from '../webapi-service/webapi.service';
import { Season } from '../webapi-service/season';
import { Game } from '../webapi-service/game';
import { Product } from '../webapi-service/product';

@Component({
  selector: 'app-attendance-grid',
  templateUrl: './attendance-grid.component.html',
  styleUrls: ['./attendance-grid.component.css']
})
export class AttendanceGridComponent implements OnInit {

  constructor(private service: WebapiService) { }

  @Output() Timeout = new EventEmitter<any>();

  attendance: Attendance[];
  seasons: Season[];
  games: Game[];
  products: Product[];

  getDataByGameSelected = true;
  selectedSeasonId: number;
  selectedGameId: number;
  selectedProductId: string;

  ngOnInit() {
    // In future I'd add more null checking here instead of using indexers
    this.seasons = this.service.getSeasons();
    this.selectedSeasonId = this.seasons[0].Id;
    this.onSeasonChange();
    this.products = this.service.getProducts();
    this.selectedProductId = this.products[0].Id;
  }

  onSeasonChange() {
    this.games = this.service.getGames(this.selectedSeasonId);
    this.selectedGameId = this.games[0].Id;
  }

  getData() {
    if (this.getDataByGameSelected) {
      this.service.getAttendanceForGame(this.selectedSeasonId, this.selectedGameId)
        .subscribe(attendance => { this.attendance = attendance; },
          err => { this.Timeout.emit(); });
    } else {
      this.service.getAttendanceForProduct(this.selectedProductId)
        .subscribe(attendance => { this.attendance = attendance; },
          err => { this.Timeout.emit(); });
    }
  }
}
