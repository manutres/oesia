export default class Location {
  public Id: number;
  public LocationName: string;
  public Latitude: string;
  public Longitude: string;

  constructor(
    id?: number,
    locationName?: string,
    latitude?: string,
    longitude?: string
  ) {
    this.Id = id || 0;
    this.LocationName = locationName || "";
    this.Latitude = latitude || "";
    this.Longitude = longitude || "";
  }
}
