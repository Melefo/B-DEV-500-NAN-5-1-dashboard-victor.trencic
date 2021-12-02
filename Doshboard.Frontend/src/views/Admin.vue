<template>
  <div>
    <p>Admin</p>
    <div v-if="isLoggedIn">
      <div v-for="user in users" :key="user.id" class="user">
        <p>id: <b>{{ user.id }}</b></p>
        <p>username: <b>{{ user.username }}</b></p>
        <p>email: <b>{{ user.email }}</b></p>
        <p>first name: <b>{{ user.firstName }}</b></p>
        <p>last name: <b>{{ user.lastName }}</b></p>
        <button @click="del(user.id)" >Delete</button>
        <button @click="promote(user.id)">Promote / Dedmote</button>
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
  name: 'Admin',
  computed: {
    ...mapGetters("user", ["isLoggedIn"]),
  },
  methods:{
    ...mapActions("user", ["all", "promote", "del"]),
  },
  data: function() {
    return {
      users : []
    }
  },
  created: async function() {
    this.users = await this.all();
  }
}
</script>
