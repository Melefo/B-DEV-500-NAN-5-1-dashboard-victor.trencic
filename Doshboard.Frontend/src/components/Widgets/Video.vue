<template>
    <div id="video-widget" v-if=!config>
        <code v-if='error'>{{ this.error }}</code>
        <div v-else-if="video" id="data">
            <img :src="video.thumbnail" />
            <div class="title">{{ video.title }}</div>
            <div id="likes">
                <div class="likes">{{ video.likes }}👍</div>
                <div class="percent">{{ (video.likes / (video.likes + video.dislikes) * 100).toFixed(2) }}%</div>
                <div class="dislikes">👎{{ video.dislikes }}</div>
            </div>
            <div id="pct">
                <div class="views">{{ video.views }} views</div>
                <div class="comments">{{ video.comments }} comments</div>
            </div>
        </div>
    </div>
    <div id="video-widget" v-else>
        <code v-if='error'>{{ this.error }}</code>
        <input type="submit" @click="clickDelete" value="X" />
        <select v-model="params.videoId" @change='send'>
            <option :value="key" v-for="(value, key) in videos" :key="key">{{ value }}</option>
        </select>
        Refresh rate<input type="number" placeholder="Timer" v-model="params.timer" @change="timer" />
    </div>
</template>

<style scoped>
#video-widget {
    height: 100%;
}

#data {
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

#likes, #pct {
    display: flex;
    flex-direction: row;
    align-items: center;
    width: 100%;
    justify-content: space-evenly;
}

img {
    width: 25%;
    border-radius: 5px;
}
</style>

<script lang="ts">
    import Vue from 'vue'
    import { mapActions } from 'vuex';

    export default Vue.extend({
        name: 'Video',
        methods: {
            ...mapActions("youtube", ["getById", "update", "getUserVideos"]),
            async clickDelete(e) {
                e.preventDefault();
                await this.ws.invoke("DeleteTimer", this.id);
                this.$emit('deleted');
            },
            async send() {
                if (this.params.videoId == '')
                    this.params.videoId = null;
                await this.update({ id: this.id, videoId: this.params.videoId})
                const { error } = await this.getById(this.id);
                this.error = error
                if (this.error)
                    return;
                const { success, json } = await this.getById(this.id);
                if (success)
                    this.video = json;
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
                video: null,
                videos: null,
                error: null
            }
        },
        created: async function() {
            const { success, json } = await this.getUserVideos();
            if (success)
                this.videos = json;
            else
                this.error = json;
            if (!this.error)
            {
                const { success: successVideo, json: jsonVideo } = await this.getById(this.id);
                if (successVideo)
                    this.video = jsonVideo;
                else
                    this.error = jsonVideo;
            }

            this.ws.on(this.id, (e, es) => {
                this.video = e;
                this.videos = es;
            })
        }
    })
</script>