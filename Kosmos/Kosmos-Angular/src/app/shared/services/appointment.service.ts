import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { Appointment } from '../../models/Appointment';
import { HttpClient, HttpHeaders } from '@angular/common/http';



@Injectable()

export class AppointmentService {

  baseUrl: string = '';
  AppointmentUrl;


  constructor(private http: HttpClient, private configService: ConfigService, private router: Router) {
    this.baseUrl = configService.getApiURI();
    this.AppointmentUrl = this.baseUrl + "/Appointment";
  }

  extractData(result: Response): Appointment[] {
    return result.json();
  }

  add(body): Observable<Appointment> {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.post<Appointment>(this.AppointmentUrl + "/add", body, httpOptions);

  }

  loginFailed(error: any): Promise<boolean> {
    return Promise.resolve(false);
  }

  deleteAppointment(id) {
    this.http.delete(this.AppointmentUrl + "/delete/" + id)
      .toPromise()
      .then()
      .catch(this.loginFailed);
  }

  getAppointments(id: number | string): Observable<Appointment[]> {
    return this.http.get<Appointment[]>(this.AppointmentUrl + "/getbyperson/" + id);
  }

}

