import { Component, OnInit } from '@angular/core';
import { FgbDetailService } from '../../service/fgb-detail.service';

@Component({
  selector: 'app-fgb-detail',
  templateUrl: './fgb-detail.component.html',
  styleUrls: ['./fgb-detail.component.css']
})
export class FgbDetailComponent implements OnInit {

  constructor(public service:FgbDetailService) { }

  ngOnInit(): void {
  }

}
