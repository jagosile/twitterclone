import Vue from "vue";
import VueRouter from "vue-router";
import store from "@/store/store";
import accountService from "@/services/AccountService";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    redirect: "login",
    meta: { requiresLogin: false },
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "login" */ "../views/Account/Login.vue"),
  },
  {
    path: "/login",
    name: "login",
    meta: { requiresLogin: false },
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "login" */ "../views/Account/Login.vue"),
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach(async (to, from, next) => {
  if (to.meta.requiresLogin) {
    //key already exists in local storage?    
    const currentToken = localStorage.getItem("auth-token"); // stash the auth token in localStorage
    if(currentToken !== null){
      store.dispatch("auth/setCredentials", currentToken);
      Vue.prototype.$axios.defaults.headers.common["Authorization"] = "Bearer " + currentToken;
    }

    //check if user is authenticated
    const user = await accountService.Authenticated();
    if (user !== null) store.dispatch("auth/fetchUser", user);
    else {
      //otherwise redirect to login
      next({ name: "login" });
    }
  }
  next();
});

export default router;
