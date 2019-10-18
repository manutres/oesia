import Axios, { AxiosRequestConfig } from "axios";
import Car from "@/models/Car";
export default class CarRespository {
  private readonly serverUrl: string;
  private readonly resourceUrl: string = "/api/cars";
  private readonly requestConfig: AxiosRequestConfig;

  constructor(serverUrl: string) {
    this.serverUrl = serverUrl;
    this.requestConfig = {
      headers: { Authorization: "Bearer " + localStorage.getItem("user_token") }
    };
  }

  public async getAll(): Promise<Car[]> {
    return Axios.get(
      `${this.serverUrl}${this.resourceUrl}`,
      this.requestConfig
    );
  }

  public async getById(carId: number): Promise<Car> {
    return Axios.get(
      `${this.serverUrl}${this.resourceUrl}/${carId}`,
      this.requestConfig
    );
  }
}
