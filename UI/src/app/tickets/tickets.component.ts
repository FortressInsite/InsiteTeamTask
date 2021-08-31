import { Component, OnInit } from "@angular/core";
import { AttendanceService } from "../attendance.service";
import { Ticket } from "../ticket";

@Component({
  selector: "app-tickets",
  templateUrl: "./tickets.component.html",
  styleUrls: ["./tickets.component.scss"],
})
export class TicketsComponent implements OnInit {
  displayedColumns: string[] = ["barcode", "productId"];
  dataSource: Ticket[] = [];

  constructor(private attendanceService: AttendanceService) {}

  ngOnInit(): void {
    this.attendanceService
      .getAllTickets()
      .subscribe((data) => (this.dataSource = data));
  }
}
