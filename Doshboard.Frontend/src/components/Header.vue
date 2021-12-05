<template>
    <header id="header">
        <router-link to="/">
            <img src="@/assets/logo.png" />
        </router-link>
        <div v-if="!isLoggedIn">
            <h1>Welcome on the Doshboard</h1>
            <p>It's a great day for login or register</p>
        </div>
        <div v-else>
            <h1>Hello, {{ fullname }}</h1>
            <p>It's a great for a workout !</p>
        </div>
        <div>
            <DateTime />
        </div>
    </header>
</template>

<style scoped>
    h1, p {
        margin: 5px 0;
        text-align: left;
    }

    h1 {
        font-size: 32px;
    }
    
    p {
        font-size: 20px;
    }
</style>

<style>
#header {
    height: 20%;
    display: flex;
    flex-direction: row;
    width: 100%;
}

#header a {
  padding: 3%;
  padding-top: 2%;
  height: 40%;
}

#header img {
  height: 100%;
  transform: rotate(-17deg);
}

#header div:nth-child(2) {
    display: flex;
    flex-direction: column;
    justify-content: center;
    padding-left: 10%;
}
</style>

<script lang="ts">
import Vue from 'vue'
import DateTime from '@/components/Widgets/DateTime.vue'
    import { parseJwt } from "@/router/index"
import { mapGetters } from 'vuex'

export default Vue.extend({
    components: {
        DateTime
    },
    data: () => {
    return {
      fullname: null
    }
  },
    computed: {
        ...mapGetters("user", ["token", "isLoggedIn"])
    },
    created: function() {
        if (this.isLoggedIn)
            this.fullname = parseJwt(this.token).given_name
    }
})
</script>