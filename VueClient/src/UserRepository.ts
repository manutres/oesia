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

  public async getUserCars(): Promise<Car[]> {
    return Axios.get(
      `${this.apiUrl}${this.resourceUrl}/${localStorage.getItem(
        "user_id"
      )}/cars`,
      this.requestConfig
    );
  }

  public async addCar(car: Car) {
    return Axios.post(
      `${this.apiUrl}${this.resourceUrl}/${localStorage.getItem(
        "user_id"
      )}/cars`,
      car,
      this.requestConfig
    );
  }

  public async getUserLocations(): Promise<Location[]> {
    return Axios.get(
      `${this.apiUrl}${this.resourceUrl}/${localStorage.getItem(
        "user_id"
      )}/locations`,
      this.requestConfig
    );
  }

  public async addLocation(location: Location) {
    return Axios.post(
      `${this.apiUrl}${this.resourceUrl}/${localStorage.getItem(
        "user_id"
      )}/locations`,
      location,
      this.requestConfig
    );
  }

  public async getUserRoutes(): Promise<Route[]> {
    return Axios.get(
      `${this.apiUrl}${this.resourceUrl}/${localStorage.getItem(
        "user_id"
      )}/routes`,
      this.requestConfig
    );
  }

  public async addRoute(route: Route) {
    return Axios.post(
      `${this.apiUrl}${this.resourceUrl}/${localStorage.getItem(
        "user_id"
      )}/routes`,
      route,
      this.requestConfig
    );
  }
}
