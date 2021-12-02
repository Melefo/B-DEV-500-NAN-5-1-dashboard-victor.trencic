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
            clickDelete(e) {
                e.preventDefault();
                this.$emit('deleted');
            },
            async send() {
                await this.update({ id: this.id, currency: this.params.currency, convert: this.params.convert})
                this.crypto = await this.getById(this.id);
            }
        },
        props : {
            id: String,
            config: Boolean,
            params: Object
        },
        data: function () {
            return {
                crypto: {},
            }
        },
        created: async function() {
            const res = await this.getById(this.id);
            console.log(res)
            this.crypto = res
        }
    })
</script>