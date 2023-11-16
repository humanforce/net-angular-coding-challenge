import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamVelocityComponent } from './team-velocity.component';

describe('TeamVelocityComponent', () => {
  let component: TeamVelocityComponent;
  let fixture: ComponentFixture<TeamVelocityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeamVelocityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeamVelocityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
