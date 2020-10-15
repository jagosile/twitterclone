//import Vue from "vue";

const util = {
  namespaced: true,
  state: {
    loading: false,
    modalComponent: null
  },
  mutations: {
    SET_LOADING(state, payload) {
      state.loading = payload;
    },
    SET_MODAL_COMPONENT(state, payload){
      state.modalComponent = payload;
    }
  },
  actions: {
    setLoading({ commit }, data ) {
      commit("SET_LOADING", data);
    },
    setModalComponent({ commit }, data ) {
      commit("SET_MODAL_COMPONENT", data);
    } ,  
  },
  getters: {
    loading: function(state) {
      return state.loading;
    },
    modalComponent: function(state) {
      return state.modalComponent;
    }            
  }
};
export default util;
