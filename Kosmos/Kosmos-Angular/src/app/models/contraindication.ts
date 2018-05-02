import { Medicine } from "./medicine";

export class Contraindication{
    id:number;
    medicine:Medicine;
    constructor(id:number,medicine:Medicine){}
}