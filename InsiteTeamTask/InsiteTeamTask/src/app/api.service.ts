import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  public getGameData() {
    return this.http.get(`https://localhost:44376/api/gameData`);
  }

  public getSeasonData() {
    return this.http.get(`https://localhost:44376/api/seasonData`);
  }

  public getProductData() {
    return this.http.get(`https://localhost:44376/api/productData`);
  }

  public getAttendanceByGameAndSeason(gameId: number, seasonId: number) {
    return this.http.get(`https://localhost:44376/api/${gameId}/${seasonId}`);
  }

  public getAttendanceByProduct(productId: string) {
    return this.http.get(`https://localhost:44376/api/product/${productId}`);
  }
}
// I created this service so that it could be injected into my component to allow to load data using the API.
