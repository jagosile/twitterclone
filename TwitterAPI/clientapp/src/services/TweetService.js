import Vue from "vue";






export default new (class TweetService {


  async Create(message) {
    const path = "/api/tweets/create";
    let result = null;
    await Vue.prototype.$axios({
      url: path,
      method: "post",
      data: {body: message},
    })
      .then((response) => {
        result = response.data;
      })
      .catch((error) => {
        console.log(error);
      });

    return result;
  } 

  async Tweets() {
    const path = "/api/tweets/tweets";
    let result = null;
    await Vue.prototype.$axios
      .get(path)
      .then((response) => {
        result = response.data;
      })
      .catch((error) => {
        console.log(error);
      });

    return result;
  }

  async Delete(id) {
    const path = `/api/tweets/delete/${id}`;
    let result = null;
    await Vue.prototype.$axios
      .get(path)
      .then((response) => {
        result = response.data;
      })
      .catch((error) => {
        console.log(error);
      });

    return result;
  }

  
      

  
  

})();
