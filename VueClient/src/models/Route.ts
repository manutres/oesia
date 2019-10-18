import Location from "@/models/Location";
import User from "./User";

export default class Route {
  public Id: number;
  public CreatorId: number;
  public Start: Location;
  public Finish: Location;
  public CarId: number;
  public Ocupantes: number[];

  constructor(
    id?: number,
    creatorId?: number,
    start?: Location,
    finish?: Location,
    carId?: number,
    ocupantes?: number[]
  ) {
    this.Id = id || 0;
    this.CreatorId = creatorId || 0;
    this.Start = start || new Location();
    this.Finish = finish || new Location();
    this.CarId = carId || 0;
    this.Ocupantes = ocupantes || [];
  }
}
