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
                    <grid-layout :layout.sync="layout" :col-num="6" :row-height="80" :is-draggable="true" :is-resizable="true" :is-mirrored="false" :vertical-compact="true" :margin="[40, 40]" :use-css-transforms="true" @breakpoint-changed="breakpointChangedEvent">
                        <grid-item v-for="item in layout" :x="item.x" :y="item.y" :w="item.width" :h="item.height" :i="item.i" :key="item.id" @resize="eventResize">
                            {{ item.id }}
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
    import { mapActions } from 'vuex'

    export default Vue.extend({
        name: 'Dashboard',
        components: {
            GridLayout: VueGridLayout.GridLayout,
            GridItem: VueGridLayout.GridItem,
            Header, vuescroll
        },
        data: function () {
            return {
                layout: [],
            }
        },
        methods: {
            ...mapActions("widget", ["get"]),
            eventResize(i, newH, newW, newHPx, newWPx) {
                const msg = "RESIZE i=" + i + ", H=" + newH + ", W=" + newW + ", H(px)=" + newHPx + ", W(px)=" + newWPx;
                newH = 10;
                newW = 10;
                console.log(msg);
            },
            breakpointChangedEvent(newBreakpoint, newLayout){
                console.log("BREAKPOINT CHANGED breakpoint=", newBreakpoint, ", layout: ", newLayout );
            },
        },
        created: async function() {
            this.layout = await this.get();
        }
    })
</script>