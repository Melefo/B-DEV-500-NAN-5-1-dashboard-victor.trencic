<template>
    <div id="frame">
        <code v-if="error">{{ error }}</code>
        <form id="login" @submit.prevent="send">
            <code v-if="errors && errors.Username">{{ errors.Username }}</code>
            <input name="identifier" type="text" minlength="2" maxlength="256" v-model="username" required placeholder="Username / Email" />
            <code v-if="errors && errors.Password">{{ errors.Password }}</code>
            <input name="password" type="password" minlength="4" maxlength="256" v-model="password" required placeholder="Password" /> 
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
      error: null,
      errors: null,
    }
  },
  methods: {
    ...mapActions("user", ["login", "googleLogin"]),
    async send(e) {
      e.preventDefault();

      const { error, errors } = await this.login({username: this.username, password: this.password});
      this.error = error
      this.errors = errors
      if (!this.error && !this.errors) {
        this.$router.push("/");
      }
    },
    async handleClickSignIn() {
      try {
        const code = await this.$gAuth.getAuthCode();
        const { error, errors } = await this.googleLogin(code);
        this.error = error;
        this.errors = errors;
        if (!this.error && !this.errors) {
          this.$router.push("/");
        }
      }
      catch {
        this.error = "Error with Google OAuth"; 
      }
    }
  }
}
</script>