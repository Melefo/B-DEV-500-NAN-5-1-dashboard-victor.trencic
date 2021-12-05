<template>
    <div id="game-widget" v-if=!config>
        <code v-if='error'>{{ this.error }}</code>
        <div v-else-if="game">
            <img :src="game.logo" />
            <div class="name">{{ game.name }}</div>
            <div class="players">{{ game.players }}</div>
            <div class="review">{{ game.review }}%</div>
            <div class="price">{{ game.price }}</div>
        </div>
    </div>
    <div id="game-widget" v-else>
        <code v-if='error'>{{ this.error }}</code>
        <button type="button" @click="clickDelete">X</button>
        <input type="text" placeholder="Game name" v-model="params.name" @change="send" />
        <input type="number" placeholder="Timer" v-model="params.timer" @change="timer" />
    </div>
</template>

<style scoped>

</style>

<script lang="ts">
    import Vue from 'vue'
    import { mapActions } from 'vuex';

    export default Vue.extend({
        name: 'Game',
        methods: {
            ...mapActions("steam", ["getById", "update"]),
            async clickDelete(e) {
                e.preventDefault();
                await this.ws.invoke("DeleteTimer", this.id);
                this.$emit('deleted');
            },
            async send() {
                if (this.params.name == '')
                    this.params.name = null;
                const { error } = await this.update({ id: this.id, name: this.params.name})
                this.error = error
                if (this.error)
                    return;
                const { success, json } = await this.getById(this.id);
                if (success)
                    this.game = json;
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
                game: null,
                error: null
            }
        },
        created: async function() {
            const { success, json } = await this.getById(this.id);
            if (success)
                this.game = json;
            else
                this.error = json;

            this.ws.on(this.id, (e) => {
                this.game = e;
            })
        }
    })
</script>