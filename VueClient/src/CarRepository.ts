import Axios, { AxiosRequestConfig } from "axios";
import Car from "@/models/Car";
export default class CarRespository {
  private readonly serverUrl: string;
  private readonly resourceUrl: string = "/api/users";
  private readonly requestConfig: AxiosRequestConfig;

  constructor(serverUrl: string) {
    this.serverUrl = serverUrl;
    this.requestConfig = {
      headers: { Authorization: "Bearer " + localStorage.getItem("user_token") }
    };
  }

  public async getAllUserCars(userId: string): Promise<Car[]> {
    return Axios.get(
      `${this.serverUrl}/${this.resourceUrl}/${userId}/cars`,
      this.requestConfig
    );
  }

  public async addCar(userId: string, car: Car): Promise<Car> {
    return Axios.post(
      `${this.serverUrl}/${this.resourceUrl}/${userId}/cars`,
      car,
      this.requestConfig
    );
  }
}
