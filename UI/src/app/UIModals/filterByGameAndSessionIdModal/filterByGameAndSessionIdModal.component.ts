import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { GameSeasondto } from 'src/app/models/gameSeason';
import { HttpService } from 'src/app/services/httpservice.service';

@Component({
  selector: 'app-filterByGameAndSessionIdModal',
  templateUrl: './filterByGameAndSessionIdModal.component.html',
  styleUrls: ['./filterByGameAndSessionIdModal.component.scss']
})
export class FilterByGameAndSessionIdModalComponent implements OnInit {

  filterForm: FormGroup;
  gameSeasons:GameSeasondto[]=[];
  gameSeason:GameSeasondto = {
    gameId: 0,
    seasonId: 0,
    gameSeasonName: ''
  };
  constructor(private activeModal: NgbActiveModal,
    private formBuilder: FormBuilder,
    public httpService:HttpService
    ) { }

  ngOnInit() {
    this.filterForm = this.formBuilder.group({
        gameseason:['',[Validators.required]],
       
    });
    this.httpService.getGameSeasons().subscribe({
      next:(data)=>{
        this.gameSeasons = data.body;
        this.gameSeason = this.gameSeasons[0];
      },
      error:(err)=>{}
    });
  }
  close()
  {
    this.activeModal.close();
  }
  search()
  {
    debugger;
    this.filterForm.markAllAsTouched();
    if(this.filterForm.valid)
    {
        this.activeModal.close(this.gameSeason);
    }
  }

}
