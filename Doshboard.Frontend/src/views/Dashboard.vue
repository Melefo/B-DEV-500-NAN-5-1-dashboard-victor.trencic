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
                <vuescroll>
                    <grid-layout :layout.sync="layout" :col-num="6" :row-height="80" :is-draggable="true" :is-resizable="true" :is-mirrored="false" :vertical-compact="true" :margin="[40, 40]" :use-css-transforms="true">
                        <grid-item v-for="item in layout" :x="item.x" :y="item.y" :w="item.w" :h="item.h" :i="item.i" :key="item.i">
                            {{ item.i }}
                        </grid-item>
                    </grid-layout>
                </vuescroll>
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

.vue-grid-item {
    background: rgba(255, 255, 255, 0.5);
    border-radius: 25px;
    backdrop-filter: blur(30px);
    box-shadow: 10px 5px 10px #00000010;
}

.vue-resizable-handle {
    background: none !important;
}
</style>

<script lang="ts">
    import Vue from 'vue'
    import VueGridLayout from 'vue-grid-layout'
    import Header from '@/components/Header.vue'
    import vuescroll from 'vuescroll'

    export default Vue.extend({
        name: 'Dashboard',
        components: {
            GridLayout: VueGridLayout.GridLayout,
            GridItem: VueGridLayout.GridItem,
            Header, vuescroll
        },
        data: function () {
            return {
                layout: [
                    {"x":0,"y":0,"w":2,"h":1,"i":"0"},
                    {"x":2,"y":0,"w":2,"h":3,"i":"1"},
                    {"x":4,"y":0,"w":2,"h":3,"i":"2"},
                    {"x":0,"y":1,"w":2,"h":3,"i":"3"},
                    {"x":2,"y":2,"w":2,"h":2,"i":"4"},
                    {"x":4,"y":2,"w":2,"h":2,"i":"5"},
                ],
            }
        }
    })
</script>