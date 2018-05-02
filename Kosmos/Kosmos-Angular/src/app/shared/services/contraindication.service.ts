import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { Contraindication } from '../../models/contraindication';



@Injectable()

export class ContraindicationService {

  baseUrl: string = '';
  ContraindicationUrl;


  constructor(private http: Http, private configService: ConfigService, private router:Router) {
    this.baseUrl = configService.getApiURI();
    this.ContraindicationUrl=this.baseUrl+"/contraindication";
  }

  extractData(result:Response):Contraindication[]{
    return result.json();
  }


  getContraindications(id:number|string): Observable<Contraindication[]> {
    return this.http.get(this.ContraindicationUrl+"/getbymedicalchart/"+id)
      .map(this.extractData)
      .catch(error =>{
        if(error.status==403)
          this.router.navigateByUrl("login");
        return Observable.throw(new Error(error.status));
      })
  }

}

