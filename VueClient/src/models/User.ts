import Car from "@/models/Car";

export default class User {
  public Id: number;
  public Name: string;
  public LastName: string;
  public Email: string;

  constructor(
    userid?: number,
    name?: string,
    lastName?: string,
    phone?: string,
    email?: string,
    pass?: string,
    cars?: Car[]
  ) {
    this.Id = userid || 0;
    this.Name = name || "";
    this.LastName = lastName || "";
    this.Email = email || "";
  }
}
