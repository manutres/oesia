<template>
  <b-form @keyup.enter="onSubmit()">
    <b-form-group id="input-group-1" label="Car Brand:" label-for="input-1">
      <b-form-input id="input-1" v-model="req.Name" required></b-form-input>
    </b-form-group>

    <b-form-group id="input-group-2" label="Car Model:" label-for="input-2">
      <b-form-input id="input-2" v-model="req.LastName" required></b-form-input>
    </b-form-group>

    <b-button @click="onSubmit()" variant="danger">Submit</b-button>
  </b-form>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import Car from "@/models/Car";

@Component
export default class CarForm extends Vue {
  carInput: Car = new Car();

  onSubmit() {}
}
</script>

<style scoped>
</style>