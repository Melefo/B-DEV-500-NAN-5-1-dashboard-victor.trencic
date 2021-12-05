<template>
    <div id="list">
        <div v-if="error">{{ this.error }}</div>
        <div v-for="service in services" :key="service.name">
            <p>{{ service.name }}</p>
            <div v-for="widget in service.widgets" :key="widget.name" @click="click(widget)">
                {{ widget.name }}
            </div>
        </div>
    </div>
</template>

<style>

#list * {
    text-align: left;
}

</style>

<script lang="ts">
import Vue from 'vue'
import { mapActions } from 'vuex'

export default Vue.extend({
    name: 'Widgets',
    components: {
    },
    data: function() {
        return {
            services: null,
            error: null
        }
    },
    methods: {
        ...mapActions("about", ["get"]),
        ...mapActions("widget", ["new"]),
        async click(widget) {
            this.error = await this.new(widget.name);
            if (!this.error) {
                this.$router.push('/dashboard');
            }
        }
    },
    created: async function() {
        const { error, data } = await this.get()
        this.error = error;
        this.services = data;
    }
})
</script>