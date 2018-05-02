import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RegistrationFormComponent } from './account/registration-form/registration-form.component';
import { LoginFormComponent } from './account/login-form/login-form.component';
import { PatientPageComponent } from './patient-page.component';
import { PatientAppointmentPage } from './patient-appointments.component';

const appRoutes: Routes = [
  { path: 'register', component: RegistrationFormComponent },
  { path: 'login', component: LoginFormComponent },
  {path:'patient',component:PatientPageComponent},
  {path:'patient-appointment',component:PatientAppointmentPage},
  {path:"**",component:LoginFormComponent}
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);