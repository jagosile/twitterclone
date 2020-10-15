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

//import tweetService from "@/services/TweetService"
import tweetcard from "@/components/TweetCard"
  export default {
      props: {
    tweet: {
      type: Object,
      default: null
    }
  },
    components: {
      tweetcard
    },
    data: () => ({
      dialog: false,
      status: "",
    }),
    mounted(){
      this.load()
      alert(this.tweets)
    },
    computed:{
      tweets(){
        return this.$store.getters["tweet/tweets"]; 
      }
    },
    methods: {
        async load(){
            //const response = await tweetService.Tweets(this.messagebody)
            await this.$store.dispatch('tweet/loadTweets');
            
            // this.status = response ? "You have just tweeted!" : "Could not create tweet!"
            // this.snackbar = true
        }
        

    }
  }
</script>