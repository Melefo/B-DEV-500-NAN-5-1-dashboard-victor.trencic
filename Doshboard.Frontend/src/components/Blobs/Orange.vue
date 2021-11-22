<template>
    <Goo intensity="strong">
        <svg role="img" aria-label="Example of a gooey effect" className="w-64 h-64">
            <g v-bind:style="{ animation: 'rotate_back 9s linear infinite' }">
                <circle cx="50%" cy="50%" r="42" fill="lightseagreen" v-bind:style="{ animation: 'blob_four 12s ease-in-out -3s infinite alternate' }" />
                <circle cx="50%" cy="50%" r="36" fill="mediumaquamarine" v-bind:style="{ animation: 'blob_three 9s ease-in-out -3s infinite alternate' }" />
                <circle cx="50%" cy="50%" r="30" fill="palegreen" v-bind:style="{ animation: 'blob_two 6s ease-in-out -3s infinite alternate' }" />
                <circle cx="50%" cy="50%" r="24" fill="mediumspringgreen" v-bind:style="{ animation: 'blob_one 3s ease-in-out -3s infinite alternate' }" />
            </g>
        </svg>
    </Goo>
</template>

<script lang="ts">
import Vue from 'vue'
import Goo from '@/components/Goo.vue'

export default Vue.extend({
    components: {
        Goo
    }
})
</script>