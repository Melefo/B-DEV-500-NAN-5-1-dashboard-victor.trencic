<template>
  <div id="home">
      <Header/>
      <div id="content">
        <a href="Dashboard">Dashboard</a>
        <RegisterFrame />
        <LoginFrame />
        <p>{{ users() }}</p>
      </div>
  </div>
</template>

<style>
  #home {
    height: 100%;
    width: 100%;
  }
  #content {
    height: 100%;
    width: 100%;
    display: flex;
  }
</style>

<script>
import RegisterFrame from '@/components/RegisterFrame.vue'
import LoginFrame from '@/components/LoginFrame.vue'
import Header from '@/components/Header.vue'

export default {
  name: 'Home',
  components: {
    RegisterFrame, LoginFrame, Header
  },
  data: function() {
    const post = 'bonjour'
    return {
      post: post
    }
  },
  created: function() {
    this.fetchData();
  },
  watch: {
    '$route': 'fetchData'
  },
  computed: {
    users() {
      return JSON.stringify(this.$store.state.users.all);
    }
  },
  methods: {
    fetchData() {
      this.$store.dispatch('users/getAll');
      return;
    }
  }
}
</script>
