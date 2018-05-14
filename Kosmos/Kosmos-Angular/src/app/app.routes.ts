import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegistrationFormComponent } from './account/registration-form/registration-form.component';
import { LoginFormComponent } from './account/login-form/login-form.component';
import { PatientPageComponent } from './patient-page.component';
import { PatientAppointmentPage } from './patient-appointments.component';
import { PatientPrescriptionsPage } from './patient-prescriptions/patient-prescriptions.component';
import { AdminPage } from './admin-page/admin-page.component';
import { AdminAppointmentPage } from './admin-appointments/admin-appointments.component';
import {MedicPageComponent} from './medic-page/medic-page.component';
import {DoctorAppointmentsComponent} from './doctor-appointments/doctor-appointments.component';
const appRoutes: Routes = [
  { path: 'register', component: RegistrationFormComponent },
  { path: 'login', component: LoginFormComponent },
  {path:'patient',component:PatientPageComponent},
  {path:'patient-appointment',component:PatientAppointmentPage},
  {path:'patient-prescriptions',component:PatientPrescriptionsPage},
  {path:'admin',component:AdminPage},
  {path:'medic', component:MedicPageComponent},
  {path: 'doctor-appointments', component: DoctorAppointmentsComponent},
  {path:'admin-appointment/:id',component:AdminAppointmentPage},
  {path:"**",component:LoginFormComponent}
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);