import Car from "@/models/Car";

export default class User {
  public UserId: number;
  public Name: string;
  public LastName: string;
  public Phone: string;
  public Email: string;
  public Pass: string;
  public Cars: Car[];

  constructor(
    userid?: number,
    name?: string,
    lastName?: string,
    phone?: string,
    email?: string,
    pass?: string,
    cars?: Car[]
  ) {
    this.UserId = userid || 0;
    this.Name = name || "";
    this.LastName = lastName || "";
    this.Phone = phone || "";
    this.Email = email || "";
    this.Pass = pass || "";
    this.Cars = cars || [];
  }
}
