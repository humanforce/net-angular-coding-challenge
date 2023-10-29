import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamCapacityComponent } from './team-capacity.component';

describe('TeamCapacityComponent', () => {
  let component: TeamCapacityComponent;
  let fixture: ComponentFixture<TeamCapacityComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TeamCapacityComponent]
    });
    fixture = TestBed.createComponent(TeamCapacityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
