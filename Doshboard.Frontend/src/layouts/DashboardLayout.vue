<template>
    <div id="content">
        <Header/>
        <div id="body">
            <div id="left">
                <a href="/dashboard" @click.prevent="clickDashboard"><i class="fa fa-home"></i></a>
                <a href="/settings" @click.prevent="clickSettings"><i class="fa fa-cog"></i></a>
                <router-link to="/widgets"><i class="uis uis-apps"></i></router-link>
                <a href="/" @click.prevent="clickLogout"><i class="uis uis-signout"></i></a>
                <img id="avatar" src="https://imgsrv2.voi.id/ZX5NI_OyT7ebOGfkfnBBKLg4sVTFvxcAoHQSyJPTEk0/auto/1200/675/sm/1/bG9jYWw6Ly8vcHVibGlzaGVycy80NjU1MC8yMDIxMDQyMzE1MjMtbWFpbi5jcm9wcGVkXzE2MTkxNjYyMDIuanBn.jpg" />
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
}

#left > * {
    margin: 40% 0 40% 15%;
}

#left {
    display: flex;
    flex-direction: column;
    width: 6%;
}

#right {
    width: 94%;
}

i {
    font-size: 2.5em !important;
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

