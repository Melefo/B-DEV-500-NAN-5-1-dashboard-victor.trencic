<template>
    <div id="crypto-widget" v-if=!config>
        <code v-if='error'>{{ this.error }}</code>
        <div v-else-if="crypto" id="data">
            <img :src="crypto.logoUrl" />
            <div>
                <div>{{ crypto.currency }}</div>
                <div>{{ crypto.priceChange }}%</div>
            </div>
            <div>
                <div>{{ crypto.price }} {{ params.convert }}</div>
                <div>#{{ crypto.rank }}</div>
            </div>
        </div>
    </div>
    <div id="crypto-widget" v-else>
        <code v-if='error'>{{ this.error }}</code>
        <button type="button" @click="clickDelete">X</button>
        <input type="text" placeholder="Currency" required v-model="params.currency" @change="send" />
        <input type="text" placeholder="Convert" required v-model="params.convert" @change="send" />
        Refresh rate<input type="number" placeholder="Timer" v-model="params.timer" @change="timer" />
    </div>
</template>

<style scoped>
#crypto-widget {
    height: 100%;
}

#data {
    display: flex;
    flex-direction: row;
    justify-content: space-evenly;
    align-content: center;
    height: 100%;
}

#data > div {
    display: flex;
    flex-direction: column;
    justify-content: center;
    height: 100%;
}

img {
    width: 10%;
}
</style>

<script lang="ts">
    import Vue from 'vue'
    import { mapActions } from 'vuex';

    export default Vue.extend({
        name: 'RealTimeCrypto',
        methods: {
            ...mapActions("crypto", ["getById", "update"]),
            async clickDelete(e) {
                e.preventDefault();
                await this.ws.invoke("DeleteTimer", this.id);
                this.$emit('deleted');
            },
            async send() {
                if (this.params.currency == '')
                    this.params.currency = null;
                if (this.params.convert == '')
                    this.params.convert = null;
                const { error } = await this.update({ id: this.id, currency: this.params.currency, convert: this.params.convert})
                this.error = error
                if (this.error)
                    return;
                const { success, json } = await this.getById(this.id);
                if (success)
                    this.crypto = json;
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
                crypto: null,
                error: null,
            }
        },
        created: async function() {
            const { success, json } = await this.getById(this.id);
            if (success)
                this.crypto = json;
            else
                this.error = json;

            this.ws.on(this.id, (e) => {
                this.crypto = e;
            })
        }
    })
</script>