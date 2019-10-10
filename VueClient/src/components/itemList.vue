<template>
  <div class="m-4">
    <b-pagination
      v-model="currentPage"
      :total-rows="rows()"
      :per-page="perPage"
      aria-controls="table"
    ></b-pagination>
    <b-table
      id="table"
      responsive
      selectable
      :per-page="perPage"
      :current-page="currentPage"
      :select-mode="selectMode"
      selected-variant="active"
      :items="info"
      @row-selected="selectItem"
      :fields="['UserId', 'Email', 'Pass']"
    ></b-table>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import Axios from "axios";

@Component
export default class ItemList extends Vue {
  info: any = null;
  selectedItem: any = null;
  selectMode: string = "single";
  perPage: number = 20;
  currentPage: number = 0;
  config = {
    headers: { Authorization: "Bearer " + localStorage.getItem("user") }
  };

  private isSelectedItem(item: any) {
    return item.id === this.selectedItem.id;
  }

  private selectItem(item: any) {
    this.selectedItem = item[0];
    this.$emit("evento", this.selectedItem);
  }

  private rows() {
    return this.info.length;
  }

  private lastPage() {
    return Math.ceil(this.rows() / this.perPage);
  }

  mounted() {
    Axios.get("https://localhost:44375/api/users", this.config).then(
      response => {
        this.info = response.data.reverse();
      }
    );
  }
}
</script>

<style scoped>
</style>
