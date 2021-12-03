<template>
    <div id="frame">
        <form id="login" @submit.prevent="send">
            <input name="identifier" v-model="username" required placeholder="Username / Email" />
            <input name="password" v-model="password" required placeholder="Password" /> 
            <input type="submit" value="Login" />
        </form>
        <button @click="handleClickSignIn">Google</button>
    </div>
</template>

<style>
  form#login {
    display: flex;
    flex-direction: column;
  }

  #frame {
    background: rgba(255, 255, 255, 0.3);
    border-radius: 50px;
    backdrop-filter: blur(30px);
    box-shadow: 10px 5px 10px #00000010;
}
</style>

<script>
import { mapActions } from 'vuex'

export default {
  name: 'LoginFrame',
  components: {
  },
  data: () => {
    return {
      username: "",
      password: "",
    }
  },
  methods: {
    ...mapActions("user", ["login", "googleLogin"]),
    async send(e) {
      e.preventDefault();

      await this.login({username: this.username, password: this.password});
      this.$router.push("/");
    },
    async handleClickSignIn() {
      const code = await this.$gAuth.getAuthCode()
      await this.googleLogin(code);
      this.$router.push("/");
    }
  }
}
</script>