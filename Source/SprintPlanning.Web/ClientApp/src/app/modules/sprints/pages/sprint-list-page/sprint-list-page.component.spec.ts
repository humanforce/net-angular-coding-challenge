import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SprintListPageComponent } from './sprint-list-page.component';

describe('SprintListPageComponent', () => {
  let component: SprintListPageComponent;
  let fixture: ComponentFixture<SprintListPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SprintListPageComponent]
    });
    fixture = TestBed.createComponent(SprintListPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
