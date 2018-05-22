import { Medicine } from "./medicine";
import { Diagnosis } from './diagnosis';
import { PrescribedMedicine } from './prescribedmedicine';
import { PrescribedMedicineMinus } from "./prescribedMedicineMinus";

export class PrescriptionPlus {
    id: number;
    diagnosis: Diagnosis;
    prescribedMedicine: PrescribedMedicineMinus[];
    notes:string;
    date:Date;
}