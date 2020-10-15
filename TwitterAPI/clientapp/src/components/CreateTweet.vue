<template>
<div>
  <v-row justify="center">
    <v-dialog
      v-model="dialog"
      persistent
      max-width="600px"
    >

      <template v-slot:activator="{ on, attrs }">
        <v-btn
          v-bind="attrs"
          v-on="on"
          class="mx-2"
      fab
      dark
      color="indigo"
        >
            <v-icon dark>
        mdi-plus
      </v-icon>
        </v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="headline">New tweet</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
                <v-textarea placeholder="Write a tweet!" v-model="messagebody"/>


            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="blue darken-1"
            text
            @click="dialog = false"
          >
            Back
          </v-btn>
          <v-btn
            color="blue darken-1"
            text
            @click="tweet"
          >
            Save
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>


 <v-snackbar
      v-model="snackbar"
      color="primary"
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
    data: () => ({
      dialog: false,
      messagebody: "",
      status: "",
      snackbar:false
    }),
    methods: {
        async tweet(){
            const response = await tweetService.Create(this.messagebody)
            this.status = response ? "You have just tweeted!" : "Could not create tweet!"
            this.snackbar = true
            if(response)
              this.$store.dispatch('tweet/loadTweets');
              
        }
        

    }
  }
</script>