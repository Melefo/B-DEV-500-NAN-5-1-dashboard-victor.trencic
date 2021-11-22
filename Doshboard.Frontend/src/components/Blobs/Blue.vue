<template>
    <div id="blue">
        <Goo intensity="strong">
            <svg role="img" aria-label="Blue blob">
                <defs>
                    <linearGradient id="gradient">
                        <stop offset="0%" stop-color="#2B7CB5" />
                        <stop offset="100%" stop-color="#55C3E9" />
                    </linearGradient>
                </defs>
                <g>
                    <circle id="blob1" cx="50%" cy="50%" r="42" fill="url('#gradient')" />
                    <circle id="blob2" cx="50%" cy="50%" r="26" fill="url('#gradient')" />
                    <circle id="blob3" cx="50%" cy="50%" r="72" fill="#4FBCDF" />
                    <circle id="blob4" cx="50%" cy="50%" r="62" fill="#369DBE"  />
                    <circle id="blob5" cx="50%" cy="50%" r="54" fill="#5ACBF1" />
                </g>
            </svg>
        </Goo>
    </div>
</template>

<style scoped>

#blob1 {
    animation: blob_one 60s ease-in-out -15s infinite alternate
}

@keyframes blob_one {
  100% { transform: translate(-10%, 10%) }
}

#blob2 {
    animation: blob_two 60s ease-in-out -15s infinite alternate
}

@keyframes blob_two {
  100% { transform: translate(-15%, 15%) }
}

#blob3 {
    animation: blob_three 60s ease-in-out -15s infinite alternate
}

@keyframes blob_three {
  100% { transform: translate(5%, 9%) }
}

#blob4 {
    animation: blob_four 60s ease-in-out -15s infinite alternate
}

@keyframes blob_four {
  100% { transform: translate(0%, 2%) }
}

#blob5 {
    animation: blob_five 60s ease-in-out -15s infinite alternate
}

@keyframes blob_five {
  100% { transform: translate(-7%, 20%) }
}
</style>

<script lang="ts">
import Vue from 'vue'
import Goo from '@/components/Goo.vue'

export default Vue.extend({
    components: {
        Goo
    }
})
</script>