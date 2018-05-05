import { Medicine } from "./medicine";
import {Prescription } from './prescription';

export class PrescribedMedicine{
    id:number;
    medicine:Medicine;
    prescription:Prescription;
    constuctor(id:number,medicine:Medicine,prescription:Prescription){
    }
}