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
import { Data } from '@angular/router/src/config';
import { ElementSchemaRegistry } from '@angular/compiler';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserService } from '../shared/services/user.service';
import { User } from '../models/user';
import { DialogPatientDetails } from '../dialog/patient-details';

@Component({
  selector: 'app-medic-page',
  templateUrl: './medic-page.component.html',
  styleUrls: ['./medic-page.component.css']
})
export class MedicPageComponent {
  
  displayedColumns = ['firstName', 'lastName', 'roleName','actions'];
  database: Database | null;
  dataSource: DataSourceUser | null;
  selectedUser: number;
  user = JSON.parse(localStorage.getItem('myUser'));
 

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('filter') filter: ElementRef;
  @ViewChild(MatSort) sort: MatSort;

  constructor(http: HttpClient, private UserService: UserService, public dialog: MatDialog, private router:Router) {
    this.database = new Database(http, this.UserService,router);
  }

  viewPatientDetails(patientId, firstName, lastName, medicalChartId){
    this.openDialog(patientId, firstName, lastName, medicalChartId);
  }

  openDialog(patientId, firstName, lastName,medicalChartId) {

    let dialogRef;
    dialogRef = this.dialog.open(DialogPatientDetails, {data: {
      patientId: patientId,
      firstName : firstName,
      lastName: lastName,
      medicalChartId:medicalChartId
    }, width: '50%', height: '40%' });

  }

  dateToString(date: Date): string {
    var currentTime = new Date(date);
    var month = currentTime.getMonth();
    var day = currentTime.getDate();
    var year = currentTime.getFullYear();
    var retdate = day + "." + month + "." + year;
    return retdate;
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


  isDoctor(role){
    return (role=='Doctor');
  }

  isPatient(role){
    return (role=='Patient');
  }

  ngOnInit() {
    this.dataSource = new DataSourceUser(this.database, this.paginator, this.sort);
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

  /** Adds a new User to the database. */
  addUsers(membersToAdd: Array<User>) {
    for (let i = 0; i < membersToAdd.length; i++) {
      const copiedData = this.data.slice();
      copiedData.push(membersToAdd[i]);
      this.dataChange.next(copiedData);
    }
  }

  /** Stream that emits whenever the data has been modified. */
  dataChange: BehaviorSubject<User[]> = new BehaviorSubject<User[]>([]);
  get data(): User[] { return this.dataChange.value; }

  constructor(private http: HttpClient, UserService: UserService, private router:Router) {
    this.user = JSON.parse(localStorage.getItem('myUser'));
    UserService.getPatients(this.user.id)
      .subscribe(
        Users => { this.addUsers(Users) },
        error => {
          if (error.status == 403)
            this.router.navigateByUrl("login");
        }
      )
  };

  getUser(id: number): User {
    const Users: User[] = this.data;
    const length: number = Users.length;
    let i;
    for (i = 0; i < length; i++) {
      if (Users[i].id == id)
        return Users[i]
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
export class DataSourceUser extends DataSource<any> {
  _filterChange = new BehaviorSubject('');
  get filter(): string { return this._filterChange.value; }
  set filter(filter: string) { this._filterChange.next(filter); }
  constructor(private _database: Database, private _paginator: MatPaginator, private _sort: MatSort) {
    super();
  }
  filterLength: number = this._database.data.length;

  /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<User[]> {
    const displayDataChanges = [
      this._database.dataChange,
      this._paginator.page,
      this._filterChange,
      this._sort.sortChange
    ];

    return Observable.merge(...displayDataChanges).map(() => {
      const startIndex = this._paginator.pageIndex * this._paginator.pageSize;
      const elements = this._database.data.filter((item: User) => {
        let searchStr = (item.person.firstName+item.person.lastName+item.role.name).toLowerCase();
        return searchStr.indexOf(this.filter.toLowerCase()) != -1;
      });
      this.filterLength = elements.length;
      return this.getSortedData(elements).splice(startIndex, this._paginator.pageSize);
    });
  }

  getSortedData(elements: User[]): User[] {
    const data = elements.slice();
    if (!this._sort.active || this._sort.direction == '') { return data; }

    return data.sort((a, b) => {
      let propertyA: number | string | Date | boolean = '';
      let propertyB: number | string | Date | boolean = '';

      switch (this._sort.active) {
        case 'firstName': [propertyA, propertyB] = [(a.person.firstName), (b.person.firstName)]; break;
        case 'lastName': [propertyA, propertyB] = [(a.person.lastName), (b.person.lastName)]; break;
        case 'roleName': [propertyA, propertyB] = [(a.role.name).toLowerCase(), (b.role.name).toLowerCase()]; break;
      }

      let valueA = isNaN(+propertyA) ? propertyA : +propertyA;
      let valueB = isNaN(+propertyB) ? propertyB : +propertyB;

      return (valueA < valueB ? -1 : 1) * (this._sort.direction == 'asc' ? 1 : -1);
    });
  }

  disconnect() { }
}
