import Axios from "axios";
import User from "@/models/User";
import LoginReq from "./models/LoginReq";
import RegisterReq from "./models/RegisterReq";

export default class UserService {
  private static readonly API_URL = "https://localhost:44375";

  private resources = {
    login: `${UserService.API_URL}/login`,
    register: `${UserService.API_URL}/register`,
    users: `${UserService.API_URL}/api/users`
  };

  private config = {
    headers: { Authorization: "Bearer " + localStorage.getItem("user") }
  };

  public async getUsers(): Promise<User[]> {
    return Axios.get(this.resources["users"], this.config).then(data => {
      return data.data;
    });
  }

  public async loginUser(loginReq: LoginReq): Promise<string> {
    return Axios.post(this.resources["login"], loginReq).then(resp => {
      return resp.data;
    });
  }

  public async registerUser(registerReq: RegisterReq): Promise<string> {
    return Axios.post(this.resources["register"], registerReq).then(resp => {
      return resp.data;
    });
  }
}
