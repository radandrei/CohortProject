import { Role } from "./role";
import { Person } from "./person";

export class User{
    id:number;
    username:string;
    role:Role;
    person:Person;
    constructor(id:number,username:string,role:Role,person:Person){}
}