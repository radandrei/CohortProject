import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { UserService } from '../../shared/services/user.service';
import { UserRegistration } from '../../shared/models/user.registration.interface';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})


export class RegistrationFormComponent implements OnInit {

  errors: string;
  isRequesting: boolean;
  submitted: boolean = false;

  constructor(private userService: UserService, private router: Router) { }


  ngOnInit() {
  }

  registerUser({ value, valid }: { value: UserRegistration, valid: boolean }) {
    this.submitted = true;
    this.isRequesting = true;
    this.errors = '';

    if (valid) {
      this.userService.register(value.username, value.password);
        // .subscribe(
        //   result => {
        //     this.isRequesting = false;
        //     this.router.navigate(['/login'], { queryParams: { brandNew: true, username: value.username } });
        //   },
        //   errors => { this.errors = errors; }
        // );
    }
  }
}