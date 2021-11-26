<template>
    <div id="frame">
        <slot></slot>
    </div>
</template>

<style>
#frame {
    background: rgba(255, 255, 255, 0.3);
    border-radius: 50px;
    backdrop-filter: blur(30px);
    box-shadow: 10px 5px 10px #00000010;
}
</style>

<script lang="ts">
import Vue from 'vue'

export default Vue.extend({
    
})
</script>