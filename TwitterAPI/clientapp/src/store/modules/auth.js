
const auth = {
  namespaced: true,
  state: {
    user: {
      loggedIn: false,
      data: null
    }
  },
  getters: {
    user(state){
      return state.user
    },
    credentials(state){
      return state.credentials
    }
  },
  mutations: {
    SET_CREDENTIALS(state, data) {      
      localStorage.setItem('auth-token', data); // stash the auth token in localStorage 
    },

    SET_LOGGED_IN(state, data) {
      state.user.loggedIn = data;
    },

    SET_USER(state, data) {
      state.user.data = data;
    }
  },
  actions: {
    setCredentials({ commit }, data) {
      commit("SET_CREDENTIALS", data);
    },     
    fetchUser({ commit }, user) {
      commit("SET_LOGGED_IN", user !== null);
      if (user) {
        commit("SET_USER", user);
      } else {
        commit("SET_USER", null);
      }
    }
  }
 
};
export default auth;
