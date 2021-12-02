<template>
    <div id="frame">
        <form id="register" @submit.prevent="send">
            <div>
              <input name="firstname" required placeholder="First Name" type="text" v-model="firstname" />
              <input name="lastname" required placeholder="Last Name" type="text" v-model="lastname" />
            </div>
            <div>
              <input name="username" required placeholder="Username" type="text" v-model="username" />
            </div>
            <div>
              <input name="email" required placeholder="Email" type="email" v-model="email" />
            </div>
            <div>
              <input name="password" required placeholder="Password" type="password" v-model="password"/>
              <input name="confirm" required placeholder="Confirm" type="password" v-model="confirm" />
            </div>
            <input type="submit" value="Register" />
        </form>
    </div>
</template>

<style>
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
  name: 'RegisterFrame',
  components: {
  },
  data: function() {
    return {
      firstname: "",
      lastname: "",
      username: "",
      email: "",
      password: "",
      confirm: ""
    }
  },
  methods: {
    ...mapActions("user", ["register"]),
    async send(e) {
      e.preventDefault();

      await this.register({firstName: this.firstname, lastName: this.lastname, username: this.username, email: this.email, password: this.password});
    }
  }
}
</script>