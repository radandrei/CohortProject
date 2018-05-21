import { Component, Inject } from "@angular/core";
import { MatDialogRef } from "@angular/material";
import { Cabinet } from "../models/cabinet";
import { AppointmentService } from "../shared/services/appointment.service";
import { Medic } from "../models/medic";
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { UserService } from "../shared/services/user.service";
import { EventService } from "../shared/services/event.service";
import { Router } from "@angular/router";
import { ContraindicationService } from "../shared/services/contraindication.service";
import { AllergyService } from "../shared/services/allergy.service";

@Component({
  selector: 'patient-details',
  templateUrl: '/patient-details.html',
  styleUrls: ['/patient-details.css'],
  providers: [UserService, AllergyService, ContraindicationService, EventService]
})
export class DialogPatientDetails {
 
  patientId;
  firstName;
  lastName;
  allergies;
  contraindications;
  events;
  constructor(@Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<DialogPatientDetails>, private userService: UserService, private allergyService: AllergyService, private contraindicationService: ContraindicationService
  , private eventService: EventService, private router: Router) {
    this.patientId = data.patientId;
    this.firstName = data.firstName;
    this.lastName = data.lastName;
    let medicalChartId = data.medicalChartId;
    allergyService.getAllergies(medicalChartId)
      .subscribe(allergies => { this.allergies = allergies });

    contraindicationService.getContraindications(medicalChartId)
      .subscribe(contraindication => { this.contraindications = contraindication });
    eventService.getEvents(medicalChartId).subscribe(events => { this.events = events; });
  }
}