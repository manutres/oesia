export default class Car {
  public Id: number;
  public Brand: string;
  public Model: string;
  public PropietaryId: number;

  constructor(
    id?: number,
    brand?: string,
    model?: string,
    propietaryId?: number
  ) {
    this.Brand = brand || "";
    this.Model = model || "";
    this.Id = id || 0;
    this.PropietaryId = propietaryId || 0;
  }
}
