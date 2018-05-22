import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { Prescription } from '../../models/Prescription';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PrescriptionPlus } from '../../models/prescriptionplus';



@Injectable()

export class PrescriptionService {

  baseUrl: string = '';
  PrescriptionUrl;


  constructor(private http: HttpClient, private configService: ConfigService, private router: Router) {
    this.baseUrl = configService.getApiURI();
    this.PrescriptionUrl = this.baseUrl + "/Prescription";
  }

  extractData(result: Response): Prescription[] {
    return result.json();
  }

  add(body): Observable<Prescription> {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.post<Prescription>(this.PrescriptionUrl + "/add", body, httpOptions);

  }

  loginFailed(error: any): Promise<boolean> {
    return Promise.resolve(false);
  }

  deletePrescription(id) {
    this.http.delete(this.PrescriptionUrl + "/delete/" + id)
      .toPromise()
      .then()
      .catch(this.loginFailed);
  }

  getPrescriptions(id: number | string): Observable<Prescription[]> {
    return this.http.get<Prescription[]>(this.PrescriptionUrl + "/getbymedicalchart/" + id);
  }

  getPrescription(id:number|string):Observable<PrescriptionPlus>{
    return this.http.get<PrescriptionPlus>(this.PrescriptionUrl+"/getbyid/"+id);
  }

}

