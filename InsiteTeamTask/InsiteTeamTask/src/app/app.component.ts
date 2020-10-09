import { Component, OnInit } from '@angular/core';
import { ApiService } from '../app/api.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'InsiteTeamTask';
  attendance;
  gameData;
  seasonData;
  productData;
  seasonId;
  gameId;

  constructor(private api: ApiService) { }
  ngOnInit(): void {
    this.api.getGameData().subscribe((data) => {
      this.gameData = data;
    });

    this.api.getSeasonData().subscribe((data) => {
      this.seasonData = data;
    });

    this.api.getProductData().subscribe((data) => {
      this.productData = data;
    });
  }

  form = new FormGroup({
    season: new FormControl('', Validators.required),
    game: new FormControl('', Validators.required)
  });

  get f() {
    return this.form.controls;
  }

  submit() {
    if (this.form.value.season !== "Select Season" && this.form.value.game !== "Select Game") {
      this.api.getAttendanceByGameAndSeason(this.form.value.game, this.form.value.season).subscribe((data) => {
        this.attendance = data;
      });
    }
  }

  formProduct = new FormGroup({
    product: new FormControl('', Validators.required)
  });

  get fP() {
    return this.formProduct.controls;
  }

  submitProduct() {
    if (this.formProduct.value.product !== "Select Product") {
      this.api.getAttendanceByProduct(this.formProduct.value.product).subscribe((data) => {
        this.attendance = data;
      });
    }
  }
}

