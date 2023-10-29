import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublicHolidayListComponent } from './public-holiday-list.component';

describe('PublicHolidayListComponent', () => {
  let component: PublicHolidayListComponent;
  let fixture: ComponentFixture<PublicHolidayListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PublicHolidayListComponent]
    });
    fixture = TestBed.createComponent(PublicHolidayListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
