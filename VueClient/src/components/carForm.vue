<template>
  <div class="m-4">
    <b-form @keyup.enter="onSubmit()">
      <b-form-group id="input-group-1" label="Car Brand:" label-for="input-1">
        <b-form-input id="input-1" v-model="carInput.Brand" required></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Car Model:" label-for="input-2">
        <b-form-input id="input-2" v-model="carInput.Model" required></b-form-input>
      </b-form-group>

      <b-button @click="onSubmit()" variant="danger">Submit</b-button>
    </b-form>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import Car from "@/models/Car";
import CarRepository from "@/CarRepository";

@Component
export default class CarForm extends Vue {
  carInput: Car = new Car();
  carRepository: CarRepository = new CarRepository("https://localhost:44375");

  onSubmit() {
    this.carRepository
      .addCar(localStorage.getItem("user_id")!, this.carInput)
      .then(response => {
        this.$emit("neweladded");
        this.carInput = new Car();
      });
  }
}
</script>

<style scoped>
</style>