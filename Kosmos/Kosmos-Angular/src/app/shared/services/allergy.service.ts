import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { Allergy } from '../../models/allergy';



@Injectable()

export class AllergyService {

  baseUrl: string = '';
  allergyUrl;


  constructor(private http: Http, private configService: ConfigService, private router:Router) {
    this.baseUrl = configService.getApiURI();
    this.allergyUrl=this.baseUrl+"/allergy";
  }

  extractData(result:Response):Allergy[]{
    return result.json();
  }


  getAllergies(id:number|string): Observable<Allergy[]> {
    return this.http.get(this.allergyUrl+"/getbymedicalchart/"+id)
      .map(this.extractData)
      .catch(error =>{
        if(error.status==403)
          this.router.navigateByUrl("login");
        return Observable.throw(new Error(error.status));
      })
  }

}

