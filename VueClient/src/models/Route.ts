export default class Route {
  public Id: number;
  public CreatorId: number;
  public StartLocationId: number;
  public StartName: string;
  public FinishLocationId: number;
  public FinishName: string;
  public CarId: number;
  public Ocupantes: number[];

  constructor(
    id?: number,
    creatorId?: number,
    start?: number,
    startName?: string,
    finish?: number,
    finishName?: string,
    carId?: number,
    ocupantes?: number[]
  ) {
    this.Id = id || 0;
    this.CreatorId = creatorId || 0;
    this.StartLocationId = start || 0;
    this.StartName = startName || "";
    this.FinishLocationId = finish || 0;
    this.FinishName = finishName || "";
    this.CarId = carId || 0;
    this.Ocupantes = ocupantes || [];
  }
}
