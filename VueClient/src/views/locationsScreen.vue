<template>
  <b-row class="home">
    <b-col cols="4">
      <LocationForm v-on:neweladded="updateItemList"></LocationForm>
    </b-col>
    <b-col cols="8">
      <!-- <ItemDetails v-bind:item="selectedItem"></ItemDetails> -->
      <ItemList
        v-on:evento="childClicked"
        :key="rerenderItemList"
        :items="locations"
        :fields="['Id', 'LocationName', 'Latitude', 'Longitude']"
      />
    </b-col>
    <div id="mapid"></div>
  </b-row>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import ItemList from "@/components/itemList.vue"; // @ is an alias to /src
import ItemDetails from "@/components/itemDetails.vue";
import LocationForm from "@/components/locationForm.vue";
import UserRepository from "@/UserRepository";
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
  var mymap = L.map('mapid').setView([51.505, -0.09], 13);

  //component properties
  selectedItem: any = null;
  locations: Location[] = [];
  userRepository: UserRepository = new UserRepository(
    "https://localhost:44375"
  );

  private async fetchLocations(): Promise<void> {
    this.userRepository
      .getUserLocations()
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
#mapid {
  height: 180px;
}
</style>
