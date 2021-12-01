<template>
    <Layout>
        <vuescroll>
            <grid-layout :layout.sync="layout" :col-num="6" :row-height="80" :is-draggable="true" :is-resizable="false" :is-mirrored="false" :vertical-compact="true" :margin="[20, 20]" :use-css-transforms="true">
                <grid-item v-for="(item, index) in layout" :x="item.x" :y="item.y" :w="item.w" :h="item.h" :i="item.i" :key="item.i">
                    <Weather v-if="item.type == 0" :id=index />
                </grid-item>
            </grid-layout>
        </vuescroll>
    </Layout>
</template>

<style>
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
    import Layout from '@/components/Layout.vue'
    import vuescroll from 'vuescroll'
    import { mapActions } from 'vuex'
    import Weather from '@/components/Widgets/Weather.vue'

    export default Vue.extend({
        name: 'Dashboard',
        components: {
            GridLayout: VueGridLayout.GridLayout,
            GridItem: VueGridLayout.GridItem,
            Layout, vuescroll, Weather
        },
        data: function () {
            return {
                layout: []
            }
        },
        methods: {
            ...mapActions("widget", ["get"])
        },
        created: async function() {
            const data = await this.get();
            this.layout = data.map((item) => {
                console.log(item);
                return {
                    x: item.x,
                    y: item.y,
                    w: item.width,
                    h: item.height,
                    i: item.id,
                    type: item.type
                }
            })
        }
    })
</script>

