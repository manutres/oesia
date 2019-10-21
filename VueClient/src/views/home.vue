<template>
  <b-row>
    <b-col cols="6">
      <h1>¿Dónde quieres ir hoy?</h1>
    </b-col>
    <b-col cols="6">
      <h1>¡Voy en mi coche!</h1>
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
</style>
