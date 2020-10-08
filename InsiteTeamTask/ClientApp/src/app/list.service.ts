import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Product, Season, Game } from "./interfaces/List";
import { Observable, of } from "rxjs";
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ListService {

  private listUrl = '/api/list';

  constructor(private http: HttpClient) { }
  
  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.listUrl + "/products");
  }

  getGames(): Observable<Game[]> {
    return this.http.get<Game[]>(this.listUrl + "/games");
  }

  getSeasons(): Observable<Season[]> {
    return this.http.get<Season[]>(this.listUrl + "/seasons");
  }
}
