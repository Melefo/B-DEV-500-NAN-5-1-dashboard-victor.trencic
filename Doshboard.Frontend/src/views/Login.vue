<template>
  <div id="home">
      <Header/>
      <div id="frames">
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
  #frames {
    height: 80%;
    width: 100%;
    display: flex;
    flex-direction: row;
    justify-content: space-evenly;
    align-items: center;
  }

  #frame {
    background: rgba(255, 255, 255, 0.3);
    border-radius: 20px;
    backdrop-filter: blur(30px);
    box-shadow: 10px 5px 10px #00000010;
    width: 100%;
    height: 50%;
    margin: 10%;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    }

@media only screen and (max-width: 768px) {
  #content {
    flex-direction: column;
  }
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
