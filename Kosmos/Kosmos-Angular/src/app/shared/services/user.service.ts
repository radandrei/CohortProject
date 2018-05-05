import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { UserRegistration } from '../models/user.registration.interface';
import { ConfigService } from '../utils/config.service';
import { LoginModel } from '../utils/login-model';

import { BaseService } from "./base.service";

import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';
import { User } from '../../models/user';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators/catchError';

//  Add the RxJS Observable operators we need in this app.
// import '../../rxjs-operators';

@Injectable()

export class UserService extends BaseService {

  baseUrl: string = '';
  userUrl;

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();
  private headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });

  private loggedIn = false;

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
    // header component resulting in authed user nav links disappearing despite the fact user is still logged in
    this._authNavStatusSource.next(this.loggedIn);
    this.baseUrl = configService.getApiURI();
    this.userUrl = this.baseUrl + "/user";
  }

  register(username: string, password: string){
    let body = JSON.stringify({ username, password });

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }

   this.http.post<string>(this.baseUrl + "/Account/Register", body, httpOptions).subscribe(
    (val)=> {
      console.log("Response: ", val);
    },
    error=>{
      this.handleError;
    },
    ()=>{
      console.log("Post call completed");
    });
 
  }

  tryLogin(username: string, password: string): Observable<LoginModel> {
    let urlSearchParams = new URLSearchParams();
    urlSearchParams.append('username', username);
    urlSearchParams.append('password', password);
    // let body = urlSearchParams.toString();
    let body = JSON.stringify({ username, password });

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.post<LoginModel>(this.baseUrl + "/Account/Login", body, httpOptions);
      
  }

  callTest(id:number) : Observable<boolean>{
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
 
    return this.http.post<boolean>(this.baseUrl + '/Account/TestLogin', id, httpOptions);
  }


  tryLogOut() {
    localStorage.removeItem('auth_token');
  }

  private failed(error: any): Promise<boolean> {
    return Promise.resolve(false);
  }


  isLoggedIn() {
    return this.loggedIn;
  }


  private handlePromiseError(error: any): Promise<any> {
    console.log(error.status);
    //if(error.status="403")
    return null;
  }

  getUser(id: number | string): Promise<User> {
    return this.http.get<User>(this.userUrl + "/getbyid/" + id)
      .toPromise()
      .then(response => response )
      .catch(this.handlePromiseError)
  }

}

