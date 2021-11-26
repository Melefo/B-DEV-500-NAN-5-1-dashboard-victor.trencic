<template>
  <div>
    <p>Admin</p>
    <div v-if="isLoggedIn">
      <div v-for="user in users" :key="user.id" class="user">
        <p>id: {{ user.id }}</p>
        <p>username: {{ user.username }}</p>
        <p>email: {{ user.email }}</p>
        <p>first name: {{ user.firstName }}</p>
        <p>last name: {{ user.lastName }}</p>
        <p>password: {{ user.password }}</p>
      </div>
    </div>
  </div>
</template>

<style scoped>
  .user {
    display: flex;
    justify-content: space-evenly;
  }
</style>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'Home',
  computed: {
    ...mapGetters("user", ["isLoggedIn"]),
    ...mapActions("user", ["all"]),
  },
  data: function() {
    return {
      users : []
    }
  },
  created: async function() {
    this.users = await this.all;
  }
}
</script>
