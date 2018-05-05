import { Medicine } from "./medicine";
import {Diagnosis } from './diagnosis';

export class Prescription{
    id:number;
    medicine:PrescribedMedicine [];
    diagnosis:Diagnosis;;
}