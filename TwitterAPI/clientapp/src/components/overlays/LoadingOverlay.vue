<template>
  <div class="text-center">
    <v-overlay :value="show">
        <v-progress-circular
        :size="70"
        :width="10"
        color="primary"
        indeterminate

          ></v-progress-circular>
    </v-overlay>
  </div>
</template>

<script>
export default {


  data() {
    return {};
  },
  computed: {
    show() {
      return this.$store.getters["util/loading"];
    }
  }
};
</script>