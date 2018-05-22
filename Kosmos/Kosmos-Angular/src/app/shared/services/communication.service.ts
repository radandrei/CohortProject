import { Injectable } from '@angular/core';
import { Subject }    from 'rxjs';
 
@Injectable()
export class CommunicationService {
 
  // Observable string sources
  private notifySource = new Subject<string>();
 
  // Observable string streams
  notify$ = this.notifySource.asObservable();
 
  // Service notify command
  notify() {
    this.notifySource.next();
  }

}