import { Injectable } from '@angular/core';
import {
    HttpEvent, HttpInterceptor, HttpHandler, HttpRequest
} from '@angular/common/http';

import { Observable } from 'rxjs/Observable';


@Injectable()
export class KosmosInterceptor implements HttpInterceptor {

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        if (localStorage.getItem('auth_token') !== null) {
            let authToken = localStorage.getItem('auth_token');

            req = req.clone({
                setHeaders: {
                    Authorization: `Bearer ${authToken}`
                }
            });

        }
        return next.handle(req);
    }
}