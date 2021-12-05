<template>
    <div v-if=!config>
        <code v-if='error'>{{ this.error }}</code>
        <div v-else-if="feed">
            <h2>{{ feed.name }}</h2>
            <div v-for="item in feed.items" :key=item.title>
                <h3>{{ item.title }}</h3>
                <div v-html=item.content></div>
            </div>
        </div>
    </div>
    <div v-else>
        <code v-if='error'>{{ this.error }}</code>
        <input type="submit" @click="clickDelete" value="X" />
        <input type="text" placeholder="Feed URL" v-model="params.url" @change="send" />
        <input type="number" placeholder="Limit of items" v-model="params.items" @change="send" />
        <input type="number" placeholder="Timer" v-model="params.timer" @change="timer" />
    </div>
</template>

<style scoped>

</style>

<script lang="ts">
import Vue from 'vue'
import { mapActions } from 'vuex'

export default Vue.extend({
    name: "Feed",
    methods: {
        ...mapActions("rss", ["getById", "update"]),
        async clickDelete(e) {
            e.preventDefault();
            await this.ws.invoke("DeleteTimer", this.id);
            this.$emit('deleted');
        },
        async send() {
            if (this.params.items < 1) {
                this.params.items = 1;
                return;
            }
            const { error } = await this.update({ id: this.id, url: this.params.url, items: parseInt(this.params.items)})
            this.error = error
            if (this.error)
                return;
            const { success, json } = await this.getById(this.id);
            if (success)
                this.feed = json;
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
            feed: null,
            error: null
        }
    },
    created: async function() {
        const { success, json } = await this.getById(this.id);
        if (success)
            this.feed = json;
        else
            this.error = json;
        this.ws.on(this.id, (e) => {
            this.feed = e;
        })
    }
})
</script>