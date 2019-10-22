<template>
  <b-row>
    <b-col md="6">
      <b-card
        title="¡Emperchate a una rutica!"
        img-src="https://www.ruta0.com/pix/una-ruta.jpg"
        img-height="300"
        img-alt="Image"
        img-top
        tag="article"
        class="m-3 bgorange"
      >
        <b-card-text>Descubre y elige una ruta entre todas las propuestas por nuestros usuarios, ahorrarás tiempo y ahorraras co2.</b-card-text>

        <b-button
          class="pinky"
          href="#"
          :to="{ name : 'routes' }"
          variant="primary"
        >Elección de ruta</b-button>
      </b-card>
    </b-col>
    <b-col md="6">
      <b-card
        title="O... deja que se te emperchen"
        img-src="https://cdn.blablacar.com/kairos/assets/build/images/home_driver_large-1d8ac5fb672573235fc5f46ce0acc37c.jpg"
        img-height="300"
        img-alt="Image"
        img-top
        tag="article"
        class="m-3 bgpink"
      >
        <b-card-text>También puedes crear tu propia ruta y publicarla en nuestra App, ahorrando dinero y reduciendo tu huella de co2.</b-card-text>

        <b-button class="pinky" :to="{ name : 'routes' }" href="#" variant="primary">Crear ruta</b-button>
      </b-card>
    </b-col>
  </b-row>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import RoutesScreen from "@/views/routesScreen.vue";
import RouteRepository from "@/RouteRepository";
@Component({
  components: {
    RoutesScreen
  }
})
export default class Home extends Vue {
  mounted() {}
}
</script>

<style scoped>
.pinky {
  border-color: #fa7c92;
  background-color: #fa7c92;
}
.bgorange {
  border-color: rgb(255, 255, 255);
  background-color: #6ec4db;
}
.bgpink {
  border-color: rgb(255, 255, 255);
  background-color: #66ab8c;
}
</style>
