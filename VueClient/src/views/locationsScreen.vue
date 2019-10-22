<template>
  <b-row class="home">
    <b-col cols="4">
      <LocationForm :locationInput="locationInput" v-on:neweladded="updateItemList"></LocationForm>
      <div id="map" class="match-parent"></div>
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
  </b-row>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import ItemList from "@/components/itemList.vue"; // @ is an alias to /src
import ItemDetails from "@/components/itemDetails.vue";
import LocationForm from "@/components/locationForm.vue";
import UserRepository from "@/UserRepository";
import Location from "@/models/Location";
import * as mapboxgl from 'mapbox-gl';

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

  map: mapboxgl.Map;
  style = 'mapbox://styles/mapbox/streets-v11';
  lat = 38.0211551;
  lng = -1.1719213;

  //component properties
  selectedItem: any = null;
  locations: Location[] = [];
  userRepository: UserRepository = new UserRepository(
    "https://localhost:44375"
  );
  locationInput: Location = new Location();
  marker: mapboxgl.Marker = new mapboxgl.Marker();


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

  private getCoordinates(e) {
    this.locationInput.Latitude = e.lngLat.lat;
    this.locationInput.Longitude = e.lngLat.lng;
    this.marker
    .setLngLat(e.lngLat)
    .addTo(this.map);
  }

  private updateItemList() {
    this.rerenderItemList++;
    this.fetchLocations();
  }

  mounted() {
    this.fetchLocations();
    mapboxgl.accessToken = "pk.eyJ1IjoibWFudXRyZXMiLCJhIjoiY2sxcTJ3dnEwMHdhYzNjb2lmcWx4MDdzcCJ9.Vw2OnO_c9FDvhAKvLNTmew";
      this.map = new mapboxgl.Map({
        container: 'map',
        style : 'mapbox://styles/mapbox/streets-v11',
        zoom: 13,
        center: [-1.1719213, 38.0211551]
    });
    // Add map controls
    this.map.addControl(new mapboxgl.NavigationControl());
    this.map.on('click', this.getCoordinates);
  }
}
</script>

<style scoped>
.match-parent {
  width: 100%;
  height: 100%;
}
</style>
