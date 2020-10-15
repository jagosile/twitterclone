<template>
<div>
     <v-btn
          class="mx-2"
      fab
      dark
      color="success"
      @click="load"
        >
            <v-icon dark>
        mdi-refresh
      </v-icon>
        </v-btn>
    <v-row v-for="t in tweets" :key="t.id">
      <v-col cols="12">
      <tweetcard :tweet="t"/>
      </v-col>
    </v-row>
</div>
</template>

<script>

import tweetService from "@/services/TweetService"
import tweetcard from "@/components/TweetCard"
  export default {
    components: {
      tweetcard
    },
    data: () => ({
      dialog: false,
      status: "",

      tweets: []
    }),
    mounted(){
      this.load()
    },
    methods: {
        async load(){
            const response = await tweetService.Tweets(this.messagebody)
            this.tweets = response
            // this.status = response ? "You have just tweeted!" : "Could not create tweet!"
            // this.snackbar = true
        }
        

    }
  }
</script>