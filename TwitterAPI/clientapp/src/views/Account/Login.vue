<template>
  <div>
    <span class="bg"></span>
    <v-main color="primary">
      <v-container style="margin-top:5em">
        <v-row class="justify-center" align="center">
          <v-col cols="6" md="3">
            <p
              class="transition-swing text-h3 mb--1 mt-10 font-weight-medium text-left"
            >Twitter Clone</p>
            <div class="transition-swing text-subtitle-1 mb-1">.NET CORE 3.1 (Entity Framework Code First, AspNetCore.Identity)</div>
            <div class="transition-swing text-subtitle-1 mb-1">VUE 2 (vuex, router, axios, vuetify)</div>
            <div class="transition-swing text-subtitle-1 mb-1">Amazon RDS MYSQL</div>
            <a href="https://github.com/jagosile/TwitterClone" target="_blank">Github</a>
          </v-col>
          <v-col md="3">
            <v-card class="elevation-12" rounded>
              <v-card-text>
                <v-form v-on:submit.prevent="Login">
                  <v-text-field
                    label="E-mail"
                    name="login"
                    prepend-icon="mdi-email"
                    type="text"
                    v-model="email"
                  ></v-text-field>

                  <v-text-field
                    id="password"
                    label="Password"
                    name="password"
                    prepend-icon="mdi-lock"
                    type="password"
                    v-model="password"
                  ></v-text-field>

                  <v-card-actions>
                    <v-container>
                      <v-row dense>
                        <v-col>
                          <v-btn
                            :loading="loading"
                            type="submit"
                            class="mt-0"
                            block
                            height="50"
                            dark
                            color="primary"
                          >
                           <v-icon
        left
        dark
       
      >
      mdi-login
      </v-icon>
                          {{ submitText }}</v-btn>
                          <signupform />
                        </v-col>
                      </v-row>

                      <v-row dense>
                        <v-col>
                          <v-slide-y-transition>
                            <div class="font-weight-regular red--text"
                              v-if="showAlert"
                              dense
                              border="left"
                              :class=" { status : 'green--text'}"
                            >
                            <v-icon left small v-if="status">mdi-check</v-icon>
                              {{ statusText }}
                            </div>
                          </v-slide-y-transition>
                        </v-col>
                      </v-row>

                      <v-row dense>
                        <v-col>
                          <v-divider inset />
                        </v-col>
                      </v-row>
                    </v-container>
                  </v-card-actions>
                </v-form>
              </v-card-text>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
    <v-spacer/>
    <loginfooter />
  </div>
</template>



<script>
// import Vue from 'vue'
import accountService from "@/services/AccountService";
import loginfooter from "@/components/navigation/LoginFooter";
import signupform from "../../components/account/Signup"
export default {
  props: {
    source: String
  },
  components: {
    loginfooter,
    signupform
  },
  data: () => ({
    email: null,
    password: null,
    showAlert: false,
    status: false,
    statusText: "",
    loading: false,
    submitText: "Log in"
  }),
  methods: {
    async Login() {
      this.showAlert = false;
      this.loading = true;
      const response = await accountService.Login(this.email, this.password);
      if (!response.succeeded) {
        this.status = false;
        this.statusText = "Wrong username or password";
      }
      else{
      this.status = true
      this.statusText = "You will soon be redirected";
      // this.$store.dispatch('auth/setCredentials', response.token);
      // Vue.prototype.$axios.defaults.headers.common["Authorization"] = "Bearer " + response.token;
      }

      this.showAlert = true;
      this.loading = false;
      if(this.status){
          setTimeout( () => {
              alert("redirect to home")
              // this.$router.replace({ name: "home" });
                  //push to:/home
          }, 1000);
      }
      
     
    }
  }
};
</script>