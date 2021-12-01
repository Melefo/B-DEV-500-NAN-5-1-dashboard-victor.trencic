<template>
    <div id="weather-widget">
        <div class="temperature">{{ weather.temp }}</div>
        <div class="humidity">{{ weather.humidity }}☔</div>
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
        methods: {
            ...mapActions("weather", ["getById"]),
        },
        props : {
            id: Number
        },
        data: function () {
            return {
                weather:[]
            }
        },
        created: async function() {
            this.weather = await this.getById(this.id);
        }
    })
</script>