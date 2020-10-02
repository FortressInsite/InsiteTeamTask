import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { FgbDetailsComponent } from './fgb-details/fgb-details.component';
import { FgbDropdownListComponent } from './fgb-details/fgb-dropdown-list/fgb-dropdown-list.component';
import { FgbDetailComponent } from './fgb-details/fgb-detail/fgb-detail.component';
import { FgbDetailService } from './service/fgb-detail.service';

@NgModule({
  declarations: [
    AppComponent,
    FgbDetailsComponent,
    FgbDropdownListComponent,
    FgbDetailComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(), // ToastrModule added
  ],
  providers: [FgbDetailService],
  bootstrap: [AppComponent]
})
export class AppModule { }
