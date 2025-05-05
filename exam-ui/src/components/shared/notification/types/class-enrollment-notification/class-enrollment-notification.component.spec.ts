import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassEnrollmentNotificationComponent } from './class-enrollment-notification.component';

describe('ClassEnrollmentNotificationComponent', () => {
  let component: ClassEnrollmentNotificationComponent;
  let fixture: ComponentFixture<ClassEnrollmentNotificationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClassEnrollmentNotificationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClassEnrollmentNotificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
