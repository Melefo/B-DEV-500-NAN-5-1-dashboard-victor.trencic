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
                <slot></slot>
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

    export default Vue.extend({
        name: 'Dashboard',
        components: {
            Header
        }
    })
</script>

