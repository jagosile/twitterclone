import Vue from 'vue'
// import * as firebase from "firebase";
import App from './App.vue'
import vuetify from './plugins/vuetify';
import router from './router'
import axios from 'axios'
import store from './store/store'




Vue.prototype.$axios = axios.create({
  baseURL: process.env.VUE_APP_BASEURL
});
Vue.prototype.$axios.defaults.withCredentials = true;


// Vue.prototype.$axios.interceptors.response.use(
//   response => {
//     return response;
//   },
//   error => {
//     if (error.response.status === 401) {
//       router.push("login");
//       //place your reentry code
//     }
//     return error;
//   }
// );


console.log(process.env.VUE_APP_BASEURL)


Vue.config.productionTip = false


Vue.filter('formatMoney',  (amount)  => {
 try {
  return new Intl.NumberFormat('sv-SE',  { maximumFractionDigits: 2 }).format(amount)
  } catch (e) {
    console.log(e)
  }
  });


new Vue({
  store,
  vuetify,
  router,
  render: h => h(App)
}).$mount('#app')


