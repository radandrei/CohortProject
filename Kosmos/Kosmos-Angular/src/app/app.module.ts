import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router'
import { HttpModule, XHRBackend } from '@angular/http';
import {HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { RegistrationFormComponent } from './account/registration-form/registration-form.component';

import { routing } from './app.routes';
import { UserService } from './shared/services/user.service';
import { ConfigService } from './shared/utils/config.service';
import { LoginFormComponent } from './account/login-form/login-form.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { KosmosInterceptor } from './shared/modules/interceptor';
import { PatientPageComponent } from './patient-page.component';
// import {PacientPrescriptionsPage}

import {ReactiveFormsModule} from '@angular/forms';
import {CdkTableModule} from '@angular/cdk/table';


import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';


import {
  MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatDividerModule,
  MatExpansionModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatStepperModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
} from '@angular/material';
import { PatientAppointmentPage } from './patient-appointments.component';
import { DialogAdd } from './dialog/add-appointment';
import { PatientPrescriptionsPage } from './patient-prescriptions/patient-prescriptions.component';
import { AdminPage } from './admin-page/admin-page.component';
import { AdminAppointmentPage } from './admin-appointments/admin-appointments.component';
import { DialogAddMedic } from './dialog/add-medic';

@NgModule({
  exports: [
    CdkTableModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
  ],
})
export class DemoMaterialModule {}

@NgModule({
  declarations: [
    AppComponent,
    RegistrationFormComponent,
    LoginFormComponent,
    PatientPageComponent,
    PatientAppointmentPage,
    DialogAdd,
    DialogAddMedic,
    PatientPrescriptionsPage,
    AdminPage,
    AdminAppointmentPage
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    DemoMaterialModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    FormsModule,
    FormsModule,
    routing,
  ],
  providers: [
    {
        provide:HTTP_INTERCEPTORS,
        useClass:KosmosInterceptor,
        multi:true
    },
    UserService,ConfigService],
  bootstrap: [AppComponent],
  entryComponents: [DialogAdd, DialogAddMedic]
})
export class AppModule { }
