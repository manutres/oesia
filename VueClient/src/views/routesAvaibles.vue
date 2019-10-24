<template>
  <b-row class="m-4 justify-content-md-center">
    <b-col cols="8">
    <h2 class="text-center">Rutas disponibles</h2>
      <b-list-group :key="elementUpdater">
        <b-list-group-item v-for="route in routes" :key="route.Id"><b-link @click="setDirection(route.StartName, route.FinishName)">
          <b>Partida desde:</b>
          {{route.StartName}}
          <b>Destino:</b>
          {{route.FinishName}}
          <span class="ml-5 rightAlign">
            <b-link @click="inscribeToRoute(route)" v-if="!inRoute(route)" href="#">
              <i class="fas fa-user-check float-right">Inscribirse</i>
            </b-link>
            <b-link @click="unsuscribeToRoute(route)" v-else href="#">
              <i class="fas fa-check float-right"> Inscrito</i>
            </b-link>
          </span>
          </b-link>
        </b-list-group-item>
      </b-list-group>
      <div id="map" class="my-4 match-parent"></div>
    </b-col>
  </b-row>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import RouteRepository from "@/RouteRepository";
import LocationRepository from "@/LocationRepository";
import Route from "../models/Route";

@Component
export default class RoutesAvaibles extends Vue {
  routeRepository: RouteRepository = new RouteRepository(
    "https://localhost:44375"
  );
  locationRepository: LocationRepository = new LocationRepository(
    "https://localhost:44375"
  );
  routes: Route[] = [];
  elementUpdater: number = 0;
  map: mapboxgl.Map;
  directions: any;

  private async fetchRoutes() : Promise<void> {
    await this.routeRepository.getAll().then(response => {
      this.routes = response;
    }).catch(error => {});
  }

  forceRender() {
    this.elementUpdater+=1;
    this.fetchRoutes();
    this.fetchRoutes();
    this.fetchRoutes();
    this.fetchRoutes();
    this.fetchRoutes();
  }

  inscribeToRoute(route: Route) {
    this.routeRepository.inscribeUser(route.Id).then(response => {
      this.forceRender();
      alert("Te has inscrito en la ruta correctamente ");
    });
  }

  unsuscribeToRoute(route: Route) {
     this.routeRepository.unsuscribeUser(route.Id).then(response => {
      this.forceRender();
      alert("Te has desinscrito en la ruta correctamente");
    });
  }

  inRoute(route: Route) {
    return route.Ocupantes.includes(parseInt(localStorage.getItem("user_id")));
  }

  setDirection(origin:string, destine:string){
    this.directions.setOrigin(origin);
    this.directions.setDestination(destine);
  }

  mounted() {
    this.fetchRoutes();
    mapboxgl.accessToken = "pk.eyJ1IjoibWFudXRyZXMiLCJhIjoiY2sxcTJ3dnEwMHdhYzNjb2lmcWx4MDdzcCJ9.Vw2OnO_c9FDvhAKvLNTmew";
    this.map = new mapboxgl.Map({
      container: 'map',
      style : 'mapbox://styles/mapbox/streets-v11',
      zoom: 13,
      center: [-1.1719213, 38.0211551]
    });
    this.directions = new MapboxDirections({
      accessToken: mapboxgl.accessToken,
    });
    this.map.addControl(this.directions,'top-left');

  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.match-parent {
  width: 100%;
  height: 150%;
}
</style>
