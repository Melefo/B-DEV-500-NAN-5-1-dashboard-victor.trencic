<template>
    <div id="weather-widget">
        <div class="temperature">{{ weather.temp }}</div>
        <div class="humidity">{{ weather.humidity }}</div>
        <div class="icon"><img :src=weather.icon></div>
        <div class="city">{{ weather.city }}</div>
    </div>
</template>

<style scoped>

</style>

<script lang="ts">
    import Vue from 'vue'
    import { mapActions } from 'vuex';

    export default Vue.extend({
        name: 'Dashboard',
        computed: {
            ...mapActions("weather", ["get"]),
        },
        data: function () {
            return {
                weather:[]
            }
        },
        created: async function() {
                this.weather = await this.get;
        }
    })
</script>