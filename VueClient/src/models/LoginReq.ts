export default class LoginReq {
  public Email: string;
  public Pass: string;

  constructor(email?: string, pass?: string) {
    this.Email = email || "";
    this.Pass = pass || "";
  }
}
