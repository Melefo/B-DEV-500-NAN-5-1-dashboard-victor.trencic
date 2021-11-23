<template>
    <div id="background">
        <Blue :styles="{top: '8%', left: '-37%'}" />
        <Green :styles="{top: '40%'}" />
        <Pink :styles="{right: '-37%', top:'10%'}" />
        <Red />
        <Orange />
        <Hologram />
    </div>
</template>

<style>
    #background {
       position: absolute;
        height: 100%;
        width: 100%;
        z-index: -1;
    }
</style>

<script lang="ts">
import Vue from 'vue'
import Blue from '@/components/Blobs/Blue.vue'
import Green from '@/components/Blobs/Green.vue'
import Pink from '@/components/Blobs/Pink.vue'
import Red from '@/components/Blobs/Red.vue'
import Orange from '@/components/Blobs/Orange.vue'
import Hologram from '@/components/Blobs/Hologram.vue'

export default Vue.extend({
    components: {
        Blue, Green, Pink, Red, Orange, Hologram
    }
})
</script>