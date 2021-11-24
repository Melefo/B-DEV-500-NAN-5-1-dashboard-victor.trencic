<template>
  <div id="home">
      <Header/>
      <div id="content">
        <RegisterFrame />
        <LoginFrame />
      </div>
  </div>
</template>

<style>
  #home {
    height: 100%;
    width: 100%;
  }
  #content {
    height: 100%;
    width: 100%;
    display: flex;
  }
</style>

<script>
import RegisterFrame from '@/components/RegisterFrame.vue'
import LoginFrame from '@/components/LoginFrame.vue'
import Header from '@/components/Header.vue'

export default {
  name: 'Home',
  components: {
    RegisterFrame, LoginFrame, Header
  }
}
</script>
