import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { Cabinet } from "../models/cabinet";
import { AppointmentService } from "../shared/services/appointment.service";
import { Medic } from "../models/medic";
import { MatDialog } from '@angular/material';
import { PrescriptionService } from "../shared/services/prescription.service";
import { PrescribedMedicine } from "../models/prescribedmedicine";


@Component({
  selector: 'show-prescription',
  templateUrl: '/show-prescription.html',
  styleUrls: ['/show-prescription.css'],
  providers: [PrescriptionService]
})
export class PrescriptionDialog {
  selectedPrescription;
  meds;

  constructor(public dialogRef: MatDialogRef<PrescriptionDialog>, private prescriptionService: PrescriptionService,@Inject(MAT_DIALOG_DATA) public data: any) {
    this.prescriptionService.getPrescription(data.id).subscribe(
      (val) => {this.selectedPrescription = val;this.meds=this.selectedPrescription.prescribedMedicine; console.log(this.meds);
        for(let x in this.meds)
        console.log(x);
    },
      (error) => console.error(error)
    );
  }
  exit(){;}
}