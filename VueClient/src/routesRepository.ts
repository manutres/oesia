import Axios, { AxiosRequestConfig } from "axios";
import Location from "@/models/Route";

export default class RoutesRespository {
  private readonly serverUrl: string;
  private readonly resourceUrl: string = "/api/users";
  private readonly requestConfig: AxiosRequestConfig;

  constructor(serverUrl: string) {
    this.serverUrl = serverUrl;
    this.requestConfig = {
      headers: { Authorization: "Bearer " + localStorage.getItem("user_token") }
    };
  }

  public async getAllUserLocations(userId: string): Promise<Location[]> {
    return Axios.get(
      `${this.serverUrl}/${this.resourceUrl}/${userId}/locations`,
      this.requestConfig
    );
  }

  public async addLocation(
    userId: string,
    location: Location
  ): Promise<Location> {
    return Axios.post(
      `${this.serverUrl}/${this.resourceUrl}/${userId}/locations`,
      location,
      this.requestConfig
    );
  }
}
