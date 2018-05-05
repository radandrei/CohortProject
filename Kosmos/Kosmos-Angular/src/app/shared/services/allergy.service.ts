import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { Allergy } from '../../models/allergy';
import { HttpClient } from '@angular/common/http';



@Injectable()

export class AllergyService {

  baseUrl: string = '';
  allergyUrl;


  constructor(private http: HttpClient, private configService: ConfigService, private router: Router) {
    this.baseUrl = configService.getApiURI();
    this.allergyUrl = this.baseUrl + "/allergy";
  }

  getAllergies(id: number | string): Observable<Allergy[]> {
    return this.http.get<Allergy[]>(this.allergyUrl + "/getbymedicalchart/" + id);

  }

}

