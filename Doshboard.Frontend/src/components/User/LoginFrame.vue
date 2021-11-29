<template>
    <Frame>
        <form id="login" @submit.prevent="send">
            <input name="identifier" v-model="username" required placeholder="Username / Email" />
            <input name="password" v-model="password" required placeholder="Password" /> 
            <input type="submit" value="Login" />
        </form>
        <button @click="handleClickSignIn" :disabled="!isLoaded">signIn</button>
    </Frame>
</template>

<style>
  form#login {
    display: flex;
    flex-direction: column;
  }
</style>

<script>
import Frame from '@/components/Frame.vue'
import { mapActions } from 'vuex'

export default {
  name: 'LoginFrame',
  components: {
    Frame
  },
  data: () => {
    return {
      username: "",
      password: "",
      isLoaded: true
    }
  },
  methods: {
    ...mapActions("user", ["login"]),
    async send(e) {
      e.preventDefault();

      await this.login({username: this.username, password: this.password});
      this.$router.push("/");
    },
    async handleClickSignIn() {
      const test = await this.$gAuth.getAuthCode()
      /*const test2 = await this.$gAuth.signIn(function (user) {
        //on success do something
      console.log('user', user)
      }, function (error) {
        console.log(error)
        //on fail do something
      })*/
      console.log(test)
      //console.log(test2)
    }
  }
}
</script>