<template>
  <b-row class="home">
    <b-col cols="4">
      <UserForm v-on:neweladded="updateItemList" id="form"></UserForm>
    </b-col>
    <b-col cols="8">
      <ItemDetails v-bind:item="selectedItem"></ItemDetails>
      <ItemList v-on:evento="childClicked" :key="rerenderItemList" />
    </b-col>
  </b-row>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import ItemList from "@/components/itemList.vue"; // @ is an alias to /src
import ItemDetails from "@/components/itemDetails.vue";
import UserForm from "@/components/userForm.vue";

@Component({
  components: {
    ItemList,
    ItemDetails,
    UserForm
  }
})
export default class Crud extends Vue {
  selectedItem: any = null;
  rerenderItemList: number = 0;

  private childClicked(value: any) {
    this.selectedItem = value;
  }

  private updateItemList() {
    this.rerenderItemList++;
  }

  mounted() {}
}
</script>

<style scoped>
</style>
