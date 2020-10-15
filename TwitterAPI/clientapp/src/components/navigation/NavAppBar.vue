<template>
  <div>
    <!-- <v-navigation-drawer v-model="drawer" app>
      <v-list dense>
        <v-list-item link to="/home">
          <v-list-item-action>
            <v-icon>mdi-home</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Home</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-email</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Contact</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer> -->
 
    <v-app-bar app color="primary" dark dense>
      <!-- <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon> -->
      <v-toolbar-title>SMART Target</v-toolbar-title>
      <v-tooltip bottom>
        <template v-slot:activator="{ on, attrs }">
   <v-btn icon class="ml-5"
          to="/home"
            v-bind="attrs"
            v-on="on"> 
        <v-icon>mdi-home</v-icon>
      </v-btn>
        </template>
          <span>Home</span>
      </v-tooltip>
       <v-tooltip bottom>
        <template v-slot:activator="{ on, attrs }">
   <v-btn icon 
          to="/map"
           v-bind="attrs"
            v-on="on">
        <v-icon>mdi-map-marker-radius</v-icon>
      </v-btn>   
        </template>
                <span>Target</span>
      </v-tooltip>
       <v-tooltip bottom>
        <template v-slot:activator="{ on, attrs }">
   <v-btn icon 
          to="/dashboard"
            v-bind="attrs"
            v-on="on">
        <v-icon>mdi-chart-bar</v-icon>
      </v-btn>           
            </template>
                <span>Dashboard</span>
      </v-tooltip>
      <v-spacer></v-spacer>
      {{ owner.name }} |
    {{ user.data.name }}
      <v-tooltip bottom>
      <template v-slot:activator="{ on, attrs }">
   <v-btn icon v-bind="attrs"
          v-on="on"
          @click="OpenAdmin"> 
        <v-icon>mdi-dots-vertical</v-icon>
      </v-btn>
</template>
      <span>Inställningar</span>
    </v-tooltip>
    
      <v-tooltip bottom>
      <template v-slot:activator="{ on, attrs }">
   <v-btn icon v-bind="attrs"
          v-on="on"
          @click="Logout"> 
        <v-icon>mdi-logout</v-icon>
      </v-btn>
</template>
      <span>Logga ut</span>
    </v-tooltip>

    </v-app-bar>




  </div>
</template>

<script>

import accountService from "@/services/AccountService";
import Vue from "vue";
export default {
  props: {
    source: String
  },
  data: () => ({
    // drawer: false
  }),
  computed: {
    user() {
      return this.$store.getters["auth/user"];
    },
    owner() {
      return this.$store.getters["owner/owner"];
    }    
  },
  methods:{
          async Logout() {
             await accountService.Logout()
             this.$store.dispatch("auth/fetchUser", null); 
             this.$store.dispatch('auth/setCredentials', null); //deletes key from local storage
             Vue.prototype.$axios.defaults.headers.common["Authorization"] = null //deletes key from axios auth header
     this.$router.replace({
            name: "login"
          });
    },
    OpenAdmin() {
     this.$router.replace({
            name: "admin"
          });
    },
    OpenMap() {
     this.$router.replace({
            name: "home"
          });
    }    
    }
};
</script>