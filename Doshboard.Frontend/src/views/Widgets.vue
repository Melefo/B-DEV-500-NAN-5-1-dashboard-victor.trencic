<template>
    <Layout>
        <div id="list">
            <div v-for="service in services" :key="service.name">
                <p>{{ service.name }}</p>
                <div v-for="widget in service.widgets" :key="widget.name" @click="click(widget)">
                    {{ widget.name }}
                </div>
            </div>
        </div>
    </Layout>
</template>

<style>

#list * {
    text-align: left;
}

</style>

<script lang="ts">
import Vue from 'vue'
import Layout from '@/components/Layout.vue'
import { mapActions } from 'vuex'

export default Vue.extend({
    name: 'Widgets',
    components: {
        Layout
    },
    data: function() {
        return {
            services: []
        }
    },
    methods: {
        ...mapActions("about", ["get"]),
        ...mapActions("widget", ["new"]),
        async click(widget) {
            await this.new(widget.name);
            this.$router.push('/dashboard');
        }
    },
    created: async function() {
        this.services = await this.get()
    }
})
</script>