import Axios, { AxiosRequestConfig } from "axios";
import Route from "@/models/Route";
export default class RouteRespository {
  private readonly serverUrl: string;
  private readonly resourceUrl: string = "/api/routes";
  private readonly requestConfig: AxiosRequestConfig;

  constructor(serverUrl: string) {
    this.serverUrl = serverUrl;
    this.requestConfig = {
      headers: { Authorization: "Bearer " + localStorage.getItem("user_token") }
    };
  }

  public async getAll(): Promise<Route[]> {
    return Axios.get(
      `${this.serverUrl}${this.resourceUrl}`,
      this.requestConfig
    ).then(response => {
      return response.data;
    });
  }

  public async getById(routeId: number): Promise<Route> {
    return Axios.get(
      `${this.serverUrl}${this.resourceUrl}/${routeId}`,
      this.requestConfig
    );
  }
}
