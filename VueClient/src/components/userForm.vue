<template>
  <div class="m-4">
    <b-form @keyup.enter="onSubmit()">
      <b-form-group id="input-group-2" label="Your Name:" label-for="input-2">
        <b-form-input id="input-2" v-model="user.Name" required></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-3" label="Your Last Name:" label-for="input-3">
        <b-form-input id="input-3" v-model="user.LastName" required></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-4" label="Your Telf:" label-for="input-4">
        <b-form-input id="input-4" v-model="user.Telf" required></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-1" label="Your Email:" label-for="input-1">
        <b-form-input
          id="input-1"
          type="email"
          v-model="user.Email"
          required
          placeholder="Enter Email"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-5" label="Your Password:" label-for="input-5">
        <b-form-input id="input-5" type="password" v-model="user.Pass" required></b-form-input>
      </b-form-group>
      <b-button @click="onSubmit()" variant="danger">Submit</b-button>
    </b-form>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import Axios from "axios";
import UserRepository from "@/UserRepository";
import User from "@/models/User";

@Component
export default class UserForm extends Vue {
  private user: User = new User();
  private repository: UserRepository = new UserRepository(
    "https://localhost:44375/api/users"
  );

  onSubmit() {
    this.repository.add(this.user).then(response => {
      this.$emit("neweladded");
      this.user = new User();
    });
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>