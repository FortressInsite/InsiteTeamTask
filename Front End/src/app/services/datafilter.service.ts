import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DataFilterService {

  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };

  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/dataFilter/';
  }

  getSeasons(): Observable<number[]> {
    const seasonUrl = 'seasons';
    return this.http.get<number[]>(this.myAppUrl + this.myApiUrl + seasonUrl)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getGames(): Observable<number[]> {
    const gameUrl = 'games';
    return this.http.get<number[]>(this.myAppUrl + this.myApiUrl + gameUrl)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  getProducts(): Observable<string[]> {
    const productUrl = 'products';
    return this.http.get<string[]>(this.myAppUrl + this.myApiUrl + productUrl)
    .pipe(
      retry(1),
      catchError(this.errorHandler)
    );
  }

  errorHandler(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
