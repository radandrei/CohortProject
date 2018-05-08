import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from '../utils/config.service';
import { Observable } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { Event } from '../../models/events';
import { HttpClient } from '@angular/common/http';



@Injectable()

export class EventService {

  baseUrl: string = '';
  EventUrl;


  constructor(private http: HttpClient, private configService: ConfigService, private router:Router) {
    this.baseUrl = configService.getApiURI();
    this.EventUrl=this.baseUrl+"/Event";
  }

  extractData(result:Response):Event[]{
    return result.json();
  }


  getEvents(id:number|string): Observable<Event[]> {
    return this.http.get<Event[]>(this.EventUrl+"/getbymedicalchart/"+id);
  }

}

