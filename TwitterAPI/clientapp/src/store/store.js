import Vue from 'vue'
import Vuex from 'vuex'

import auth from './modules/auth'
import util from './modules/util'
Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
      auth: auth,
      util: util
  }
})