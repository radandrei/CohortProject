import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { Appointment } from '../../models/Appointment';



@Injectable()

export class AppointmentService {

  baseUrl: string = '';
  AppointmentUrl;


  constructor(private http: Http, private configService: ConfigService, private router:Router) {
    this.baseUrl = configService.getApiURI();
    this.AppointmentUrl=this.baseUrl+"/Appointment";
  }

  extractData(result:Response):Appointment[]{
    return result.json();
  }

  add(body){
    {
      this.http.post(this.AppointmentUrl+"/add",body)
      .toPromise()
      .then(response => (response.status == 200))
      .catch(this.loginFailed);
  }
  }

  loginFailed(error: any): Promise<boolean> {
    return Promise.resolve(false);
  }

  deleteAppointment(id){
    this.http.delete(this.AppointmentUrl+"/delete/"+id)
    .toPromise()
    .then(response=>(response.status==200))
    .catch(this.loginFailed);
  }

  getAppointments(id:number|string): Observable<Appointment[]> {
    return this.http.get(this.AppointmentUrl+"/getbyperson/"+id)
      .map(this.extractData)
      .catch(error =>{
        if(error.status==403)
          this.router.navigateByUrl("login");
        return Observable.throw(new Error(error.status));
      })
  }

}

