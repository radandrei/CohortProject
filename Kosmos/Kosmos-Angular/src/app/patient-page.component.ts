import { Component } from '@angular/core';
import { UserService } from './shared/services/user.service';
import { Router } from '@angular/router';
import { User } from './models/user';
import { AllergyService } from './shared/services/allergy.service';
import { Allergy } from './models/allergy';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { ContraindicationService } from './shared/services/contraindication.service';
import { EventService } from './shared/services/event.service';

@Component({
  selector: 'patient',
  templateUrl: './patient-page.component.html',
  styleUrls: ['./patient-page.component.css'],
  providers: [UserService, AllergyService, ContraindicationService, EventService]
})
export class PatientPageComponent {
  idUser = localStorage.getItem('auth_id');
  user = JSON.parse(localStorage.getItem('myUser'));
  allergies;
  contraindications;
  events;

  dateToString(birthDate: Date): string {
    var currentTime = new Date(birthDate);
    var month = currentTime.getMonth();
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();
    var date = day + "." + month + "." + year;
    return date;
  }

  constructor(private userService: UserService, private allergyService: AllergyService, private contraindicationService: ContraindicationService
    , private eventService: EventService, private router: Router) {
    const medicalChartId = this.user.person.medicalChart.id;
    allergyService.getAllergies(medicalChartId)
      .subscribe(allergies => { this.allergies = allergies },
        error => {
          if (error.status == 403)
            this.router.navigateByUrl("login");
        });

    contraindicationService.getContraindications(medicalChartId)
      .subscribe(contraindication => { this.contraindications = contraindication },
        error => {
          if (error.status == 403)
            this.router.navigateByUrl("login");
        });
    eventService.getEvents(medicalChartId).subscribe(events => { this.events = events; },
      error => {
        if (error.status == 403)
          this.router.navigateByUrl("login");
      });
  }


  logout(){
    localStorage.removeItem('auth_token');
    this.router.navigateByUrl("/");
  }



}
