<template>
    <div id="game-widget" v-if=!config>
        <img :src="game.logo" />
        <div class="name">{{ game.name }}</div>
        <div class="players">{{ game.players }}</div>
        <div class="review">{{ game.review }}%</div>
        <div class="price">{{ game.price }}</div>
    </div>
    <div id="game-widget" v-else>
        <button type="button" @click="clickDelete">X</button>
        <input type="text" placeholder="Game name" v-model="params.name" @change="send" />
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
            clickDelete(e) {
                e.preventDefault();
                this.$emit('deleted');
            },
            async send() {
                await this.update({ id: this.id, name: this.params.name})
                this.game = await this.getById(this.id);
            }
        },
        props : {
            id: String,
            config: Boolean,
            params: Object
        },
        data: function () {
            return {
                game: {},
            }
        },
        created: async function() {
            this.game = await this.getById(this.id);
        }
    })
</script>