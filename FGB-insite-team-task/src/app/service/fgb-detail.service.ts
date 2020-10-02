import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import {Game} from '../fgb-models/game.model';
import { Season } from '../fgb-models/season.model';
import { Product } from '../fgb-models/product.model';
import { Attendance } from '../fgb-models/attendance.model';

@Injectable({
  providedIn: 'root'
})
export class FgbDetailService {
  gameList:Game[];
  seasonList:Season[];
  productList:Product[];
  attendanceList:Attendance[];
  gameNumber:number;
  seasonNumber:number;
  productNumber:string;

  readonly rootURL = 'https://localhost:5001/api';

  constructor(private http: HttpClient) {
  }

  getGame() {
    this.http.get<Game[]>(this.rootURL + '/game')
    .toPromise()
    .then(res => this.gameList = res as Game[]);
  }

  getSeason() {
    this.http.get(this.rootURL + '/season')
    .toPromise()
    .then(res => this.seasonList = res as Season[]);
  }

  getProduct() {
    this.http.get(this.rootURL + '/product')
    .toPromise()
    .then(res => this.productList = res as Product[]);
  }

  getAttendance(gameNumber:number, seasonNumber:number, productNumber?:string) {
    if(productNumber != null)
    {
      this.http.get(this.rootURL + '/attendance/' + gameNumber + '/' + seasonNumber + '/' + productNumber)
      .toPromise()
      .then(res => this.attendanceList = res as Attendance[]);
    }
    else
    {
      this.http.get(this.rootURL + '/attendance/' + gameNumber + '/' + seasonNumber)
      .toPromise()
      .then(res => this.attendanceList = res as Attendance[]);
    }
  }
}
