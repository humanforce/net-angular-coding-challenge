import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SprintComponent } from './sprint.component';

describe('SprintComponent', () => {
  let component: SprintComponent;
  let fixture: ComponentFixture<SprintComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SprintComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SprintComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
}); 
