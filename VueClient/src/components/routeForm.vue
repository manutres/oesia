<template>
  <div class="m-4">
    <b-form @keyup.enter="onSubmit()">
      <b-form-group id="input-group-1" label="Select Car:" label-for="input-1">
        <b-form-select id="input-1" v-model="routeInput.CarId" :options="carsOptions"></b-form-select>
      </b-form-group>
      <b-form-group id="input-group-2" label="Start Location:" label-for="input-2">
        <b-form-select
          id="input-2"
          v-model="routeInput.StartLocationId"
          :options="locationsOptions"
        ></b-form-select>
      </b-form-group>
      <b-form-group id="input-group-3" label="Finish Location:" label-for="input-3">
        <b-form-select
          id="input-3"
          v-model="routeInput.FinishLocationId"
          :options="locationsOptions"
        ></b-form-select>
      </b-form-group>

      <b-button @click="onSubmit()" variant="danger">Submit</b-button>
    </b-form>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import Route from "@/models/Route";
import Car from "@/models/Car";
import UserRepository from "@/UserRepository";
import LocationRepository from "@/LocationRepository";

@Component
export default class RouteForm extends Vue {
  routeInput: Route = new Route();
  userRepository: UserRepository = new UserRepository(
    "https://localhost:44375"
  );
  locationRepository: LocationRepository = new LocationRepository(
    "https://localhost:44375"
  );

  options: any = [
    { value: null, text: "Please select an option" },
    { value: "a", text: "This is First option" },
    { value: "b", text: "Selected Option" },
    { value: { C: "3PO" }, text: "This is an option with object value" },
    { value: "d", text: "This one is disabled", disabled: true }
  ];

  carsOptions: any = [];
  locationsOptions: any[] = [];

  private mapCarsOptions(cars: Car[]) {
    cars.forEach(car => {
      this.carsOptions.push({
        value: car.Id,
        text: `${car.Brand} ${car.Model}`
      });
    });
  }

  private mapLocationsOptions(locations: Location[]) {
    locations.forEach(location => {
      this.locationsOptions.push({
        value: location.Id,
        text: `${location.LocationName}`
      });
    });
  }

  fetchCars() {
    this.userRepository
      .getUserCars()
      .then(response => {
        this.mapCarsOptions(response.data);
      })
      .catch(error => {});
  }

  fetchLocations() {
    this.locationRepository
      .getAll()
      .then(response => {
        this.mapLocationsOptions(response);
      })
      .catch(error => {});
  }

  onSubmit() {
    this.userRepository.addRoute(this.routeInput).then(response => {
      this.$emit("neweladded");
      this.routeInput = new Route();
    });
  }

  mounted() {
    this.routeInput.CreatorId = parseInt(localStorage.getItem("user_id"));
    this.fetchCars();
    this.fetchLocations();
  }
}
</script>

<style scoped>
</style>