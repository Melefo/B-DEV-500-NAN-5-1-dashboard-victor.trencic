<template>
    <div id="crypto-widget" v-if=!config>
        <img :src="crypto.logoUrl" />
        <div>{{ crypto.currency }}</div>
        <div>{{ crypto.priceChange }}%</div>
        <div>{{ crypto.price }}</div>
        <div>{{ crypto.rank }}</div>

    </div>
    <div id="crypto-widget" v-else>
        <button type="button" @click="clickDelete">X</button>
        <input type="text" placeholder="Currency" v-model="params.currency" @change="send" />
        <input type="text" placeholder="Convert" v-model="params.convert" @change="send" />
        <input type="number" placeholder="Timer" v-model="params.timer" @change="timer" />
    </div>
</template>

<style scoped>

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
                await this.update({ id: this.id, currency: this.params.currency, convert: this.params.convert})
                this.crypto = await this.getById(this.id);
            },
            async timer() {
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
                crypto: {},
            }
        },
        created: async function() {
            this.crypto = await this.getById(this.id);

            this.ws.on(this.id, (e) => {
                this.crypto = e;
            })
        }
    })
</script>