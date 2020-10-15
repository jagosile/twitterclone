<template>
  <div>
<v-container>
        <v-row class="justify-center" align="center">
          <v-col>

            <createtweet/>
          </v-col>    
        </v-row>
      </v-container>
  </div>
</template>



<script>


import createtweet from "@/components/CreateTweet"
export default {
  props: {
    source: String
  },
  components: {
    createtweet
  },
  data: () => ({

    showOnlySubscriptions: false,

  }),
  methods: {
    
     
  }
};
</script>