import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublicHolidayComponent } from './public-holiday.component';

describe('PublicHolidayComponent', () => {
  let component: PublicHolidayComponent;
  let fixture: ComponentFixture<PublicHolidayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PublicHolidayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PublicHolidayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
