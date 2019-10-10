<template>
  <div class="m-4">
    <b-card class="mt-3" header="Item details">
      <pre class="m-0">{{item}}</pre>
    </b-card>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component
export default class ItemDetails extends Vue {
  @Prop() item?: any;
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
