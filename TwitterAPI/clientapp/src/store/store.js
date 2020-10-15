import Vue from 'vue'
import Vuex from 'vuex'

import auth from './modules/auth'
import util from './modules/util'
import tweet from './modules/tweet'
Vue.use(Vuex)

export default new Vuex.Store({
    modules: {
      auth: auth,
      util: util,
      tweet: tweet
  }
})