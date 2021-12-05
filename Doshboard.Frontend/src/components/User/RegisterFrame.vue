<template>
    <div id="frame">
      <h1>New to Doshboard?</h1>
      <code v-if="error">{{ this.error }}</code>
        <form id="register" @submit.prevent="send">
            <div>
              <code v-if="errors && errors.Firstname">{{ this.errors.Firstname }}</code>
              <input name="firstname" required placeholder="First Name" type="text" v-model="firstname" />
              <code v-if="errors && errors.Lastname">{{ this.errors.Lastname }}</code>
              <input name="lastname" required placeholder="Last Name" type="text" v-model="lastname" />
            </div>
            <div>
              <code v-if="errors && errors.Username">{{ this.errors.Username }}</code>
              <input name="username" required placeholder="Username" type="text" minlength="2" maxlength="256" v-model="username" />
            </div>
            <div>
              <code v-if="errors && errors.Email">{{ this.errors.Email }}</code>
              <input name="email" required placeholder="Email" type="email" v-model="email" />
            </div>
            <div>
              <code v-if="errors && errors.Password">{{ this.errors.Password }}</code>
              <input name="password" required placeholder="Password" type="password" minlength="4" maxlength="256" v-model="password"/>
              <code v-if="errors && errors.Confirm">{{ this.errors.Confirm }}</code>
              <input name="confirm" required placeholder="Confirm" type="password" minlength="4" maxlength="256" v-model="confirm" />
            </div>
            <input type="submit" value="Register" />
        </form>
        <code v-if="!error && !errors && sent">You can now authenticate</code>
    </div>
</template>

<style>

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
      confirm: "",
      error: null,
      errors: null,
      sent: false
    }
  },
  methods: {
    ...mapActions("user", ["register"]),
    async send(e) {
      e.preventDefault();

      if (this.password != this.confirm) {
        this.errors = {}
        this.errors.Confirm = "Confirmation doesn't match password";
        return;
      }

      const { error, errors } = await this.register({firstName: this.firstname, lastName: this.lastname, username: this.username, email: this.email, password: this.password});
      this.error = error || null;
      this.errors = errors || null;
      this.sent = true
    }
  }
}
</script>