<template>
  <div class="m-4">
    <b-form @keyup.enter="onSubmit()">
      <b-form-group id="input-group-1" label="Latitude:" label-for="input-1">
        <b-form-input id="input-1" v-model="locationInput.Latitude" required></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Longitude:" label-for="input-2">
        <b-form-input id="input-2" v-model="locationInput.Longitude" required></b-form-input>
      </b-form-group>

      <b-button @click="onSubmit()" variant="danger">Submit</b-button>
    </b-form>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import Location from "@/models/Location";
import LocationRepository from "@/LocationRepository";

@Component
export default class LocationForm extends Vue {
  locationInput: Location = new Location();
  locationRepository: LocationRepository = new LocationRepository(
    "https://localhost:44375"
  );

  onSubmit() {
    this.locationRepository
      .addLocation(localStorage.getItem("user_id")!, this.locationInput)
      .then(response => {
        this.$emit("neweladded");
        this.locationInput = new Location();
      });
  }
}
</script>

<style scoped>
</style>