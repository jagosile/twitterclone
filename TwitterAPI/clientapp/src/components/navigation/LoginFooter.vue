<template>
  <v-footer
    dark
    padless
    absolute
    
  >
    <v-card
      flat
      tile
      class="primary white--text text-center"
      width="100%"
    >
      <v-card-text>
        <v-btn
          v-for="icon in icons"
          :key="icon.key"
          class="mx-4 white--text"
          icon
          :href="icon.link" target="_blank"
          
        >
          <v-icon size="24px">
            {{ icon.icon }}
          </v-icon>
        </v-btn>
      </v-card-text>


      <v-divider></v-divider>

      <v-card-text class="white--text">
        {{ new Date().getFullYear() }} — <strong>Fisk & Co BI CRM AB</strong>
      </v-card-text>
    </v-card>
  </v-footer>
</template>

<script>
  export default {
    data: () => ({
      icons: [
        {key:1, icon: 'mdi-linkedin', link: "https://se.linkedin.com/company/fisk-co-bi-crm-ab"},
        {key:2, icon: 'mdi-email', link: "mailto:support@fiskco.se"}
      ],
    }),
  }
</script>