<template>
    <div id="competition-widget" v-if=!config>
        <code v-if='error'>{{ this.error }}</code>
        <div v-else-if="footMatchs">
            {{ this.footMatchs }}
        </div>
    </div>
    <div id="competition-widget" v-else>
        <code v-if='error'>{{ this.error }}</code>
        <button type="button" @click="clickDelete">X</button>
        <select v-model="params.competition" @change='send'>
            <option :value="key" v-for="(value, key) in competitions" :key="key">{{ value }}</option>
        </select>
        <input type="number" placeholder="Timer" v-model="params.timer" @change="timer" />
    </div>
</template>

<style scoped>

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
                if (this.params.competition == '')
                    this.params.competition = null;
                const { error } = await this.update({ id: this.id, competition: this.params.competition })
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