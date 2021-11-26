<template>
  <div>
    <p>Admin</p>
    <div v-if="isLoggedIn">{{ getAll }}</div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'Home',
  computed: {
    ...mapGetters("user", ["isLoggedIn"]),
    ...mapActions("user", ["all"]),
    getAll() {
      return JSON.stringify(this.$store.state.user.all);
    }
  },
  created: async function() {
    await this.all;
  }
}
</script>
