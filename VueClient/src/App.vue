<template>
<b-container id="app" fluid>
  <html>
    <head>
      <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    </head>
    <body>
      <div id="nav">
        <b-navbar toggleable="lg" type="dark" variant="secondary">
          <b-navbar-brand :to="{ name : 'home' }">EZCar</b-navbar-brand>

          <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

          <b-collapse id="nav-collapse" is-nav>
            <b-navbar-nav v-if="authenticated">
              <b-nav-item @click="deauthenticate()">Log Out</b-nav-item>
            </b-navbar-nav>
            <b-navbar-nav v-else>
              <b-nav-item :to="{ name : 'login' }">Login</b-nav-item>
              <b-nav-item :to="{ name : 'register' }">Register</b-nav-item>
            </b-navbar-nav>
          </b-collapse>
        </b-navbar>
      </div>
      <router-view @loged="setAuthenticated()" :key="renderViews" :item="item" />
    </body>
  </html>
</b-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";

@Component
export default class App extends Vue {
  public authenticated: boolean = false;
  private renderViews: number = 0;

  public setAuthenticated() {
    if (localStorage.getItem("user")) {
      this.authenticated = true;
      this.$router.replace({ name: "home" });
    }
  }

  public deauthenticate() {
    localStorage.removeItem("user");
    this.authenticated = false;
    this.$router.replace({ name: "login" });
  }

  public updateRouterView() {
    this.renderViews++;
  }

  mounted() {
    if (localStorage.getItem("user")) {
      this.authenticated = true;
      this.$router.replace({ name: "home" });
    }
  }
}
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  display: grid;
  grid-template-columns: 100%;
  grid-template-rows: auto;
  grid-template-areas:
    "nav"
    "routerviews";
}

#nav {
  grid-area: nav;
}
#views {
  grid-area: routerviews;
}
</style>
