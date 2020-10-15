<template>
  <v-app id="app">
    <LoadingOverlay style="z-index:1000000000000000" />

    <!-- <Navbar style="z-index:500000" v-if="user.loggedIn"/> -->
    <Navbar v-if="user.loggedIn" />

    <v-main>
      <router-view />
    </v-main>

    <v-dialog v-model="showModal" v-if="showModal" persistent scrollable :max-width="modal.width">


     <v-card v-if="showModal">
        <v-fab-transition >
         <v-btn style="bottom:1em"
                color="error"
                dark
                absolute
                bottom
                left
                fab
                x-small
                @click="toggleModal"
              >
                <v-icon small> mdi-window-close</v-icon>
              </v-btn>
         </v-fab-transition>
  <v-card-text>
   <keep-alive>
                <v-container>
                  <component v-bind:is="modal.component"></component>
                </v-container>
              </keep-alive>
  </v-card-text>
     </v-card>
    </v-dialog>
  </v-app>
</template>

<style lang="scss">
html,
body {
  width: 100%;
  height: 100%;
  margin: 0;
  padding: 0;
  background-color: #eef9f7;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  // text-align: center;
  color: #2c3e50;
}


#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>

<script>
// @ is an alias to /src
import LoadingOverlay from "@/components/overlays/LoadingOverlay.vue";
import Navbar from "@/components/navigation/NavAppBar.vue";


export default {
  components: {
    LoadingOverlay,
    Navbar

  },
  computed: {
    loading() {
      return this.$store.getters["util/loading"];
    },
    user() {
      return this.$store.getters["auth/user"];
    },
    modal() {
      return this.$store.getters["util/modalComponent"];
    },
    showModal() {
      return this.modal !== null;
    },
  },
  methods: {
    toggleModal() {
      this.$store.dispatch("util/setModalComponent", null);
    },
  },
};
</script>

