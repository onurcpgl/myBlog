import { ref, computed } from 'vue'
import { defineStore } from 'pinia'
import { loginAxios } from "../service/Login/login";

export const useLoginStore = defineStore('login', () => {
  const isLogin = ref(false);
  const isAdmin = ref(false);
  
  async function startLogin(params) {
    const result = await loginAxios();
    isLogin.value = true;
    return result; 
  }

  return { isLogin, startLogin }
})
