import tweetService from "@/services/TweetService"
const tweet = {
  namespaced: true,
  state: {
    tweets: [],
  },
  mutations: {
    SET_TWEETS(state, payload) {
      state.tweets = payload;
    }
  },
  actions: {
    setTweets({ commit }, data ) {
      commit("SET_TWEETS", data);
    },
    async loadTweets({ commit } ) {
      let res = await tweetService.Tweets()
      commit("SET_TWEETS", res);
    },    
  },
  getters: {
    tweets: function(state) {
      return state.tweets;
    }    
  }
};
export default tweet;
