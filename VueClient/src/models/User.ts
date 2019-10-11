import Car from "@/models/Car";

export default class User {
  private _userId: number;
  private _name: string;
  private _lastName: string;
  private _phone: string;
  private _email: string;
  private _pass: string;
  private _cars: Car[];

  constructor(
    userid?: number,
    name?: string,
    lastName?: string,
    phone?: string,
    email?: string,
    pass?: string,
    cars?: Car[]
  ) {
    this._userId = userid || 0;
    this._name = name || "";
    this._lastName = lastName || "";
    this._phone = phone || "";
    this._email = email || "";
    this._pass = pass || "";
    this._cars = cars || [];
  }

  get userId() {
    return this._userId;
  }

  get name() {
    return this._name;
  }

  get lastName() {
    return this._lastName;
  }

  get phone() {
    return this._phone;
  }

  get email() {
    return this._email;
  }

  get pass() {
    return this._pass;
  }

  get cars() {
    return this._cars;
  }
}
