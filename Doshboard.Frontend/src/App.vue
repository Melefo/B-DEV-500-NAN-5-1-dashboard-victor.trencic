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

    * {
        font-family: 'AvenirLTStd';
    }

    #app {
      display: flex;
      height: 100%;
      width: 100%;
      justify-content: center;
      align-items: center;
    }

    input {
      border: none;
      padding: 10px 20px;
      border-radius: 20px;
      box-shadow: 0 2px 1px #88888866;
      color: grey;
      background: white;
    }

    input::placeholder {
      color: grey;
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