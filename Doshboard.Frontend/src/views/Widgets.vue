<template>
    <Layout>
    </Layout>
</template>

<style scoped>

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
        ...mapActions("about", ["get"])
    },
    created: async function() {
        this.get()
    }
})
</script>