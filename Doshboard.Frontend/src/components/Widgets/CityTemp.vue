<template>
    <div id="temp-widget" v-if=!config>
        <code v-if='error'>{{ this.error }}</code>
        <div v-else-if="weather" id="data">
            <div class="icon">
                <img :src=weather.icon width="80%">
            </div>
            <div>
                <h1 class="temperature">{{ weather.temp }}°</h1>
                <div class="humidity">{{ weather.humidity }}% ☔</div>
                <div class="city"><b>{{ weather.city }}</b></div>
            </div>
        </div>
    </div>
    <div id="temp-widget" v-else>
        <code v-if='error'>{{ this.error }}</code>
        <input type="submit" @click="clickDelete" value="X" />
        <input type="text" placeholder="City" v-model="params.city" @change="send" />
        <select v-model="params.unit" @change="send">
            <option value="0">Celsius</option>
            <option value="1">Fahrenheit</option>
            <option value="2">Kelvin</option>
        </select>
        Refresh rate<input type="number" placeholder="Timer" v-model="params.timer" @change="timer" />
    </div>
</template>

<style scoped>
#temp-widget {
    height: 100%;
}

#data {
        display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: space-evenly;
    height: 100%;
}

img {
        background: linear-gradient(180deg, #97f1ec, #d9c5f8);
    border-radius: 100px;
}
</style>

<script lang="ts">
    import Vue from 'vue'
    import { mapActions } from 'vuex';

    export default Vue.extend({
        name: 'CityTemp',
        methods: {
            ...mapActions("weather", ["getById", "update"]),
            async clickDelete(e) {
                e.preventDefault();
                await this.ws.invoke("DeleteTimer", this.id);
                this.$emit('deleted');
            },
            async send() {
                if (this.params.city == '')
                    this.params.city = null;
                if (this.params.unit == '')
                    this.params.unit = null;
                const { error } = await this.update({ id: this.id, city: this.params.city, unit: parseInt(this.params.unit)})
                this.error = error
                if (this.error)
                    return;
                const { success, json } = await this.getById(this.id);
                if (success)
                    this.weather = json;
                else
                    this.error = json;
            },
            async timer() {
                if (this.params.timer < 1) {
                    this.params.timer = 1;
                    return;
                }
                await this.ws.invoke("UpdateTimer", this.id, parseInt(this.params.timer));
            }
        },
        props : {
            id: String,
            config: Boolean,
            params: Object,
            ws: Object
        },
        data: function () {
            return {
                weather: null,
                error: null,
            }
        },
        created: async function() {
        const { success, json } = await this.getById(this.id);
            if (success)
                this.weather = json;
            else
                this.error = json;

            this.ws.on(this.id, (e) => {
                this.weather = e;
            })
        }
    })
</script>