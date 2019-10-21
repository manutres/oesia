<template>
  <b-row class="home">
    <b-col cols="4">
      <CarForm v-on:neweladded="updateItemList"></CarForm>
    </b-col>
    <b-col cols="8">
      <!-- <ItemDetails v-bind:item="selectedItem"></ItemDetails> -->
      <ItemList
        v-on:evento="childClicked"
        :key="rerenderItemList"
        :items="cars"
        :fields="['Id', 'Brand', 'Model']"
      />
    </b-col>
  </b-row>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import ItemList from "@/components/itemList.vue"; // @ is an alias to /src
import ItemDetails from "@/components/itemDetails.vue";
import CarForm from "@/components/carForm.vue";
import UserRepository from "@/UserRepository";
import Car from "@/models/Car";

@Component({
  components: {
    ItemList,
    ItemDetails,
    CarForm
  }
})
export default class CarsScreen extends Vue {
  //component keys for rerendering
  rerenderItemList: number = 0;

  //component properties
  selectedItem: any = null;
  cars: Car[] = [];
  userRepository: UserRepository = new UserRepository(
    "https://localhost:44375"
  );

  private async fetchCars(): Promise<void> {
    this.userRepository
      .getUserCars()
      .then(response => {
        this.cars = response.data;
      })
      .catch(error => {});
  }

  private childClicked(value: any) {
    this.selectedItem = value;
  }

  private updateItemList() {
    this.rerenderItemList++;
    this.fetchCars();
  }

  mounted() {
    this.fetchCars();
  }
}
</script>

<style scoped>
</style>
