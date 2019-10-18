export default class User {
  public Id: number;
  public Name: string;
  public LastName: string;
  public Email: string;

  constructor(
    userid?: number,
    name?: string,
    lastName?: string,
    email?: string
  ) {
    this.Id = userid || 0;
    this.Name = name || "";
    this.LastName = lastName || "";
    this.Email = email || "";
  }
}
