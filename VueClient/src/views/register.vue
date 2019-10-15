<template>
  <div class="Absolute-Center is-Responsive">
    <b-form @keyup.enter="onSubmit()">
      <b-form-group id="input-group-2" label="Your Name:" label-for="input-2">
        <b-form-input id="input-2" v-model="registerReq.Name" required></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-3" label="Your Last Name:" label-for="input-3">
        <b-form-input id="input-3" v-model="registerReq.LastName" required></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-4" label="Your Telf:" label-for="input-4">
        <b-form-input id="input-4" v-model="registerReq.Telf" required></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-1" label="Your Email:" label-for="input-1">
        <b-form-input
          id="input-1"
          type="email"
          v-model="registerReq.Email"
          required
          placeholder="Enter Email"
        ></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-5" label="Your Password:" label-for="input-5">
        <b-form-input id="input-5" type="password" v-model="registerReq.Pass" required></b-form-input>
      </b-form-group>
      <b-button @click="onSubmit()" variant="danger">Submit</b-button>
    </b-form>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import Axios from "axios";
import RegisterReq from "@/models/RegisterReq";
import AuthService from "@/AuthService";

@Component
export default class Register extends Vue {
  private authService: AuthService = new AuthService("https://localhost:44375");
  private registerReq: RegisterReq = new RegisterReq();

  async onSubmit() {
    this.authService.register(this.registerReq).then(resp => {
      localStorage.setItem("user_token", resp.data.Token);
      localStorage.setItem("user_id", resp.data.UserInfo.UserId);
      this.$emit("loged");
      this.registerReq = new RegisterReq();
    });
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.Absolute-Center {
  margin: auto;
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
}

.Absolute-Center.is-Responsive {
  width: 50%;
  height: 70%;
  min-width: 200px;
  max-width: 600px;
  padding: 40px;
}
</style>
