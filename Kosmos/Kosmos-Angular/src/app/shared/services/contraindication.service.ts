import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { Contraindication } from '../../models/contraindication';
import { HttpClient } from '@angular/common/http';



@Injectable()

export class ContraindicationService {

  baseUrl: string = '';
  ContraindicationUrl;


  constructor(private http: HttpClient, private configService: ConfigService, private router:Router) {
    this.baseUrl = configService.getApiURI();
    this.ContraindicationUrl=this.baseUrl+"/contraindication";
  }

  extractData(result:Response):Contraindication[]{
    return result.json();
  }


  getContraindications(id:number|string): Observable<Contraindication[]> {
    return this.http.get<Contraindication[]>(this.ContraindicationUrl+"/getbymedicalchart/"+id);
      
  }

}

