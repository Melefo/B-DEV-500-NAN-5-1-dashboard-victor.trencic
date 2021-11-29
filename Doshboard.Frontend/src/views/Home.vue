<template>
  <div>
    <p>Welcome!</p>
    <router-link v-if="!isLoggedIn" to="/login">
      <p>Login</p>
    </router-link>
    <router-link v-if="isLoggedIn" to="/dashobard">
      <p>Dashboard</p>
    </router-link>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'Home',
  computed: {
    ...mapGetters("user", ["isLoggedIn"])
  }
}
</script>
