<template>
    <div v-bind:style="styles">
      <svg v-bind:style="svgStyle">
        <defs>
          <filter color-interpolation-filters="sRGB" v-bind:id="id">
            <feGaussianBlur v-bind:stdDeviation="blur" />
            <feColorMatrix v-bind:values="`${r} ${g} ${b} ${a}`"/>
            <feComposite v-if="composite" data-testid="composite" in="SourceGraphic"></feComposite>
          </filter>
        </defs>
      </svg>
      <div v-bind:class="className" v-bind:style="{filter: `url(#${id})`, position: 'absolute', height:'100%', width:'100%'}">
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

svg, g {
  overflow: visible;
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
        styles: Array
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
                display: 'none'
            }
        }
    }
})
</script>