<template>
  <div>
<v-container>
        <v-row class="justify-center" align="center">
          <v-col>
            <createtweet/>
          </v-col>    
        </v-row>
        <v-row class="justify-center" align="center">
          <v-col>
            <tweetfeed />
          </v-col>    
        </v-row>        
      </v-container>
  </div>
</template>



<script>


import createtweet from "@/components/CreateTweet"
import tweetfeed from "@/components/TweetFeed"
export default {
  props: {
    source: String
  },
  components: {
    createtweet,
    tweetfeed
  },
  data: () => ({

    showOnlySubscriptions: false,

  }),
  methods: {
    
     
  }
};
</script>