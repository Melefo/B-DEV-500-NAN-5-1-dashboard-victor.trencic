<template>
    <Goo intensity="strong" :styles="[styles, {position: 'relative'}]">
        <svg role="img" aria-label="Blue blob">
            <defs>
                <linearGradient id="gradient">
                    <stop offset="0%" stop-color="#2B7CB5" />
                    <stop offset="100%" stop-color="#55C3E9" />
                </linearGradient>
            </defs>
            <g v-bind:style="{ animation: 'rotate_back 90s linear infinite' }">
                <circle class="blob1" cx="1%" cy="20%" r="44" fill="url('#gradient')" />
                <circle class="blob2" cx="-25%" cy="48%" r="26" fill="url('#gradient')" />
                <circle class="blob4" cx="50%" cy="0%" r="62" fill="#5ACBF1" />
                <circle class="blob4" cx="60%" cy="10%" r="62" fill="#5ACBF1" />
                <circle class="blob3" cx="80%" cy="50%" r="72" fill="#4FBCDF" />
                <circle class="blob3" cx="50%" cy="50%" r="72" fill="#4FBCDF" />
                <circle class="blob5" cx="15%" cy="95%" r="54" fill="#369DBE" />
                <circle class="blob5" cx="60%" cy="80%" r="54" fill="#369DBE" />
                <circle class="blob5" cx="50%" cy="90%" r="54" fill="#369DBE" />
                <circle class="blob5" cx="25%" cy="120%" r="54" fill="#369DBE" />
            </g>
        </svg>
    </Goo>
</template>

<style scoped>

.blob1 {
    animation: blob_one 60s ease-in-out -15s infinite alternate
}

@keyframes blob_one {
  50% { transform: translate(50%, 20%) }
  100% { transform: translate(-10%, -5%) }
}

.blob2 {
    animation: blob_two 60s ease-in-out -15s infinite alternate
}

@keyframes blob_two {
  50% { transform: translate(-20%, -10%) }
  100% { transform: translate(5%, 5%) }
}

.blob3 {
    animation: blob_three 60s ease-in-out -15s infinite alternate
}

@keyframes blob_three {
  100% { transform: rotate(-360deg) translate(-20%, -30%) }
}

.blob4 {
    animation: blob_four 60s ease-in-out -15s infinite alternate
}

@keyframes blob_four {
  100% { transform: rotate(-360deg) translate(5%, 70%) }
}

.blob5 {
    animation: blob_five 60s ease-in-out -15s infinite alternate
}

@keyframes blob_five {
  100% { transform: rotate(-360deg) translate(30%, -30%) }
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