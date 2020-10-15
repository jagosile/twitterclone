<template>
  <div class="text-center">
    <v-dialog
      v-model="dialog"
      width="500"
    >
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          color="primary"
          dark
          v-bind="attrs"
          v-on="on"
          fab
          icon
        >
          <v-icon>mdi-account</v-icon>
        </v-btn>
      </template>

      <v-card>
        <v-card-title class="headline grey lighten-2">
          {{ user.email}}
        </v-card-title>

        <v-card-text>
          {{ user.bio}}
        </v-card-text>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="primary"
            text
            @click="dialog = false"
          >
            I accept
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>


<script>

  export default {
          props: {
    user: {
      type: Object,
      default: null
    }
  },
    data: () => ({
      dialog: false,
    }),
    methods: {
    }
  }
</script>