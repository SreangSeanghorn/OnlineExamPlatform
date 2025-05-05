import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignmentDueNotificationComponent } from './assignment-due-notification.component';

describe('AssignmentDueNotificationComponent', () => {
  let component: AssignmentDueNotificationComponent;
  let fixture: ComponentFixture<AssignmentDueNotificationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AssignmentDueNotificationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssignmentDueNotificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
