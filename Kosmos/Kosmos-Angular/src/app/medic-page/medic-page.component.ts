import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-medic-page',
  templateUrl: './medic-page.component.html',
  styleUrls: ['./medic-page.component.css']
})
export class MedicPageComponent implements OnInit {
  
  idUser = localStorage.getItem('auth_id');
  user = JSON.parse(localStorage.getItem('myUser'));
  patients;
  constructor() { }

  ngOnInit() {
  }

  dateToString(birthDate: Date): string {
    var currentTime = new Date(birthDate);
    var month = currentTime.getMonth();
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();
    var date = day + "." + month + "." + year;
    return date;
  }

  getAppointments(){
    console.log('get appointments')
  }

}
