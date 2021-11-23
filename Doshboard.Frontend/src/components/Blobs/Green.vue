<template>
    <Goo intensity="strong" :styles="[styles, {position: 'relative', opacity: '0.6'}]">
        <svg role="img" aria-label="Green blob">
            <defs>
                <linearGradient id="green">
                    <stop offset="0%" stop-color="#86F692" />
                    <stop offset="100%" stop-color="#2AD5D6" />
                </linearGradient>
                <linearGradient id="blue">
                    <stop offset="0%" stop-color="#2AD5D6" />
                    <stop offset="100%" stop-color="#21CFDF" />
                </linearGradient>
            </defs>
            <g v-bind:style="{ animation: 'rotate_back 90s linear infinite' }">
                <circle class="blob1" cx="45%" cy="0%" r="64" fill="#86F692" />
                <circle class="blob1" cx="40%" cy="10%" r="64" fill="#86F692" />
                <circle class="blob1" cx="65%" cy="20%" r="64" fill="#86F692" />
                <circle class="blob2" cx="30%" cy="60%" r="64" fill="url('#green')" />
                <circle class="blob2" cx="50%" cy="50%" r="64" fill="url('#green')" />
                <circle class="blob2" cx="80%" cy="40%" r="64" fill="url('#green')" />
                <circle class="blob3" cx="45%" cy="90%" r="64" fill="url('#blue')" />
                <circle class="blob3" cx="55%" cy="100%" r="64" fill="url('#blue')" />
                <circle class="blob3" cx="70%" cy="80%" r="64" fill="url('#blue')" />
            </g>
        </svg>
    </Goo>
</template>

<style scoped>
.blob1 {
    animation: blob_one 60s ease-in-out -15s infinite alternate
}

@keyframes blob_one {
  100% { transform: rotate(-360deg) translate(10%, 50%) }
}

.blob2 {
    animation: blob_two 60s ease-in-out -15s infinite alternate
}

@keyframes blob_two {
  100% { transform: rotate(-360deg) translate(15%, -20%) }
}

.blob3 {
    animation: blob_three 60s ease-in-out -15s infinite alternate
}

@keyframes blob_three {
  100% { transform: rotate(-360deg) translate(-10%, -80%) }
}

</style>

<script lang="ts">
import Vue from 'vue'
import Goo from '@/components/Goo.vue'

export default Vue.extend({
    components: {
        Goo
    },
    props: ["styles"]
})
</script>