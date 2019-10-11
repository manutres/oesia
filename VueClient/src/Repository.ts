import Axios, { AxiosRequestConfig } from "axios";

export default class Respository<T> {
  private readonly resourceUrl: string;
  private readonly requestConfig: AxiosRequestConfig;

  constructor(resourceUrl: string) {
    this.requestConfig = {
      headers: { Authorization: "Bearer " + localStorage.getItem("user") }
    };
    this.resourceUrl = resourceUrl;
  }

  public async getAll(): Promise<T[]> {
    return Axios.get(`${this.resourceUrl}`, this.requestConfig);
  }

  public async getById(resourceId: number): Promise<T> {
    return Axios.get(`${this.resourceUrl}/${resourceId}`, this.requestConfig);
  }

  public async add(resource: T): Promise<T> {
    return Axios.post(`${this.resourceUrl}`, resource, this.requestConfig);
  }
}
