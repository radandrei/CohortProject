import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';

import { UserRegistration } from '../models/user.registration.interface';
import { ConfigService } from '../utils/config.service';

import { BaseService } from "./base.service";

import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';
import { User } from '../../models/user';

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

  constructor(private http: Http, private configService: ConfigService) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
    // header component resulting in authed user nav links disappearing despite the fact user is still logged in
    this._authNavStatusSource.next(this.loggedIn);
    this.baseUrl = configService.getApiURI();
    this.userUrl=this.baseUrl+"/user";
  }

  register(username: string, password: string): Observable<UserRegistration> {
    let body = JSON.stringify({ username, password });
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });

    return this.http.post(this.baseUrl + "/Account/Register", body, options)
      .map(res => true)
      .catch(this.handleError);
  }

  tryLogin(username: string, password: string): Promise<boolean> {
    let urlSearchParams = new URLSearchParams();
    urlSearchParams.append('username', username);
    urlSearchParams.append('password', password);
    // let body = urlSearchParams.toString();
    let body=JSON.stringify({ username, password })
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let opt=new RequestOptions({headers:this.headers});
    return this.http.post(this.baseUrl+"/Account/Login", body,{headers})
      .toPromise()
      .then(response =>{ 
        localStorage.setItem('auth_token',JSON.parse(response.text()).auth_token);
        localStorage.setItem('auth_id',JSON.parse(response.text()).id);
       return(response.status==200)})
      .catch(this.failed);

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

  getUser(id:number|string):Promise<User>{
    return this.http.get(this.userUrl+"/getbyid/"+id)
    .toPromise()
    .then(response => response.json() as User)
    .catch(this.handlePromiseError)
  }

}

