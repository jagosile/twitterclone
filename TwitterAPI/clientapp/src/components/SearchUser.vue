<template>
<div>
         <v-autocomplete
            v-model="selected"
            :items="users"
            return-object
            item-text="email"
            outlined
            dense
            chips
            small-chips
            label="Search users"
            multiple
            @input="filter"
          >
           <template v-slot:append-outer>
             <v-tooltip right>
      <template v-slot:activator="{ on, attrs }">
             <v-btn icon v-bind="attrs"
          v-on="on" @click="unsubscribe">
              <v-icon>mdi-account-remove</v-icon>
             </v-btn>
      </template>
       <span>Unsubscribe selected</span>
             </v-tooltip>
           </template>
          
          </v-autocomplete>

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
      snackbar: false,
      users: [],
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
           this.users =  await tweetService.Users()
        },
        async filter(val){
          if(val.length > 0) {
           await this.$store.dispatch('tweet/loadTweetsByUser', val.map(x => x.id));
          }
          else{
            await this.$store.dispatch('tweet/loadTweets');
          }
        },
        async unsubscribe(){
          const result = await tweetService.DeleteSubscriptions(this.selected.map( x => x.id))
          this.status = result ?  "You have unsubscribed to the users" : "Could not unsubscribe" 
          this.snackbar = true

        }
        

        

    }
  }
</script>