import Axios from "axios";
import LoginReq from "./models/LoginReq";
import RegisterReq from "./models/RegisterReq";

export default class AuthService {
  private readonly authEndpointUrl: string;

  constructor(url: string) {
    this.authEndpointUrl = url;
  }

  public async login(loginReq: LoginReq): Promise<string> {
    return Axios.post(`${this.authEndpointUrl}/login`, loginReq);
  }

  public async register(registerReq: RegisterReq): Promise<string> {
    return Axios.post(`${this.authEndpointUrl}/register`, registerReq);
  }
}
