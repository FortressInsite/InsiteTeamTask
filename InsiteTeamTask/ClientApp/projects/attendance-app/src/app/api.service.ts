import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Attendance } from './models/attendance';
import { Product } from './models/product';
import { Season } from './models/season';
import { Game } from './models/game';

@Injectable({
	providedIn: 'root'
})
export class ApiService {

	private SERVER_URL = "https://localhost:5001";

	constructor(private httpClient: HttpClient) { }

	attendances: Attendance[] = [{memberId: 2, barcode: "N/A"},{memberId: 1, barcode: "N/A"}]
	products: Product[] = [];
	seasons: Season[] = [];
	games: Game[] = [];

	getProducts(): Observable<Product[]> {
		return this.httpClient.get<Product[]>(this.SERVER_URL+'/api/product');
	}

	getSeasons(): Observable<Season[]> {
		return this.httpClient.get<Season[]>(this.SERVER_URL+'/api/season');
	}

	getGames(): Observable<Game[]> {
		return this.httpClient.get<Game[]>(this.SERVER_URL+'/api/game');
	}

	getAttendancesFromProductId(productId?: string): Observable<Attendance[]> {
		return this.httpClient.get<Attendance[]>(`${this.SERVER_URL}/api/attendance?productId=${productId}`);
	}

	getAttendancesFromSeasonAndGame(seasonId?: number, gameId?: number): Observable<Attendance[]> {
		return this.httpClient.get<Attendance[]>(`${this.SERVER_URL}/api/attendance?seasonId=${seasonId}&gameId=${gameId}`);
	}
}
