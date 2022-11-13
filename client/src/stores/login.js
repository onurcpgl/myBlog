import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import { loginAxios } from "../service/Login/login";

export const useLoginStore = defineStore('login', () => {
  const isLogin = ref(false);
  const isAdmin = ref(false);
  const userToken = ref(localStorage.getItem("token"));

  
  async function startLogin(params) {
    const result = await loginAxios();
    console.log(result.data.result.accessToken);
    localStorage.setItem("token",result.data.result.accessToken);
    isLogin.value = true;
    window.location.reload();
    return result; 
  }
  async function logout(params) {
    localStorage.removeItem("token");
    isLogin.value = false; 
    window.location.reload();
  }

  return { isLogin, startLogin,logout,userToken }
})
