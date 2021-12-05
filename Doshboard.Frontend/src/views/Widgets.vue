<template>
    <div id="list">
        <div v-if="error">{{ this.error }}</div>
        <div id="widgets">
            <div class="service" v-for="service in services" :key="service.name">
                <h1>{{ service.name }}</h1>
                <div class="service-widget" v-for="widget in service.widgets" :key="widget.name" @click="click(widget)">
                    <h5>{{ widget.name }}+</h5>
                </div>
            </div>
        </div>
    </div>
</template>


<style>

.service-widget {
    background: rgba(255, 255, 255, 0.3);
    border-radius: 50px;
    backdrop-filter: blur(30px);
    box-shadow: 10px 5px 10px #00000010;
}

.service-widget:hover {
    background: rgba(0, 0, 255, 0.3);
    cursor:pointer;
}

.service {
    width: 100%;
    height: 100%;
}

#widgets {
    display: flex;
    justify-content: space-evenly;
    overflow-x: auto;
    text-transform: capitalize;
}

#list * {
    margin-left: 2%;
    margin-right: 2%;
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