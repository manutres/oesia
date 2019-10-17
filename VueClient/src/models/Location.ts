export default class Location {
  public Id: number;
  public Latitude: string;
  public Longitude: string;

  constructor(id?: number, latitude?: string, longitude?: string) {
    this.Id = id || 0;
    this.Latitude = latitude || "";
    this.Longitude = longitude || "";
  }
}
