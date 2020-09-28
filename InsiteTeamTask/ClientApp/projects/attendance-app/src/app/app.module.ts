import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component'
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTableModule } from '@angular/material/table';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { AttendancesComponent } from './attendances/attendances.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AttendancesComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
	HttpClientModule,
	MatToolbarModule,
	MatTableModule,
	MatButtonModule,
    MatSelectModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
