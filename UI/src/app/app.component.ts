import { Component, OnInit } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { NgxSpinnerService } from "ngx-spinner";
import { Attendancedto } from "./models/attendancedto";
import { HttpService } from "./services/httpservice.service";
import { FilterByGameAndSessionIdModalComponent } from "./UIModals/filterByGameAndSessionIdModal/filterByGameAndSessionIdModal.component";
import { FilterByProductCodeModalComponent } from "./UIModals/filterByProductCodeModal/filterByProductCodeModal.component";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.scss"],
})
export class AppComponent implements  OnInit  {

  attendances:Attendancedto[] = [];
  isloading = true;
  constructor(
    public httpService:HttpService,
    public ngModalService:NgbModal,
    private spinner: NgxSpinnerService
  ){

  }
  ngOnInit(): void {
    
    this.fetchall();
  }
  fetchall()
  {
    this.spinner.show();
    this.isloading = true;
    this.httpService.getAttendance().subscribe({
      next:(data)=>{
        this.spinner.hide();
        this.isloading = false;
        this.attendances = data.body;
      },
      error:(err)=>{
        this.spinner.hide();
        this.isloading = false;
      }
    });
  }
  filterByProductCode(productCode:string)
  {
    this.isloading = true;
    this.spinner.show();
    this.httpService.getAttendanceByProductCode(productCode).subscribe({
      next:(data)=>{
        this.spinner.hide();
        this.isloading = false;
        this.attendances = data.body;
      },
      error:(err)=>{
        this.spinner.hide();
        this.isloading = false;
      }
    });
  }
  filterBySessionAndGameId(sessionId:number,gameId:number)
  {
    this.isloading = true;
    this.spinner.show();
      this.httpService.getAttendanceBySessionIdAndGameId(sessionId,gameId).subscribe({
        next:(data)=>{
          this.spinner.hide();
          this.isloading = false;
          this.attendances = data.body;
        },
        error:(err)=>{
          this.spinner.hide();
          this.isloading = false;
        }
      });
  }
  openFilterModals(id:number)
  {
    if(id == 1)
    {
      let modal = this.ngModalService.open(FilterByProductCodeModalComponent);
      modal.result.then(res =>{
        if(res != undefined)
        {
          this.filterByProductCode(res);
        }
      });
    }
    else{
      let modal = this.ngModalService.open(FilterByGameAndSessionIdModalComponent);
      modal.result.then(res=>{
        if(res != undefined)
        {
          this.filterBySessionAndGameId(res.sessionId,res.gameId);
        }
      });
    }
  }

}
