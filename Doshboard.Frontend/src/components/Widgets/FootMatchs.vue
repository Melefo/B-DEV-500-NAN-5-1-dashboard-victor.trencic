<template>
    <div>
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
        ...mapActions("foot", ["getAllCompetitions", "getMatchByCompetitions", "update"]),
        async send() {
            await this.update({ id: this.id, city: this.params.city, unit: parseInt(this.params.unit)})
            this.footMatchs = await this.getMatchByCompetitions(this.id);
        }
    },
    props : {
        id: String,
        config: Boolean,
        params: Object
    },
    data: function () {
        return {
            weather: {},
        }
    },
    created: async function() {
        this.weather = await this.getById(this.id);
    }
})
</script>