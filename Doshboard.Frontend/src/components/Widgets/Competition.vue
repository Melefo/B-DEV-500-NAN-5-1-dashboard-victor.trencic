<template>
    <div id="competition-widget" v-if=!config>
    </div>
    <div id="competition-widget" v-else>
        <button type="button" @click="clickDelete">X</button>
        <input type="number" placeholder="Timer" v-model="params.timer" @change="timer" />
    </div>
</template>

<style scoped>

</style>

<script lang="ts">
    import Vue from 'vue'
    import { mapActions } from 'vuex';

    export default Vue.extend({
        name: 'Competition',
        methods: {
            ...mapActions("foot", ["getMatchByCompetitions", "getAllCompetitions", "update"]),
            async clickDelete(e) {
                e.preventDefault();
                await this.ws.invoke("DeleteTimer", this.id);
                this.$emit('deleted');
            },
            async send() {
                await this.update({ id: this.id})
                this.competition = await this.getMatchByCompetitions(this.id);
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
                competition: {},
            }
        },
        created: async function() {
            this.competition = await this.getMatchByCompetitions(this.id);

            this.ws.on(this.id, (e) => {
                this.competition = e;
            })
        }
    })
</script>