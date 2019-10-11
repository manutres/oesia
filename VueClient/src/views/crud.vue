<template>
  <b-row class="home">
    <b-col cols="4">
      {{ fullpath }}
      <UserForm v-on:neweladded="updateItemList"></UserForm>
    </b-col>
    <b-col cols="8">
      <ItemDetails v-bind:item="selectedItem"></ItemDetails>
      <ItemList v-on:evento="childClicked" :key="rerenderItemList" :users="users" />
    </b-col>
  </b-row>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";
import ItemList from "@/components/itemList.vue"; // @ is an alias to /src
import ItemDetails from "@/components/itemDetails.vue";
import UserForm from "@/components/userForm.vue";
import Repository from "@/Repository";
import User from "@/models/User";

@Component({
  components: {
    ItemList,
    ItemDetails,
    UserForm
  }
})
export default class Crud extends Vue {
  //component keys for rerendering
  rerenderItemList: number = 0;

  //component properties
  selectedItem: any = null;
  userRepository: Repository<User> = new Repository<User>(
    "https://localhost:44375/api/users"
  );
  users: User[] = [];

  private async fetchUsers(): Promise<void> {
    this.userRepository
      .getAll()
      .then(response => {
        this.users = response.data;
      })
      .catch(error => {});
  }

  private childClicked(value: any) {
    this.selectedItem = value;
  }

  private updateItemList() {
    this.rerenderItemList++;
  }

  mounted() {
    this.fetchUsers();
  }
}
</script>

<style scoped>
</style>
