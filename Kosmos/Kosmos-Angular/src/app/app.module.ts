import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router'
import { HttpModule, XHRBackend } from '@angular/http';

import { AppComponent } from './app.component';
import { RegistrationFormComponent } from './account/registration-form/registration-form.component';

import { routing } from './app.routes';
import { UserService } from './shared/services/user.service';
import { ConfigService } from './shared/utils/config.service';
import { LoginFormComponent } from './account/login-form/login-form.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { KosmosInterceptor } from './shared/modules/interceptor';


@NgModule({
  declarations: [
    AppComponent,
    RegistrationFormComponent,
    LoginFormComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
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
  bootstrap: [AppComponent]
})
export class AppModule { }
