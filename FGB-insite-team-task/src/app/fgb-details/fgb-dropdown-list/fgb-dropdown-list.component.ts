import { Component, OnInit } from '@angular/core';
import { FgbDetailService } from '../../service/fgb-detail.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-fgb-dropdown-list',
  templateUrl: './fgb-dropdown-list.component.html',
  styleUrls: ['./fgb-dropdown-list.component.css']
})
export class FgbDropdownListComponent implements OnInit {
  constructor(public service:FgbDetailService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.getGame();
    this.service.getSeason();
    this.service.getProduct();
  }

  gameSelected(val:any) {
    this.service.gameNumber = val
    console.log(val)
  }

  seasonSelected(val:any) {
    this.service.seasonNumber = val
    console.log(val)
  }

  productSelected(val:any) {
    this.service.productNumber = val
    console.log(val)
  }

  initializeAttendanceData() {
    if(this.service.gameNumber != null && this.service.seasonNumber != null)
    {
      this.service.getAttendance(this.service.gameNumber,this.service.seasonNumber,this.service.productNumber)
    }
    else {
      this.toastr.success('Select both Game and Season to proceed!');
    }
  }
}
