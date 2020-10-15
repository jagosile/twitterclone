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
          <v-btn icon v-if="canEdit" @click="deleteTweet">
          <v-icon class="mr-1">mdi-delete</v-icon>
          </v-btn>
           <v-btn icon v-if="canEdit">
          <v-icon class="mr-1">mdi-tooltip-edit</v-icon>
           </v-btn>
          <v-btn icon v-if="!canEdit">
          <v-icon class="mr-1">mdi-bookmark-plus</v-icon>
           </v-btn>           
        </v-row>
      </v-list-item>
    </v-card-actions>
  </v-card>
</template>


<script>

import profile from "@/components/account/Profile"
import tweetService from "@/services/TweetService"
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
  }),
    computed: {
    user() {
      return this.$store.getters["auth/user"];
    },
    canEdit(){
      return this.tweet.user.id == this.user.data.id
    }
  },  
  methods:{
    async deleteTweet(){
      await tweetService.Delete(this.tweet.id)
      //trigger refresh
    }
  }
};
</script>