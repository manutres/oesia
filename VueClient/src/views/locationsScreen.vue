<template>
  <b-row class="home">
    <b-col cols="4">
      <LocationForm v-on:neweladded="updateItemList"></LocationForm>
    </b-col>
    <b-col cols="8">
      <ItemDetails v-bind:item="selectedItem"></ItemDetails>
      <ItemList
        v-on:evento="childClicked"
        :key="rerenderItemList"
        :items="locations"
        :fields="['LocationId', 'Latitude', 'Longitude']"
      />
    </b-col>
  </b-row>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import ItemList from "@/components/itemList.vue"; // @ is an alias to /src
import ItemDetails from "@/components/itemDetails.vue";
import LocationForm from "@/components/locationForm.vue";
import LocationRepository from "@/LocationRepository";
import Location from "@/models/Location";

@Component({
  components: {
    ItemList,
    ItemDetails,
    LocationForm
  }
})
export default class LocationsScreen extends Vue {
  //component keys for rerendering
  rerenderItemList: number = 0;

  //component properties
  selectedItem: any = null;
  locations: Location[] = [];
  locationRepository: LocationRepository = new LocationRepository(
    "https://localhost:44375"
  );

  private async fetchLocations(): Promise<void> {
    this.locationRepository
      .getAllUserLocations(localStorage.getItem("user_id")!)
      .then(response => {
        this.locations = response.data;
      })
      .catch(error => {});
  }

  private childClicked(value: any) {
    this.selectedItem = value;
  }

  private updateItemList() {
    this.rerenderItemList++;
    this.fetchLocations();
  }

  mounted() {
    this.fetchLocations();
  }
}
</script>

<style scoped>
</style>
