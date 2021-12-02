<template>
  <div id="home">
      <Header/>
      <div id="content">
        <RegisterFrame />
        <LoginFrame />
      </div>
  </div>
</template>

<style scoped>
  #home {
    height: 100%;
    width: 100%;
  }
  #content {
    height: 80%;
    width: 100%;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
  }
</style>

<script>
import RegisterFrame from '@/components/User/RegisterFrame.vue'
import LoginFrame from '@/components/User/LoginFrame.vue'
import Header from '@/components/Header.vue'

export default {
  name: 'Login',
  components: {
    RegisterFrame, LoginFrame, Header
  }
}
</script>
