<template>
  <v-card class="mx-auto" elevation="10"  max-width="700">
    <v-card-title>
      <v-icon large left>mdi-twitter</v-icon>
      <span class="title font-weight-light">{{tweet.user.email}}</span>
      <profile :user="tweet.user" />
    </v-card-title>

    <v-card-text
      class="headline font-weight-bold"
    >
    {{tweet.message}}
    </v-card-text>

    <v-card-actions>
      <v-list-item >
        <v-list-item-content>
          <v-list-item-subtitle>{{ tweet.created}}</v-list-item-subtitle>
        </v-list-item-content>

        <v-row align="center" justify="end">
          <v-icon class="mr-1">mdi-heart</v-icon>
          <span class="subheading mr-2">256</span>
          <span class="mr-1">·</span>
          <v-icon class="mr-1">mdi-share-variant</v-icon>
          <span class="subheading">45</span>
        </v-row>
      </v-list-item>
    </v-card-actions>
  </v-card>
</template>


<script>

import profile from "@/components/account/Profile"
export default {
  components:{
    profile
  },
  props: {
    tweet: {
      type: Object,
      default: null
    }
  },
  data: () => ({
    //
  })
};
</script>