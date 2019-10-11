export default class Car {
  private _brand: string;
  private _model: string;

  constructor(brand?: string, model?: string) {
    this._brand = brand || "";
    this._model = model || "";
  }

  get brand() {
    return this._brand;
  }
  set brand(brand: string) {
    this._brand = brand;
  }

  get model() {
    return this._model;
  }
  set model(model: string) {
    this._model = model;
  }
}
