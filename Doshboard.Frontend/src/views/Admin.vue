<template>
  <div>
    <p>Admin</p>
    <div v-if="isLoggedIn">
      <table>
        <tr>
          <th>ID</th>
          <th>Username</th>
          <th>Email</th>
          <th>Fullname</th>
          <th>Role</th>
          <th>Action</th>
        </tr>
        <tr v-for="(user, key) in users" :key="user.id">
          <td>{{ user.id }}</td>
          <td>{{ user.username }}</td>
          <td>{{ user.email }}</td>
          <td>{{ user.firstName }} {{ user.lastName }}</td>
          <td>{{ user.role }}</td>
          <td>
            <input type="submit" @click="deleted($event, user.id, key)" value="Delete" />
            <input type="submit" @click="mote($event, user.id, key)" :value="user.role == 'Admin' ? 'Demote' : 'Promote'" />
          </td>
        </tr>
      </table>
    </div>
  </div>
</template>

<style scoped>
  .user {
    display: flex;
    justify-content: space-evenly;
  }

  table {
    width: 100%;
    border-spacing: 0 1.5em;
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
    deleted(e, id, key) {
      e.preventDefault();
      this.del(id);
      this.users.splice(key, 1);
    },
    mote(e, id, key) {
      e.preventDefault();
      this.promote(id);
      this.users[key].role = this.users[key].role == 'Admin' ? 'User' : 'Admin';
    }
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
