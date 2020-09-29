import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatChipsModule } from '@angular/material/chips'
import { MatInputModule } from '@angular/material/input'
import { MatListModule } from '@angular/material/list'

import { AttendanceListComponent } from './attendance-list.component';

@NgModule({
  declarations: [AttendanceListComponent],
  imports: [
      CommonModule,

      MatListModule,
      MatInputModule,
      MatChipsModule
  ],
  exports: [AttendanceListComponent]
})
export class AttendanceListModule { }
