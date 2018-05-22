import { Headers, Http, Response, RequestOptions } from '@angular/http';
import { Component, ViewChild, ElementRef, Inject } from '@angular/core';
import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort, MatDateFormats } from '@angular/material';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { MatDialog, MatDialogRef } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/observable/merge';
import 'rxjs/add/operator/map';
import { MAT_DIALOG_DATA } from '@angular/material';

import { Data } from '@angular/router/src/config';

import { ElementSchemaRegistry } from '@angular/compiler';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AppointmentService } from '../shared/services/appointment.service';
import { DialogAdd } from '../dialog/add-appointment';
import { Appointment } from '../models/appointment';
import { ActivatedRoute } from '@angular/router';
import { Params } from '@angular/router';
import { AfterViewInit } from '@angular/core';





@Component({
  selector: 'admin-appointment',
  styleUrls: ['admin-appointments.component.css'],
  templateUrl: 'admin-appointments.component.html',
  providers: [AppointmentService]
})
export class AdminAppointmentPage {
  displayedColumns = ['date', 'time', 'notes'];
  database: Database | null;
  dataSource: DataSourceAppointment | null;
  selectedAppointment: number;
  user = JSON.parse(localStorage.getItem('myUser'));

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('filter') filter: ElementRef;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('dateStart') dateStart:ElementRef;
  @ViewChild('dateEnd') dateEnd:ElementRef;


  constructor(http: HttpClient, private appointmentService: AppointmentService, public dialog: MatDialog, private router:Router,private activatedRoute: ActivatedRoute) {
    this.database = new Database(http, this.appointmentService,router,activatedRoute);
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
    var retdate = day + "." + (month+1) + "." + year;
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

  setStartDate(date){
      this.dataSource.dateStart=date.value;
  }

  setEndDate(date){
    this.dataSource.dateEnd=date.value;
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

  constructor(private http: HttpClient, AppointmentService: AppointmentService, private router:Router,private activatedRoute: ActivatedRoute) {
      this.activatedRoute.params.subscribe((params: Params) => {
        let personId = params['id'];
        console.log(personId);
        AppointmentService.getAllAppointments(personId)
      .subscribe(
        appointments => { this.addAppointments(appointments) },
        error => {
          if (error.status == 403)
            this.router.navigateByUrl("login");
        }
      )
      });
    
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
  _dateStartChange = new BehaviorSubject(null);
  _dateEndChange = new BehaviorSubject(null);

  get filter(): string { return this._filterChange.value; }
  set filter(filter: string) { this._filterChange.next(filter); }

  get dateStart(): Date { return this._dateStartChange.value; }
  set dateStart(date: Date) { this._dateStartChange.next(date); }

  get dateEnd(): Date { return this._dateEndChange.value; }
  set dateEnd(date: Date) { this._dateEndChange.next(date); }

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
      this._sort.sortChange,
      this._dateStartChange,
      this._dateEndChange
    ];

    return Observable.merge(...displayDataChanges).map(() => {
      const startIndex = this._paginator.pageIndex * this._paginator.pageSize;
      const elements = this._database.data.filter((item: Appointment) => {
        let searchStr = (item.notes).toLowerCase();

        

        let boolStart;
        let boolEnd;

        let date=new Date(item.date);
        console.log(date);
        console.log(item.date);

        if(this.dateStart==null)
          boolStart=true;
        else{
          if(this.dateStart.getTime()<=date.getTime())
            boolStart=true;
          else
            boolStart=false;
        }


        if(this.dateEnd==null)
            boolEnd=true;
          else{
            if(this.dateEnd.getTime()>=date.getTime())
              boolEnd=true;
            else
              boolEnd=false;
          }
      
        
        return (searchStr.indexOf(this.filter.toLowerCase()) != -1 && boolStart&&boolEnd);
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
        case 'date': [propertyA, propertyB] = [(new Date(a.date).getTime()), (new Date(b.date).getTime())]; break;
        case 'notes': [propertyA, propertyB] = [(a.notes).toLowerCase(), (b.notes).toLowerCase()]; break;
      }

      let valueA = isNaN(+propertyA) ? propertyA : +propertyA;
      let valueB = isNaN(+propertyB) ? propertyB : +propertyB;

      return (valueA < valueB ? -1 : 1) * (this._sort.direction == 'asc' ? 1 : -1);
    });
  }

  disconnect() { }
}