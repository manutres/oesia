export default class Locatino {
  public Latitude: string;
  public Longitude: string;

  constructor(latitude?: string, longitude?: string) {
    this.Latitude = latitude || "";
    this.Longitude = longitude || "";
  }
}
