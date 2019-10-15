export default class Car {
  public Brand: string;
  public Model: string;

  constructor(brand?: string, model?: string) {
    this.Brand = brand || "";
    this.Model = model || "";
  }
}
