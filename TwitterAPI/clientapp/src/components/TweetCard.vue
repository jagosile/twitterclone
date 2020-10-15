<template>
<div>
  <v-card class="mx-auto" elevation="10" :color="canEdit ? 'cyan' : ''" :dark="canEdit"  max-width="700" :loading="loading" loader-height="10">
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
          <v-btn icon v-if="!canEdit" @click="subscribe">
          <v-icon class="mr-1">mdi-bookmark-plus</v-icon>
           </v-btn>           
        </v-row>
      </v-list-item>
    </v-card-actions>
  </v-card>
 <v-snackbar
      v-model="snackbar"
      color="primary"
      v-if="snackbar"
    >
      {{ status }}

      <template v-slot:action="{ attrs }">
        <v-btn
          color="white"
          text
          v-bind="attrs"
          @click="snackbar = false"
          
        >
          Close
        </v-btn>
      </template>
    </v-snackbar>
  </div>
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
      default: null,
      status:  ""
    }
  },
  data: () => ({
    loading:false,
    snackbar:false
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
      this.loading = "red";
      await tweetService.Delete(this.tweet.id)
      //trigger refresh
      await this.$store.dispatch('util/setLoading', true);
      await this.$store.dispatch('tweet/loadTweets');
      await this.$store.dispatch('util/setLoading', false);
      this.loading = false;
    },
    async subscribe(){
      this.loading = true;
      let response = await tweetService.Subscribe(this.tweet.user.id)
      
  this.status = response ? `You are now subscribing  to ${this.tweet.user.email}}` : `You are already subscribing to ${this.tweet.user.email}`
  this.snackbar = true;
      this.loading = false;
    }
  }
};
</script>