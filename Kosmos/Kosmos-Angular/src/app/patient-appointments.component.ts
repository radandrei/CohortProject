import { Headers, Http, Response, RequestOptions } from '@angular/http';
import { Component, ViewChild, ElementRef, Inject } from '@angular/core';
import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort } from '@angular/material';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { MatDialog, MatDialogRef } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { MAT_DIALOG_DATA } from '@angular/material';
import { Appointment } from './models/appointment';
import { Data } from '@angular/router/src/config';
import { AppointmentService } from './shared/services/appointment.service';
import { AppointmentSend } from './models/appointmentsend';
import { DialogAdd } from './dialog/add-appointment';
import { ElementSchemaRegistry } from '@angular/compiler';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';





@Component({
  selector: 'patient-appointment',
  styleUrls: ['patient-appointments.component.css'],
  templateUrl: 'patient-appointments.component.html',
  providers: [AppointmentService]
})
export class PatientAppointmentPage {
  displayedColumns = ['date', 'time', 'notes', 'confirmed', 'cancel'];
  database: Database | null;
  dataSource: DataSourceAppointment | null;
  selectedAppointment: number;
  user = JSON.parse(localStorage.getItem('myUser'));

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('filter') filter: ElementRef;
  @ViewChild(MatSort) sort: MatSort;

  constructor(http: HttpClient, private appointmentService: AppointmentService, public dialog: MatDialog, private router:Router) {
    this.database = new Database(http, this.appointmentService,router);
  }

  openDialog() {

    let dialogRef;
    dialogRef = this.dialog.open(DialogAdd, { width: '25%', height: '40%' });

  }

  logout(){
    localStorage.removeItem('auth_token');
    this.router.navigateByUrl("/");
  }

  dateToString(date: Date): string {
    var currentTime = new Date(date);
    var month = currentTime.getMonth();
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();
    var retdate = day + "." + month + "." + year;
    return retdate;
  }

  isConfirmed(resp: boolean) {
    if (resp == true)
      return 'confirmed';
    else
      return 'unconfirmed';
  }

  dateToHour(date: Date): string {
    var currentTime = new Date(date);
    var hour = currentTime.getHours();
    var minutes = currentTime.getMinutes();
    return hour + ":" + minutes;
  }

  daysDifference(d1: Date, d2: Date) {
    var oneDay = 1000 * 60 * 60 * 24;
    var d1t = d1.getTime();
    var d2t = d2.getTime();

    var difference = d1t - d2t;
    return Math.round(difference / oneDay);
  }

  cancelConfirm(id, date) {
    if (confirm("Are you sure to cancel it? ")) {
      var verifyDate: Date = new Date(date);
      if (this.daysDifference(verifyDate, new Date()) < 1) {
        alert("You can cancel an appointment only before 24h or more");
        return "error";
      }
      this.appointmentService.deleteAppointment(id);
      window.location.reload();
      alert("Appointmed canceled!");
    }
  }


  ngOnInit() {
    this.dataSource = new DataSourceAppointment(this.database, this.paginator, this.sort);
    Observable.fromEvent(this.filter.nativeElement, 'keyup')
      .debounceTime(150)
      .distinctUntilChanged()
      .subscribe(() => {
        if (!this.dataSource) { return; }
        this.dataSource.filter = this.filter.nativeElement.value;
      });

  }
}

/** An example database that the data source uses to retrieve data for the table. */
export class Database {
  user = JSON.parse(localStorage.getItem('myUser'));

  /** Adds a new Appointment to the database. */
  addAppointments(membersToAdd: Array<Appointment>) {
    for (let i = 0; i < membersToAdd.length; i++) {
      const copiedData = this.data.slice();
      copiedData.push(membersToAdd[i]);
      this.dataChange.next(copiedData);
    }
  }

  /** Stream that emits whenever the data has been modified. */
  dataChange: BehaviorSubject<Appointment[]> = new BehaviorSubject<Appointment[]>([]);
  get data(): Appointment[] { return this.dataChange.value; }

  constructor(private http: HttpClient, AppointmentService: AppointmentService, private router:Router) {
    this.user = JSON.parse(localStorage.getItem('myUser'));
    AppointmentService.getAppointments(this.user.person.id)
      .subscribe(
        appointments => { this.addAppointments(appointments) },
        error => {
          if (error.status == 403)
            this.router.navigateByUrl("login");
        }
      )
  };

  getAppointment(id: number): Appointment {
    const Appointments: Appointment[] = this.data;
    const length: number = Appointments.length;
    let i;
    for (i = 0; i < length; i++) {
      if (Appointments[i].id == id)
        return Appointments[i]
    }
    return null;
  }

}

/**
 * Data source to provide what data should be rendered in the table. Note that the data source
 * can retrieve its data in any way. In this case, the data source is provided a reference
 * to a common data base, Database. It is not the data source's responsibility to manage
 * the underlying data. Instead, it only needs to take the data and send the table exactly what
 * should be rendered.
 */
export class DataSourceAppointment extends DataSource<any> {
  _filterChange = new BehaviorSubject('');
  get filter(): string { return this._filterChange.value; }
  set filter(filter: string) { this._filterChange.next(filter); }
  constructor(private _database: Database, private _paginator: MatPaginator, private _sort: MatSort) {
    super();
  }
  filterLength: number = this._database.data.length;

  /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<Appointment[]> {
    const displayDataChanges = [
      this._database.dataChange,
      this._paginator.page,
      this._filterChange,
      this._sort.sortChange
    ];

    return Observable.merge(...displayDataChanges).map(() => {
      const startIndex = this._paginator.pageIndex * this._paginator.pageSize;
      const elements = this._database.data.filter((item: Appointment) => {
        let searchStr = (item.notes).toLowerCase();
        return searchStr.indexOf(this.filter.toLowerCase()) != -1;
      });
      this.filterLength = elements.length;
      return this.getSortedData(elements).splice(startIndex, this._paginator.pageSize);
    });
  }

  getSortedData(elements: Appointment[]): Appointment[] {
    const data = elements.slice();
    if (!this._sort.active || this._sort.direction == '') { return data; }

    return data.sort((a, b) => {
      let propertyA: number | string | Date | boolean = '';
      let propertyB: number | string | Date | boolean = '';

      switch (this._sort.active) {
        case 'confirmed': [propertyA, propertyB] = [(a.confirm), (b.confirm)]; break;
        case 'date': [propertyA, propertyB] = [(a.date), (b.date)]; break;
        case 'notes': [propertyA, propertyB] = [(a.notes).toLowerCase(), (b.notes).toLowerCase()]; break;
      }

      let valueA = isNaN(+propertyA) ? propertyA : +propertyA;
      let valueB = isNaN(+propertyB) ? propertyB : +propertyB;

      return (valueA < valueB ? -1 : 1) * (this._sort.direction == 'asc' ? 1 : -1);
    });
  }

  disconnect() { }
}

