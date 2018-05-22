import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from './shared/utils/config.service';
import { UserService } from './shared/services/user.service';
import { Router } from '@angular/router';
import { CommunicationService } from './shared/services/communication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers:[CommunicationService]
})

export class AppComponent {
  title = 'app';
  isAuthenticated;
  constructor(private router: Router, private communicationService:CommunicationService){
    communicationService.notify$.subscribe(()=>{
      console.log('semnal primit');
    });
  }
  changeOfRoutes(){
    this.isAuthenticated = localStorage.getItem("auth_token") ? true: false;
  }
  logout(){
    localStorage.removeItem('auth_token');
    this.router.navigateByUrl("/");
  }
}