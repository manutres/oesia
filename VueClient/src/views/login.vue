<template>
  <div class="Absolute-Center is-Responsive">
    <b-form @keyup.enter="onSubmit()">
      <b-form-group id="input-group-1" label="Email:" label-for="input-email">
        <b-form-input type="email" v-model="req.Email" required placeholder="Enter your email"></b-form-input>
      </b-form-group>

      <b-form-group id="input-group-2" label="Password:" label-for="input-2">
        <b-form-input id="input-2" type="password" v-model="req.Pass" required></b-form-input>
      </b-form-group>

      <b-button @click="onSubmit()" variant="danger">Submit</b-button>
    </b-form>
    <b-alert class="my-3" v-show="badLogin" variant="danger" show>NOOOOOOOOOOO</b-alert>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import Axios from "axios";
import BadLogin from "@/components/badLogin.vue";
import LoginReq from "@/models/LoginReq";
import AuthService from "@/AuthService";

@Component({
  components: {
    BadLogin
  }
})
export default class Login extends Vue {
  private badLogin: boolean = false;
  private req: LoginReq = new LoginReq();
  private authService: AuthService = new AuthService("https://localhost:44375");

  onSubmit() {
    this.authService
      .login(this.req)
      .then(resp => {
        localStorage.setItem("user", resp.data);
        this.$emit("loged");
        this.req = new LoginReq();
      })
      .catch(error => {
        this.badLogin = !this.badLogin;
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
  height: 50%;
  min-width: 200px;
  max-width: 600px;
  padding: 40px;
}
</style>
