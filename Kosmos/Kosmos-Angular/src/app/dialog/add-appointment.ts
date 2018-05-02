import { Component } from "@angular/core";
import { AppointmentService } from "../shared/services/appointment.service";
import { MatDialogRef } from "@angular/material";
import { Appointment } from "../models/appointment";


@Component({
    selector: 'add-appointment',
    templateUrl: '/add-appointment.html',
    styleUrls: ['/add-appointment.css'],
    providers:[AppointmentService]
  })
  export class DialogAdd {
  
  
    constructor(public dialogRef: MatDialogRef<DialogAdd>,private appointmentService: AppointmentService) { 
     }
    add(date,notes) {
      var appointment : Appointment=new Appointment();
      if(date =="" || notes == ""){
        alert("The date is not complete! The Appointment was not created.");
        return "error";
      }

      var completeDate:Date=new Date(date);
      if (completeDate<new Date()){
        alert("The appointments was not created.It must take place in the future!");
        return "error";
      }
      var tmz=completeDate.getTimezoneOffset();
      completeDate.setHours( completeDate.getHours() - completeDate.getTimezoneOffset()/(60) );
      console.log(completeDate);
      appointment.date=completeDate;
      appointment.notes=notes;
      appointment.confirm=false;
      this.appointmentService.add(appointment); // the call
      window.location.reload(); 
      alert("Appointmed created!");  
    }
    cancel(){
        ;
    } 
  }