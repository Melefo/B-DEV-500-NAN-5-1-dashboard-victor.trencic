<template>
    <div id="weather-widget" v-if=!config>
        <div class="temperature">{{ weather.temp }}</div>
        <div class="humidity">{{ weather.humidity }}☔</div>
        <div class="icon"><img :src=weather.icon></div>
        <div class="city">{{ weather.city }}</div>
    </div>
    <div id="weather-widget" v-else>
        <button type="button" @click="clickDelete">X</button>
        <input type="text" placeholder="City" v-model="params.city" @change="send" />
        <select v-model="params.unit" @change="send">
            <option value="0">Celsius</option>
            <option value="1">Fahrenheit</option>
            <option value="2">Kelvin</option>
        </select>
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
            ...mapActions("weather", ["getById", "update"]),
            clickDelete(e) {
                e.preventDefault();
                this.$emit('deleted');
            },
            async send() {
                await this.update({ id: this.id, city: this.params.city, unit: parseInt(this.params.unit)})
                this.weather = await this.getById(this.id);
            }
        },
        props : {
            id: String,
            config: Boolean,
            params: Object
        },
        data: function () {
            return {
                weather: {},
            }
        },
        created: async function() {
            this.weather = await this.getById(this.id);
        }
    })
</script>