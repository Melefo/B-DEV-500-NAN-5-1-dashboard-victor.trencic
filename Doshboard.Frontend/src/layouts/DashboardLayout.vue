<template>
    <div id="content">
        <Header/>
        <div id="body">
            <div id="left">
                <a href="/dashboard" @click.prevent="clickDashboard"><i class="fa fa-home"></i></a>
                <a href="/settings" @click.prevent="clickSettings"><i class="fa fa-cog"></i></a>
                <router-link to="/widgets"><i class="uis uis-apps"></i></router-link>
                <router-link v-if=isAdmin to="/admin"><i class="fa fa-key"></i></router-link>
                <a href="/" @click.prevent="clickLogout"><i class="uis uis-signout"></i></a>
            </div>
            <div id="right">
                <slot :config=config></slot>
            </div>
        </div>
    </div>
</template>

<style>

#content {
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
}
#body {
    display: flex;
    width: 100%;
    overflow: hidden;
    height: 100%;
}

#left {
    display: flex;
    flex-direction: column;
    width: 6%;
    justify-content: space-evenly;
}

#left a {
    color: black;
}

#left a:hover {
    color: black;
}

#right {
    width: 94%;
}

i {
    font-size: 2.5em !important;
    transition: color 0.1s;
}

a:hover i {
    color: #359DBE;
}

#avatar {
    border-radius: 50%;
    object-fit: cover;
    width: 75px;
    height: 75px;
}
</style>

<script lang="ts">
    import Vue from 'vue'
    import Header from '@/components/Header.vue'
    import { mapActions } from 'vuex'
    import { mapGetters } from 'vuex'

    export default Vue.extend({
        name: 'DashboardLayout',
        components: {
            Header
        },
        data: function () {
            return {
                config: false
            }
        },
        computed: {
            ...mapGetters("user", ["isAdmin"])
        },
        methods: {
            ...mapActions("user", ["logout"]),
            clickLogout(e) {
                e.preventDefault();
                this.logout();
                this.$router.push('/');
            },
            clickSettings(e) {
                e.preventDefault();
                this.config = true;
                if (this.$route.path != '/dashboard')
                    this.$router.push('/dashboard');
            },
            clickDashboard(e) {
                e.preventDefault();
                this.config = false;
                if (this.$route.path != '/dashboard')
                    this.$router.push('/dashboard');
            }
        }
    })
</script>

