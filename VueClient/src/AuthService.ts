import Axios from "axios";
import LoginReq from "./models/LoginReq";
import RegisterReq from "./models/RegisterReq";
import sha256 from "js-sha256";

export default class AuthService {
  private readonly authEndpointUrl: string;

  constructor(url: string) {
    this.authEndpointUrl = url;
  }

  public async login(loginReq: LoginReq): Promise<string> {
    return Axios.post(`${this.authEndpointUrl}/login`, new LoginReq(loginReq.Email,sha256(loginReq.Pass)));
  }

  public async register(registerReq: RegisterReq): Promise<string> {
    registerReq.Pass = sha256(registerReq.Pass);
    return Axios.post(`${this.authEndpointUrl}/register`, registerReq);
  }
}
