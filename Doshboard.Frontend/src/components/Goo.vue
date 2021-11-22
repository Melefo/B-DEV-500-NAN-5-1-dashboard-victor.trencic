<template>
    <div>
      <svg v-bind:style="svgStyle">
        <defs>
          <filter color-interpolation-filters="sRGB" v-bind:id="id">
            <feGaussianBlur v-bind:stdDeviation="blur" />
            <feColorMatrix v-bind:values="`${r} ${g} ${b} ${a}`"/>
            <feComposite v-if="composite" data-testid="composite" in="SourceGraphic"></feComposite>
          </filter>
        </defs>
      </svg>
      <div v-bind:class="className" v-bind:style="[styles, {filter: `url(#${id})`}]">
        <slot></slot>
      </div>
    </div>
</template>

<style>
@keyframes rotate_back {
  100% { transform: rotate(-360deg) }
}

svg * { 
    transform-origin: 50% ;
}

svg {
  height: 100vh;
  width: 100vw;
}
</style>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
    props: {
        intensity: String,
        id: {
            type: String,
            default: "gooey-vue"
        },
        className: String,
        composite: Boolean,
        styles: Object
    },
    data: function() {
        const blur = this.intensity === 'weak' ? 8 : this.intensity === 'strong' ? 18 : 12
        const alpha = blur * 6
        const shift = alpha / -2
        const r = '1 0 0 0 0'
        const g = '0 1 0 0 0'
        const b = '0 0 1 0 0'
        const a = `0 0 0 ${alpha} ${shift}`
        return {
            blur: blur,
            alpha: alpha,
            r: r,
            g: g,
            b: b,
            a: a,
            svgStyle: {
                pointerEvents: 'none',
                position: 'absolute'
            }
        }
    }
})
</script>