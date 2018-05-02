import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule }  from '@angular/forms';
 
import { UserService }  from '../shared/services/user.service';

import { routing }  from './account.routing';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { LoginFormComponent } from './login-form/login-form.component';


@NgModule({
  imports: [
    CommonModule,FormsModule,routing
  ],
  declarations: [RegistrationFormComponent, LoginFormComponent],
  providers:    [ UserService ]
})
export class AccountModule { }
