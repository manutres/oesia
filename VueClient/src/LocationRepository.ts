import Axios, { AxiosRequestConfig } from "axios";
import Car from "@/models/Car";
import User from "@/models/User";

export default class LocationRespository {
  private readonly resourceUrl: string = "/api/users";
  private readonly requestConfig: AxiosRequestConfig;

  constructor() {
    this.requestConfig = {
      headers: { Authorization: "Bearer " + localStorage.getItem("user_token") }
    };
  }

  public async getAllUserCars(user: User): Promise<Car[]> {
    return Axios.get(
      `${this.resourceUrl}/${user.UserId}/meetingpoints`,
      this.requestConfig
    );
  }

  public async addCar(user: User, meetPoint: Location): Promise<Car> {
    return Axios.post(
      `${this.resourceUrl}/${user.UserId}/meetingpoints`,
      meetPoint,
      this.requestConfig
    );
  }
}
