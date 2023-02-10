/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FilterByGameAndSessionIdModalComponent } from './filterByGameAndSessionIdModal.component';

describe('FilterByGameAndSessionIdModalComponent', () => {
  let component: FilterByGameAndSessionIdModalComponent;
  let fixture: ComponentFixture<FilterByGameAndSessionIdModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FilterByGameAndSessionIdModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FilterByGameAndSessionIdModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
