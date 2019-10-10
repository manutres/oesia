<template>
  <div class="m-4">
    <b-form @keyup.enter="onSubmit()">
      <b-form-group id="input-group-2" label="Your Name:" label-for="input-2">
        <b-form-input id="input-2" v-model="req.Name" required></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-3" label="Your Last Name:" label-for="input-3">
        <b-form-input id="input-3" v-model="req.LastName" required></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-4" label="Your Telf:" label-for="input-4">
        <b-form-input id="input-4" v-model="req.Telf" required></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-1" label="Your Email:" label-for="input-1">
        <b-form-input
          id="input-1"
          type="email"
          v-model="req.Email"
          required
          placeholder="Enter Email"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-5" label="Your Password:" label-for="input-5">
        <b-form-input id="input-5" type="password" v-model="req.Pass" required></b-form-input>
      </b-form-group>
      <b-button @click="onSubmit()" variant="danger">Submit</b-button>
    </b-form>
    <b-card class="mt-3" header="Request result">
      <pre class="m-0">{{ response }}</pre>
    </b-card>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import Axios from "axios";

interface RequestUser {
  Email?: string;
  Name?: string;
  LastName?: string;
  Telf?: number;
  Pass?: string;
}

@Component
export default class UserForm extends Vue {
  private req: RequestUser = {
    Email: undefined,
    Name: undefined,
    LastName: undefined,
    Telf: undefined,
    Pass: undefined
  };
  private response: any = null;
  config = {
    headers: { Authorization: "Bearer " + localStorage.getItem("user") }
  };

  onSubmit() {
    Axios.post("https://localhost:44375/api/users", this.req, this.config).then(
      resp => {
        this.response = resp;
        this.$emit("neweladded", this.response.data);
        this.req = {
          Email: undefined,
          Name: undefined,
          LastName: undefined,
          Telf: undefined,
          Pass: undefined
        };
      }
    );
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
