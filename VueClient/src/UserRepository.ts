import Axios, { AxiosRequestConfig } from "axios";
import User from "./models/User";
import Car from "./models/Car";
import Location from "./models/Location";
import Route from "./models/Route";

export default class UserRespository {
  private readonly apiUrl: string;
  private readonly resourceUrl: string = "/api/users";
  private readonly requestConfig: AxiosRequestConfig;

  constructor(apiUrl: string) {
    this.requestConfig = {
      headers: { Authorization: "Bearer " + localStorage.getItem("user_token") }
    };
    this.apiUrl = apiUrl;
  }

  public async getAll(): Promise<User[]> {
    return Axios.get(`${this.apiUrl}${this.resourceUrl}`, this.requestConfig);
  }

  public async getById(userId: number): Promise<User> {
    return Axios.get(
      `${this.apiUrl}${this.resourceUrl}/${userId}`,
      this.requestConfig
    );
  }

  public async add(user: User): Promise<User> {
    return Axios.post(
      `${this.apiUrl}${this.resourceUrl}`,
      user,
      this.requestConfig
    );
  }

  public async getUserCars(userId: number): Promise<Car[]> {
    return Axios.get(
      `${this.apiUrl}${this.resourceUrl}/${userId}/cars`,
      this.requestConfig
    );
  }
  public async getUserLocations(userId: number): Promise<Location[]> {
    return Axios.get(
      `${this.apiUrl}${this.resourceUrl}/${userId}/locations`,
      this.requestConfig
    );
  }
  public async getUserRoutes(userId: number): Promise<Route[]> {
    return Axios.get(
      `${this.apiUrl}${this.resourceUrl}/${userId}/routes`,
      this.requestConfig
    );
  }
}
