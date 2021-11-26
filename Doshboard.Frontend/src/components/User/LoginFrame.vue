<template>
    <Frame>
        <form id="login" @submit.prevent="send">
            <input name="identifier" v-model="username" required placeholder="Username / Email" />
            <input name="password" v-model="password" required placeholder="Password" /> 
            <input type="submit" value="Login" />
        </form>
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
      password: ""
    }
  },
  methods: {
    ...mapActions("user", ["login"]),
    async send(e) {
      e.preventDefault();

      await this.login({username: this.username, password: this.password});
      this.$router.push("/");
    }
  }
}
</script>