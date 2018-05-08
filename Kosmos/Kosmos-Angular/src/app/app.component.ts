import { Component } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ConfigService } from './shared/utils/config.service';
import { UserService } from './shared/services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  baseUrl: string = '';

  constructor(private userService: UserService) {
  }

callTest(){
  let x = this.userService.callTest(2005);
  console.log(x);
}

  title = 'app';

}
