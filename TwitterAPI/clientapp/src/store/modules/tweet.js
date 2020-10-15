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
    async loadTweets({ commit } ) {
      commit("SET_TWEETS", []);
      let res = await tweetService.Tweets()
      commit("SET_TWEETS", res);
    },  
    async loadTweetsByUser({ commit }, data ) {
      commit("SET_TWEETS", []);
      let res = await tweetService.TweetsByUsers(data)
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
