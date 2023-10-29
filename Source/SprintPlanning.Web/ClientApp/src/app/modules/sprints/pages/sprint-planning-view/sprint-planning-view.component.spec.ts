import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SprintPlanningViewComponent } from './sprint-planning-view.component';

describe('SprintPlanningViewComponent', () => {
  let component: SprintPlanningViewComponent;
  let fixture: ComponentFixture<SprintPlanningViewComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SprintPlanningViewComponent]
    });
    fixture = TestBed.createComponent(SprintPlanningViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
