import { Component } from "@angular/core";
import { MatDialogRef } from "@angular/material";
import { Cabinet } from "../models/cabinet";
import { AppointmentService } from "../shared/services/appointment.service";
import { Medic } from "../models/medic";
import { MatDialog } from '@angular/material';


@Component({
  selector: 'add-medic',
  templateUrl: '/add-medic.html',
  styleUrls: ['/add-medic.css'],
  providers: [AppointmentService]
})
export class DialogAddMedic {
  selectedCabinet: number;
  cabinets: Cabinet[];

  constructor(public dialogRef: MatDialogRef<DialogAddMedic>, private appointmentService: AppointmentService) {
    this.appointmentService.getCabinets().subscribe(
      (val) => this.cabinets = val,
      (error) => console.error(error)
    );
  }

  add(username, password, firstName, lastName) {
    var medic: Medic = new Medic();
    if (username == "" || password == "" || firstName == "" || lastName == "") {
      alert("The fields are not complete! The Medic was not created.");
      return "error";
    }

    medic.username = username;
    medic.password = password;
    medic.firstName = firstName;
    medic.lastName = lastName;
    medic.cabinetId = this.selectedCabinet;
    
    this.appointmentService.addMedic(medic).subscribe(
      response => {
        window.location.reload();
        alert("Medic created!");
      },
      error => {
        alert("Medic creation issue!");
      }

    ); // the call

  }
  cancel() {
    ;
  }
}