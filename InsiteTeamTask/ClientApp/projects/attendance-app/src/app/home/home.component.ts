import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Attendance } from '../models/attendance';
import { Product } from '../models/product';
import { Season } from '../models/season';
import { Game } from '../models/game';

@Component({
	selector: 'insite-team-home',
	templateUrl: './home.component.html',
	styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

    attendances: Attendance[] = [];
	products: Product[] = [];
	seasons: Season[] = [];
	allGames: Game[] = [];

	isProductSelectionMethod = true;
	games: Game[] = [];
	selectedGame?: Game;
	selectedProduct?: Product;
	selectedSeason?: Season;

	error: string = "";

	constructor(private apiService: ApiService) { 
		this.apiService.getProducts().subscribe(products => this.products = products);
		this.apiService.getSeasons().subscribe(seasons => this.seasons = seasons);
		this.apiService.getGames().subscribe(games => this.allGames = games);
	}

	ngOnInit(): void {
	}

	setToProduct(): void {
		this.error="";
		this.isProductSelectionMethod = true;
		this.selectedSeason = undefined;
		this.selectedGame = undefined;
	}

	setToSeasonAndGame(): void {
		this.isProductSelectionMethod = false;
		this.selectedProduct = undefined;
	}

	onSelectProduct(product: Product) {
		this.selectedProduct = product;
	}

	onSelectSeason(season: Season) {
		this.selectedSeason = season;
		this.games = this.allGames.filter(g => g.seasonId == season.id);
	}

	onSelectGame(game: Game) {
		this.error = "";
		this.selectedGame = game;
	}

	getAttendances(): void {
		if(this.isProductSelectionMethod) {
			this.apiService.getAttendancesFromProductId(this.selectedProduct?.id).subscribe(attendances => this.attendances = attendances);
		}
		else if(this.selectedSeason && this.selectedGame) {
			this.apiService.getAttendancesFromSeasonAndGame(this.selectedSeason?.id,this.selectedGame?.id).subscribe(attendances => this.attendances = attendances);
		}
		else {
			this.error = "Please provide both season and game!";
		}
	}
}


