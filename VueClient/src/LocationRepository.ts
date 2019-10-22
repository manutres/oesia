import Axios, { AxiosRequestConfig } from "axios";
import Location from "@/models/Location";
export default class LocationRespository {
  private readonly serverUrl: string;
  private readonly resourceUrl: string = "/api/locations";
  private readonly requestConfig: AxiosRequestConfig;

  constructor(serverUrl: string) {
    this.serverUrl = serverUrl;
    this.requestConfig = {
      headers: { Authorization: "Bearer " + localStorage.getItem("user_token") }
    };
  }

  public async getAll(): Promise<Location[]> {
    return Axios.get(
      `${this.serverUrl}${this.resourceUrl}`,
      this.requestConfig
    ).then(response => {
      return response.data;
    });
  }

  public async getById(locationId: number): Promise<Location> {
    return Axios.get(
      `${this.serverUrl}${this.resourceUrl}/${locationId}`,
      this.requestConfig
    ).then(response => {
      return response.data;
    });
  }
}
