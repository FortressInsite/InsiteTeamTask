import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { MatCardModule } from '@angular/material/card'

import { DataService } from './_services/data.service';
import { AppComponent } from './app.component';
import { AttendanceListModule } from './_components/attendance-list/attendance-list.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatCardModule,

    AttendanceListModule
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
