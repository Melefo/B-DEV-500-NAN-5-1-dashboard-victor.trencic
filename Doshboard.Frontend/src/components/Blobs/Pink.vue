<template>
    <Goo intensity="strong" :styles="[styles, {position: 'relative'}]">
        <svg role="img" aria-label="Pink blob">
            <defs>
                <linearGradient id="pink">
                    <stop offset="0%" stop-color="#FE3389" />
                    <stop offset="100%" stop-color="#CB61C3" />
                </linearGradient>
                <linearGradient id="magenta">
                    <stop offset="0%" stop-color="#CB61C3" />
                    <stop offset="100%" stop-color="#9785FE" />
                </linearGradient>
            </defs>
            <g v-bind:style="{ animation: 'rotate_back 90s linear infinite' }">
                <circle class="blob1" cx="20%" cy="50%" r="76" fill="url('#pink')" />
                <circle class="blob2" cx="35%" cy="50%" r="52" fill="#CB61C3" />
                <circle class="blob2" cx="50%" cy="50%" r="48" fill="#CB61C3" />
                <circle class="blob4" cx="37%" cy="-28%" r="28" fill="#CB61C3" />
                <circle class="blob5" cx="42%" cy="118%" r="24" fill="#CB61C3" />
                <circle class="blob3" cx="60%" cy="20%" r="52" fill="url('#magenta')" />
                <circle class="blob3" cx="70%" cy="80%" r="58" fill="url('#magenta')" />
                <circle class="blob6" cx="98%" cy="30%" r="32" fill="#9785FE" />
            </g>
        </svg>
    </Goo>
</template>

<style scoped>
.blob1 {
    animation: blob_one 60s ease-in-out -15s infinite alternate
}

@keyframes blob_one {
  100% { transform: rotate(-360deg) translate(50%, 10%) }
}

.blob2 {
    animation: blob_two 60s ease-in-out -15s infinite alternate
}

@keyframes blob_two {
  100% { transform: rotate(-360deg) translate(15%, -60%) }
}

.blob3 {
    animation: blob_three 60s ease-in-out -15s infinite alternate
}

@keyframes blob_three {
  100% { transform: rotate(-360deg) translate(-10%, -80%) }
}

.blob4 {
    animation: blob_four 60s ease-in-out -15s infinite alternate
}

@keyframes blob_four {
  100% { transform: rotate(-360deg) translate(45%, 45%) }
}

.blob5 {
    animation: blob_five 60s ease-in-out -15s infinite alternate
}

@keyframes blob_five {
  100% { transform: rotate(-360deg) translate(-20%, 30%) }
}

.blob6 {
    animation: blob_six 60s ease-in-out -15s infinite alternate
}

@keyframes blob_six {
  100% { transform: rotate(-360deg) translate(-90%, -10%) }
}
</style>

<script lang="ts">
import Vue from 'vue'
import Goo from '@/components/Goo.vue'

export default Vue.extend({
    components: {
        Goo
    },
    props: ['styles']
})
</script>