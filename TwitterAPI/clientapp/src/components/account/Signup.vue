<template>
  <v-row justify="center">
    <v-dialog
      v-model="dialog"
      persistent
      max-width="600px"
    >
      <template v-slot:activator="{ on, attrs }">
        
        <v-btn
          color="primary"
          dark
          v-bind="attrs"
          v-on="on"
          text
        >
          SIGN UP
        </v-btn>
      </template>
      <v-card>
        <v-card-title>
          <span class="headline">Signup</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
    
      
      
              <v-col cols="12">
                <v-text-field
                v-model="email"
                  label="Email*"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                v-model="password"
                  label="Password*"
                  type="password"
                  required
                ></v-text-field>
              </v-col>
              <v-col
                cols="12"
                sm="6"
              >
                <v-textarea filled label="Write your bio" placeholder="Biography" v-model="bio"
                ></v-textarea>
              </v-col>
              <v-col
              cols="12"
              sm="6">
              <v-container v-if="response" key="signupresponse">
                <v-alert
                    v-for="e in response.errors" :key="e.code"
                    border="top"
                    color="red lighten-2"
                    dark
                    dense
                    class="text"
                  >
                    {{ e.description }}
                  </v-alert>
    

                   <v-alert v-if="response.errors.length == []"
      dense
      text
      type="success"
    >
      You have been signed up! Log in with <strong>{{ email }}</strong> and your password
    </v-alert>
                  
              </v-container>

              </v-col>
            </v-row>
          </v-container>
          <small>*indicates required field</small>
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
            @click="create"
          >
            OK
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<script>
import accountService from "@/services/AccountService"
  export default {
    data: () => ({
      dialog: false,
       email: "",
      password: "",
      bio: "",
      response: ""
    }),
    methods: {
      async create(){
        this.response = await accountService.Create(this.email, this.password, this.bio)
        
        

      }
    }
  }
</script>