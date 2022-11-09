<script setup>
import Navbar from "./components/Navbar/Navbar.vue";
import { useLoginStore } from "./stores/login";
const loginStore = useLoginStore();
const isActive = loginStore.isLogin;
</script>

<template>
  <Navbar :isActiveLogin="loginStore.isLogin" />
  <RouterView /> 
</template>
<style scoped>
</style>
