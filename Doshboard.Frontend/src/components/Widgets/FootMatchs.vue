<template>
    <div id="competition-widget" v-if=!config>
        <code v-if='error'>{{ this.error }}</code>
        <div v-else-if="footMatchs">
            <h3>{{ footMatchs.competition.name }}</h3>
            <table>
                <tr v-for="value in footMatchs.matches" :key="value.id">
                    <td>{{ value.homeTeam.name }}</td>
                    <td><b>{{ value.score.fullTime.homeTeam }} - {{ value.score.fullTime.awayTeam }}</b></td>
                    <td>{{ value.awayTeam.name }}</td>
                </tr>
            </table>
        </div>
    </div>
    <div id="competition-widget" v-else>
        <code v-if='error'>{{ this.error }}</code>
        <button type="button" @click="clickDelete">X</button>
        <select v-model="params.id" @change='send'>
            <option :value="value.id.toString()" v-for="value in competitions" :key="value.id">{{ value.name }}</option>
        </select>
        Refresh rate<input type="number" placeholder="Timer" v-model="params.timer" @change="timer" />
    </div>
</template>

<style scoped>
.match {
    display: flex;
}

table {
    width: 100%;
    border-spacing: 0 0.5em;
}
</style>

<script lang="ts">
    import Vue from 'vue'
    import { mapActions } from 'vuex';

    export default Vue.extend({
        name: 'FootMatchs',
        methods: {
            ...mapActions("foot", ["getMatchByCompetitions", "getAllCompetitions", "update"]),
            async clickDelete(e) {
                e.preventDefault();
                await this.ws.invoke("DeleteTimer", this.id);
                this.$emit('deleted');
            },
            async send() {
                if (this.params.id == '')
                    this.params.id = null;
                const { error } = await this.update({ id: this.id, competition: this.params.id })
                this.error = error;
                if (this.error)
                    return;
                const { success, json } = await this.getMatchByCompetitions(this.id);
                if (success)
                    this.footMatchs = json;
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
                footMatchs: null,
                error: null,
                competitions: null
            }
        },
        created: async function() {
            
            const { success, json } = await this.getAllCompetitions();
            if (success)
                this.competitions = json;
            else
                this.error = json;
            if (!this.error)
            {
                const { success: successMatchs, json: jsonMatchs } = await this.getMatchByCompetitions(this.id);
                if (successMatchs)
                    this.footMatchs = jsonMatchs;
                else
                    this.error = jsonMatchs;
            }

            this.ws.on(this.id, (e) => {
                this.footMatchs = e;
            })
        }
    })
</script>