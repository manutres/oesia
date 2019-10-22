<template>
  <b-row class="home">
    <b-col cols="4">
      <RouteForm v-on:neweladded="updateItemList"></RouteForm>
    </b-col>
    <b-col cols="8">
      <!-- <ItemDetails v-bind:item="selectedItem"></ItemDetails> -->
      <ItemList
        v-on:evento="childClicked"
        :key="rerenderItemList"
        :items="routes"
        :fields="['CarId', 'StartName', 'FinishName']"
      />
    </b-col>
  </b-row>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import ItemList from "@/components/itemList.vue"; // @ is an alias to /src
import ItemDetails from "@/components/itemDetails.vue";
import RouteForm from "@/components/routeForm.vue";
import UserRepository from "@/UserRepository";
import Route from "@/models/Route";

@Component({
  components: {
    ItemList,
    ItemDetails,
    RouteForm
  }
})
export default class RoutesScreen extends Vue {
  //component keys for rerendering
  rerenderItemList: number = 0;

  //component properties
  selectedItem: any = null;
  routes: Route[] = [];
  userRepository: UserRepository = new UserRepository(
    "https://localhost:44375"
  );

  private async fetchRoutes(): Promise<void> {
    this.userRepository
      .getUserRoutes()
      .then(response => {
        this.routes = response.data;
      })
      .catch(error => {});
  }

  private childClicked(value: any) {
    this.selectedItem = value;
  }

  private updateItemList() {
    this.rerenderItemList++;
    this.fetchRoutes();
  }

  mounted() {
    this.fetchRoutes();
  }
}
</script>

<style scoped>
</style>
