<template>
    <vuescroll>
        <grid-layout :layout.sync="layout" :col-num="6" :row-height="80" :is-draggable="true" :is-resizable="false" :is-mirrored="false" :vertical-compact="true" :margin="[20, 20]" :use-css-transforms="true">
            <grid-item v-for="item in layout" :x="item.x" :y="item.y" :w="item.w" :h="item.h" :i="item.i" :key="item.i" @moved="movedEvent">
                <CityTemp v-if="item.type == 'city_temperature'" :id=item.i :params=item.params :config="$attrs.config || false" @deleted="deleteItem(item.i)" />
                <RealTimeCrypto v-if="item.type == 'realtime_crypto'" :id=item.i :params="item.params" :config="$attrs.config || false" @deleted="deleteItem(item.i)" />
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
    import CityTemp from '@/components/Widgets/CityTemp.vue'
    import RealTimeCrypto from '@/components/Widgets/RealTimeCrypto.vue'

    export default Vue.extend({
        name: 'Dashboard',
        components: {
            GridLayout: VueGridLayout.GridLayout,
            GridItem: VueGridLayout.GridItem,
            vuescroll, CityTemp, RealTimeCrypto
        },
        data: function () {
            return {
                layout: [] as any[]
            }
        },
        methods: {
            ...mapActions("widget", ["get", "delete", "update"]),
            deleteItem(id) {
                this.delete(id);
                this.layout = this.layout.filter(item => item.i !== id);
            },
            movedEvent(i, newX, newY){
                this.update({id: i, x: newX, y: newY}),
                console.log("MOVED i=" + i + ", X=" + newX + ", Y=" + newY);
            },
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

