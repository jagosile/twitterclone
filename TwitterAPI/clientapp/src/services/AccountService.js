import Vue from "vue";






export default new (class AccountService {


  async Authenticated() {
    const path = "/api/accounts/authenticated";
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

  async Create(email, password) {
    const path = "/api/accounts/create";
    let result = null;
    await Vue.prototype.$axios({
      url: path,
      method: "post",
      data: {email: email, password: password},
    })
      .then((response) => {
        result = response.data;
      })
      .catch((error) => {
        console.log(error);
      });

    return result;
  } 

  async Login(email, password) {
    const path = "/api/accounts/login";
    let result = null;
    await Vue.prototype.$axios({
      url: path,
      method: "post",
      data: {email: email, password: password},
    })
      .then((response) => {
        result = response.data;
      })
      .catch((error) => {
        console.log(error.response.data)
      });

    return result;
  } 

  async Logout() {
    const path = "/api/account/logout";
    let result = null;
    await Vue.prototype.$axios
      .get(path)
      .then((response) => {
        result = response.data;
      })
      .catch((error) => {
       return error
      });

    return result;
  }



  async Users() {
    const path = "/api/account/users";
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

  async SaveUser(user) {
    const path = "/api/accounts/edit";
    let result = null;
    await Vue.prototype.$axios({
      url: path,
      method: "post",
      data: user
    })
      .then((response) => {
        result = response.data;
      })
      .catch((error) => {
        console.log(error);
      });
      

    return result;
  } 

  
  async DeleteUser(userId) {
    const path = "/api/accounts/delete";
    let result = null;
    await Vue.prototype.$axios({
      url: path,
      method: "delete",
      params: {userId : userId}
    })
      .then((response) => {
        result = response.data;
      })
      .catch((error) => {
        console.log(error);
      });
    return result;
  } 

  async ResetPassword(email) {
    const path = `/api/accounts/resetpassword/${email}`;
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
