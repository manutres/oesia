import Location from "@/models/Location";
import User from "./User";

export default class Route {
  public Id: number;
  public CreatorId: number;
  public StartLocationId: number;
  public FinishLocationId: number;
  public CarId: number;
  public Ocupantes: number[];

  constructor(
    id?: number,
    creatorId?: number,
    start?: number,
    finish?: number,
    carId?: number,
    ocupantes?: number[]
  ) {
    this.Id = id || 0;
    this.CreatorId = creatorId || 0;
    this.StartLocationId = start || 0;
    this.FinishLocationId = finish || 0;
    this.CarId = carId || 0;
    this.Ocupantes = ocupantes || [];
  }
}
