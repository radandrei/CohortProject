import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { AdminAppointmentPage } from './admin-appointments.component';


describe('AdminPrescriptionsComponent', () => {
  let component: AdminAppointmentPage;
  let fixture: ComponentFixture<AdminAppointmentPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdminAppointmentPage ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminAppointmentPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
