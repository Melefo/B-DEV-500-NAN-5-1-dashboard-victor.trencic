<template>
    <vuescroll>
        <grid-layout :layout.sync="layout" :col-num="6" :row-height="80" :is-draggable="true" :is-resizable="false" :is-mirrored="false" :vertical-compact="true" :margin="[20, 20]" :use-css-transforms="true">
            <grid-item v-for="item in layout" :x="item.x" :y="item.y" :w="item.w" :h="item.h" :i="item.i" :key="item.i">
                <Weather v-if="item.type == 'city_temperature'" :id=item.i :params=item.params :config="$attrs.config || false" @deleted="deleteItem(item.i)" />
            </grid-item>
        </grid-layout>
    </vuescroll>
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
    import vuescroll from 'vuescroll'
    import { mapActions } from 'vuex'
    import Weather from '@/components/Widgets/Weather.vue'

    export default Vue.extend({
        name: 'Dashboard',
        components: {
            GridLayout: VueGridLayout.GridLayout,
            GridItem: VueGridLayout.GridItem,
            vuescroll, Weather
        },
        data: function () {
            return {
                layout: [] as any[]
            }
        },
        methods: {
            ...mapActions("widget", ["get", "delete"]),
            deleteItem(id) {
                this.delete(id);
                this.layout = this.layout.filter(item => item.i !== id);
            }
        },
        created: async function() {
            const data = await this.get();
            this.layout = data.map((item) => {
                return {
                    x: item.x,
                    y: item.y,
                    w: item.width,
                    h: item.height,
                    i: item.id,
                    type: item.type,
                    params: item.params
                }
            })
        }
    })
</script>

