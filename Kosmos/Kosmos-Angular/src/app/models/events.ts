import { EventType } from "./eventtype";
import { Diagnosis } from "./diagnosis";

export class Event{
    id:number;
    startDate:Date;
    endDate:Date;
    name:string;
    observations:string;
    type:EventType;
    diagnosis:Diagnosis;
}