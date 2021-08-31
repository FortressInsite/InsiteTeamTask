import { Component, OnInit } from "@angular/core";
import { AttendanceService } from "../attendance.service";
import { Member } from "../member";

@Component({
  selector: "app-members",
  templateUrl: "./members.component.html",
  styleUrls: ["./members.component.scss"],
})
export class MembersComponent implements OnInit {
  displayedColumns: string[] = ["id", "productId"];
  dataSource: Member[] = [];

  constructor(private attendanceService: AttendanceService) {}

  ngOnInit(): void {
    this.attendanceService
      .getAllMembers()
      .subscribe((data) => (this.dataSource = data));
  }
}
