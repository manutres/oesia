export default class RegisterReq {
  Email: string;
  Name: string;
  LastName: string;
  Telf: string;
  Pass: string;

  constructor(
    email?: string,
    name?: string,
    lastName?: string,
    telf?: string,
    pass?: string
  ) {
    this.Email = email || "";
    this.Name = name || "";
    this.LastName = lastName || "";
    this.Telf = telf || "";
    this.Pass = pass || "";
  }
}
