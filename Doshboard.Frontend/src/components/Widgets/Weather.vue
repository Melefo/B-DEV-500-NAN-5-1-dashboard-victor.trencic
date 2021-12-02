<template>
    <div id="weather-widget" v-if=!config>
        <div class="temperature">{{ weather.temp }}</div>
        <div class="humidity">{{ weather.humidity }}☔</div>
        <div class="icon"><img :src=weather.icon></div>
        <div class="city">{{ weather.city }}</div>
    </div>
    <div id="weather-widget" v-else>
        <button type="button" @click="clickDelete">X</button>
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
            clickDelete(e) {
                e.preventDefault();
                console.log("DELETE");
                this.$destroy();
            }
        },
        props : {
            id: String,
            config: Boolean
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