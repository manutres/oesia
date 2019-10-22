<template>
  <div class="m-4">
    <b-form @keyup.enter="onSubmit()">
      <b-form-group id="input-group-3" label="Location Name:" label-for="input-3">
        <b-form-input id="input-3" v-model="locationInput.LocationName" required></b-form-input>
      </b-form-group>

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
import { Component, Prop, Vue } from "vue-property-decorator";
import Location from "@/models/Location";
import UserRespository from "../UserRepository";

@Component
export default class LocationForm extends Vue {
  @Prop() locationInput: Location = new Location();
  userRepository: UserRespository = new UserRespository(
    "https://localhost:44375"
  );

  onSubmit() {
    this.userRepository.addLocation(this.locationInput).then(response => {
      this.$emit("neweladded");
      this.locationInput = new Location();
    });
  }
}
</script>

<style scoped>
</style>