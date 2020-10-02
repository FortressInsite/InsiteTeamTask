import { Component, OnInit } from '@angular/core';
import { Game } from '../fgb-models/game.model';
import { FgbDetailService } from '../service/fgb-detail.service';

@Component({
  selector: 'app-fgb-details',
  templateUrl: './fgb-details.component.html',
  styleUrls: ['./fgb-details.component.css']
})
export class FgbDetailsComponent implements OnInit {
  
  constructor(public service: FgbDetailService) { }

  ngOnInit():void {
  }

}
