<template>
  <b-row class="m-4 justify-content-md-center">
    <b-col cols="6">
      <b-list-group>
        <b-list-group-item v-for="route in routes" :key="route.Id">
          <b>Partida de:</b>
          {{route.StartName}}
          <b>Destino:</b>
          {{route.FinishName}}
          <span class="rightAlign">
            <b-link v-if="inRoute(route)" href="#" :to="{ name : 'routes' }">
              <i class="fas fa-user-check float-right"></i>
            </b-link>
            <b-link v-else href="#" :to="{ name : 'routes' }">
              <i class="fas fa-check"></i>
            </b-link>
          </span>
        </b-list-group-item>
      </b-list-group>
    </b-col>
  </b-row>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import RouteRepository from "@/RouteRepository";
import LocationRepository from "@/LocationRepository";
import Route from "../models/Route";
import SemanticRoute from "../models/SemanticRoute";

@Component
export default class RoutesAvaibles extends Vue {
  routeRepository: RouteRepository = new RouteRepository(
    "https://localhost:44375"
  );
  locationRepository: LocationRepository = new LocationRepository(
    "https://localhost:44375"
  );
  routes: Route[] = [];

  fetchRoutes() {
    this.routeRepository.getAll().then(response => {
      this.routes = response;
    });
  }

  inRoute(route: Route) {
    return route.Ocupantes.includes(parseInt(localStorage.getItem("user_id")!));
  }

  mounted() {
    this.fetchRoutes();
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
