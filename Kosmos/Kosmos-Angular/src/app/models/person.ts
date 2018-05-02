import { User } from "./user";
import { PersonalData } from "./personaldata";
import { MedicalData } from "./medicaldata";
import { Cabinet } from "./cabinet";
import { MedicalChart } from "./medicalchart";

export class Person{
    id:number;
    firstName:string;
    lastName:string;
    active:boolean;
    medicalChart:MedicalChart;
    cabinet:Cabinet;
    personalData:PersonalData;
}