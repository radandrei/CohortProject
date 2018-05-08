import { Medicine } from "./medicine";
import { Diagnosis } from './diagnosis';
import { PrescribedMedicine } from './prescribedmedicine';

export class Prescription {
    id: number;
    prescribedMedicine: PrescribedMedicine[];
    diagnosis: Diagnosis;
    notes:string;
    date:Date;
}