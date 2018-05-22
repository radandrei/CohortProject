import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PatientPrescriptionsPage } from './patient-prescriptions.component';


describe('PatientPrescriptionsComponent', () => {
  let component: PatientPrescriptionsPage;
  let fixture: ComponentFixture<PatientPrescriptionsPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PatientPrescriptionsPage ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PatientPrescriptionsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
