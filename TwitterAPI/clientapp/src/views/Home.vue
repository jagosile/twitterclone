<template>
  <div>
       
<v-container>

        <v-row class="justify-center" align="center">
          <v-col cols="2">
              <createtweet/>
          </v-col>
          <v-col cols="2">
            <v-card>
              <v-card-text>
            <subscriptions />
              </v-card-text>
            </v-card>
          </v-col>    
        </v-row>
        <v-row class="justify-center" align="center">
          <v-col>
            <v-card>
            <tweetfeed />
            </v-card>
          </v-col>    
        </v-row>        
      </v-container>
  </div>
</template>



<script>


import createtweet from "@/components/CreateTweet"
import tweetfeed from "@/components/TweetFeed"
import subscriptions from "@/components/Subscriptions"
export default {
  props: {
    source: String
  },
  components: {
    createtweet,
    tweetfeed,
    subscriptions
  },
  data: () => ({

    showOnlySubscriptions: false,

  }),
  methods: {
    
     
  }
};
</script>