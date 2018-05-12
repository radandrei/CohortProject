import { Component } from "@angular/core";
import { MatDialogRef } from "@angular/material";
import { Cabinet } from "../models/cabinet";
import { AppointmentService } from "../shared/services/appointment.service";
import { Medic  } from "../models/medic";


@Component({
  selector: 'add-cabinet',
  templateUrl: '/add-cabinet.html',
  styleUrls: ['/add-cabinet.css'],
  providers: [AppointmentService]
})
export class DialogAdd {
selectedCabinet:Cabinet;
cabinets: Cabinet[];

  constructor(public dialogRef: MatDialogRef<DialogAdd>, private appointmentService: AppointmentService) {
  this.appointmentService.getCabinets().subscribe(
      (val)=>this.cabinets=val,
      (error)=> console.error(error)
  );
}
  add(username, password,firstName,lastName) {
    var medic: Medic = new Medic();
    if (username == "" || password == "" || firstName == "" || lastName == "") {
      alert("The fields are not complete! The Medic was not created.");
      return "error";
    }

    medic.username = username;
    medic.password  = password;
    medic.firstName  = firstName;
    medic.lastName  = lastName;
    medic.cabinetId=this.selectedCabinet.id;
    
    this.appointmentService.addMedic(medic).subscribe(
      response=>{
        window.location.reload();
        alert("Medic created!");
      },
      error=>{
        alert("Medic creation issue!");
      }

    ); // the call
    
  }
  cancel() {
    ;
  }
}