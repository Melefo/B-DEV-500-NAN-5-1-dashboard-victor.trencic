<template>
    <div id="video-widget" v-if=!config>
        <img :src="video.thumbnail" />
        <div class="title">{{ video.title }}</div>
        <div class="likes">{{ video.likes }}👍</div>
        <div class="percent">{{ video.likes / (video.likes + video.dislikes) * 100 }}%</div>
        <div class="dislikes">{{ video.dislikes }}👎</div>
        <div class="views">{{ video.views }}</div>
        <div class="comments">{{ video.comments }}</div>
    </div>
    <div id="video-widget" v-else>
        <button type="button" @click="clickDelete">X</button>
        <select v-model="params.videoId" @change='send'>
            <option :value="key" v-for="(value, key) in videos" :key="key">{{ value }}</option>
        </select>
    </div>
</template>

<style scoped>

</style>

<script lang="ts">
    import Vue from 'vue'
    import { mapActions } from 'vuex';

    export default Vue.extend({
        name: 'Video',
        methods: {
            ...mapActions("youtube", ["getById", "update", "getUserVideos"]),
            clickDelete(e) {
                e.preventDefault();
                this.$emit('deleted');
            },
            async send() {
                await this.update({ id: this.id, videoId: this.params.videoId})
                this.video = await this.getById(this.id);
            }
        },
        props : {
            id: String,
            config: Boolean,
            params: Object
        },
        data: function () {
            return {
                video: {},
                videos: []
            }
        },
        created: async function() {
            this.video = await this.getById(this.id);
            this.videos = await this.getUserVideos();
        }
    })
</script>