<template>
    <div id="content">
        <Header/>
        <div id="body">
            <div id="left">
                <router-link to="/dashboard"><i class="fa fa-home"></i></router-link>
                <router-link to="/settings"><i class="fa fa-cog"></i></router-link>
                <router-link to="/widgets"><i class="uis uis-apps"></i></router-link>
                <router-link to="/logout"><i class="uis uis-signout"></i></router-link>
                <img id="avatar" src="https://imgsrv2.voi.id/ZX5NI_OyT7ebOGfkfnBBKLg4sVTFvxcAoHQSyJPTEk0/auto/1200/675/sm/1/bG9jYWw6Ly8vcHVibGlzaGVycy80NjU1MC8yMDIxMDQyMzE1MjMtbWFpbi5jcm9wcGVkXzE2MTkxNjYyMDIuanBn.jpg" />
            </div>
            <div id="right">
               
            </div>
        </div>
    </div>
</template>

<style scoped>

</style>

<script lang="ts">
import Vue from 'vue'
import Header from '@/components/Header.vue'
import { mapActions } from 'vuex'

export default Vue.extend({
    name: 'Widgets',
    components: {
        Header
    },
    data: function() {
        return {
            services: []
        }
    },
    methods: {
        ...mapActions("about", ["get"])
    },
    created: async function() {
        this.get()
    }
})
</script>