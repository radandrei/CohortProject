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
import { PrescriptionService } from '../shared/services/prescription.service';
import { Prescription } from '../models/prescription';


@Component({
  selector: 'patient-prescriptions',
  templateUrl: './patient-prescriptions.component.html',
  styleUrls: ['./patient-prescriptions.component.css'],
  providers:[PrescriptionService],
})

export class PatientPrescriptionsPage {
  displayedColumns = ['date', 'notes', 'diagnosis'];
  database: Database | null;
  dataSource: DataSourcePrescription | null;
  selectedPrescription: number;
  user = JSON.parse(localStorage.getItem('myUser'));

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild('filter') filter: ElementRef;
  @ViewChild(MatSort) sort: MatSort;

  constructor(http: HttpClient, private prescriptionService: PrescriptionService, public dialog: MatDialog, private router:Router) {
    this.database = new Database(http, this.prescriptionService,router);
  }

  openDialog() {

    let dialogRef;
    // dialogRef = this.dialog.open(DialogAdd, { width: '25%', height: '40%' });

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
        alert("You can cancel an prescription only before 24h or more");
        return "error";
      }
      this.prescriptionService.deletePrescription(id);
      window.location.reload();
      alert("Appointmed canceled!");
    }
  }


  ngOnInit() {
    this.dataSource = new DataSourcePrescription(this.database, this.paginator, this.sort);
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

  /** Adds a new Prescription to the database. */
  addPrescriptions(membersToAdd: Array<Prescription>) {
    for (let i = 0; i < membersToAdd.length; i++) {
      const copiedData = this.data.slice();
      copiedData.push(membersToAdd[i]);
      this.dataChange.next(copiedData);
    }
  }

  /** Stream that emits whenever the data has been modified. */
  dataChange: BehaviorSubject<Prescription[]> = new BehaviorSubject<Prescription[]>([]);
  get data(): Prescription[] { return this.dataChange.value; }

  constructor(private http: HttpClient, PrescriptionService: PrescriptionService, private router:Router) {
    this.user = JSON.parse(localStorage.getItem('myUser'));
    let chartId = this.user.person.medicalChart.id;
    PrescriptionService.getPrescriptions(chartId)
      .subscribe(
        prescriptions => { this.addPrescriptions(prescriptions) },
        error => {
          if (error.status == 403)
            this.router.navigateByUrl("login");
            else
            console.log(error.error);
        }
      )
  };

  getPrescription(id: number): Prescription {
    const Prescriptions: Prescription[] = this.data;
    const length: number = Prescriptions.length;
    let i;
    for (i = 0; i < length; i++) {
      if (Prescriptions[i].id == id)
        return Prescriptions[i]
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
export class DataSourcePrescription extends DataSource<any> {
  _filterChange = new BehaviorSubject('');
  get filter(): string { return this._filterChange.value; }
  set filter(filter: string) { this._filterChange.next(filter); }
  constructor(private _database: Database, private _paginator: MatPaginator, private _sort: MatSort) {
    super();
  }
  filterLength: number = this._database.data.length;

  /** Connect function called by the table to retrieve one stream containing the data to render. */
  connect(): Observable<Prescription[]> {
    const displayDataChanges = [
      this._database.dataChange,
      this._paginator.page,
      this._filterChange,
      this._sort.sortChange
    ];

    return Observable.merge(...displayDataChanges).map(() => {
      const startIndex = this._paginator.pageIndex * this._paginator.pageSize;
      const elements = this._database.data.filter((item: Prescription) => {
        let searchStr = (item.notes).toLowerCase()+(item.diagnosis.name);
        return searchStr.indexOf(this.filter.toLowerCase()) != -1;
      });
      this.filterLength = elements.length;
      return this.getSortedData(elements).splice(startIndex, this._paginator.pageSize);
    });
  }

  getSortedData(elements: Prescription[]): Prescription[] {
    const data = elements.slice();
    if (!this._sort.active || this._sort.direction == '') { return data; }

    return data.sort((a, b) => {
      let propertyA: number | string | Date | boolean = '';
      let propertyB: number | string | Date | boolean = '';

      switch (this._sort.active) {
        case 'confirmed': [propertyA, propertyB] = [(a.date), (b.date)]; break;
        case 'date': [propertyA, propertyB] = [(a.diagnosis.name), (b.diagnosis.name)]; break;
        case 'notes': [propertyA, propertyB] = [(a.notes).toLowerCase(), (b.notes).toLowerCase()]; break;
      }

      let valueA = isNaN(+propertyA) ? propertyA : +propertyA;
      let valueB = isNaN(+propertyB) ? propertyB : +propertyB;

      return (valueA < valueB ? -1 : 1) * (this._sort.direction == 'asc' ? 1 : -1);
    });
  }

  disconnect() { }
}
