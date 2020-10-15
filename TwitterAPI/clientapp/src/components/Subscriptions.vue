<template>
<div>
         <v-autocomplete
            v-model="selected"
            :items="subscriptions"
            item-value="subscriber.id"
            item-text="subscriber.email"
            outlined
            dense
            chips
            small-chips
            label="Filter feed subscriptions"
            multiple
            @input="filter"
          ></v-autocomplete>
</div>
</template>

<script>

import tweetService from "@/services/TweetService"



  export default {
      props: {
    tweet: {
      type: Object,
      default: null
    }
  },
    components: {
    },
    data: () => ({
      dialog: false,
      status: "",
      subscriptions: [],
      selected: []
    }),
    mounted(){
      this.load()
    },
    computed:{
      tweets(){
        return this.$store.getters["tweet/tweets"]; 
      }
    },
    methods: {
        async load(){
            this.subscriptions = await tweetService.Subscriptions()
            
           // await this.$store.dispatch('tweet/loadTweets', this.selected );
            
            // this.status = response ? "You have just tweeted!" : "Could not create tweet!"
            // this.snackbar = true
        },
        async filter(val){
          if(val.length > 0) {
           await this.$store.dispatch('tweet/loadTweetsByUser', val );
          }
          else{
            await this.$store.dispatch('tweet/loadTweets');
          }

        }

        

    }
  }
</script>