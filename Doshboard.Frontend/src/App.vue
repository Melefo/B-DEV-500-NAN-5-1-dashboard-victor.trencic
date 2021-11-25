<template>
  <div id="app">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <Background />
    <Foreground>
      <router-view />
    </Foreground>
  </div>
</template>

<style>
    html, body {
        height: 100%;
        width: 100%;
        text-align: center;
        overflow: hidden;
    }

    body {
        background: #E7E7E7;
    }

    #app {
      display: flex;
      height: 100%;
      width: 100%;
      justify-content: center;
      align-items: center;
    }
</style>

<script lang="ts">
import Vue from 'vue'
import Background from '@/components/Background.vue'
import Foreground from '@/components/Foreground.vue'

export default Vue.extend({
  components: {
    Background, Foreground
  }
})
</script>