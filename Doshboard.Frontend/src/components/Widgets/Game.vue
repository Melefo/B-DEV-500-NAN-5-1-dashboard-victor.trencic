<template>
    <div id="game-widget" v-if=!config>
        <code v-if='error'>{{ this.error }}</code>
        <div v-else-if="game" id="gameinfo">
            <div id="id">
                <img :src="game.logo" />
                <h3 class="name">{{ game.name }}</h3>
            </div>
            <div>
                <div class="players">Number of player online: <b>{{ game.players }}</b></div>
                <div class="review">Positive reviews: <b>{{ game.review }}%</b></div>
                <div class="price">Current price: <b>{{ game.price }}</b></div>
            </div>
        </div>
    </div>
    <div id="game-widget" v-else>
        <code v-if='error'>{{ this.error }}</code>
        <button type="button" @click="clickDelete">X</button>
        <input type="text" placeholder="Game name" v-model="params.name" @change="send" />
        Refresh rate<input type="number" placeholder="Timer" v-model="params.timer" @change="timer" />
    </div>
</template>

<style scoped>
#game-widget {
    height: 100%;
}

#id {
    display: flex;
    flex-direction: column;
}

#gameinfo {
    display: flex;
    flex-direction: row;
    align-content: center;
    align-items: center;
    height: 90%;
    justify-content: space-evenly;
}
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