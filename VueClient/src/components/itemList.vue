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
      :items="users"
      @row-selected="selectItem"
      :fields="['UserId', 'Email', 'Pass']"
    ></b-table>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import Axios from "axios";
import UserService from "@/userService";
import User from "@/models/User";
import Repository from "@/Repository";

@Component
export default class ItemList extends Vue {
  //components props
  @Prop() users: User[] = [];

  selectedItem: any = null;

  //table props
  perPage: number = 20;
  selectMode: string = "single";
  currentPage: number = 0;

  userRepository: Repository<User> = new Repository<User>(
    "https://localhost:44375/api/users"
  );

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
    return this.users.length;
  }

  private lastPage() {
    return Math.ceil(this.rows() / this.perPage);
  }
}
</script>

<style scoped>
</style>
