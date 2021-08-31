import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import {
  MatButtonModule,
  MatInputModule,
  MatSelectModule,
  MatTableModule,
} from "@angular/material";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { AttendanceComponent } from "./attendance/attendance.component";
import { MembersComponent } from "./members/members.component";
import { TicketsComponent } from "./tickets/tickets.component";
@NgModule({
  declarations: [
    AppComponent,
    MembersComponent,
    TicketsComponent,
    AttendanceComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatTableModule,
    MatButtonModule,
    HttpClientModule,
    MatInputModule,
    MatSelectModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
