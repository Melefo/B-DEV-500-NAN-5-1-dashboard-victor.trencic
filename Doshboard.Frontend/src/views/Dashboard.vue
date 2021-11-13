<template>
    <div id="body">
        <div id="background">
            <svg id="blob" viewBox="0 0 900 600" width="900" height="600" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1">
                <g transform="translate(441.3650925301122 308.59616651992724)">
                    <path id="blob1" d="M173.3 -185.4C205.1 -141.4 198 -70.7 186.5 -11.5C174.9 47.6 158.9 95.2 127.1 139.1C95.2 182.9 47.6 222.9 4.6 218.3C-38.4 213.8 -76.8 164.5 -112.3 120.7C-147.8 76.8 -180.4 38.4 -178.9 1.5C-177.4 -35.4 -141.7 -70.7 -106.2 -114.7C-70.7 -158.7 -35.4 -211.4 17.7 -229C70.7 -246.7 141.4 -229.4 173.3 -185.4" fill="#BB004B"></path>
                </g>
                <g transform="translate(422.42739410903823 283.85928654349004)" style="visibility: hidden">
                    <path id="blob2" d="M117.5 -95.9C164.4 -70.7 222.7 -35.4 234.6 11.9C246.5 59.2 212 118.3 165.2 144.3C118.3 170.3 59.2 163.2 -5.8 168.9C-70.7 174.7 -141.4 193.4 -167.9 167.4C-194.4 141.4 -176.7 70.7 -166.8 9.9C-156.9 -50.9 -154.8 -101.8 -128.3 -127C-101.8 -152.2 -50.9 -151.6 -7.8 -143.8C35.4 -136 70.7 -121 117.5 -95.9" fill="#BB004B"></path>
                </g>
            </svg>
        </div>
        <div id="foreground">
            <p>Hello, Maria</p>
            <p>It's a great day for a workout</p>
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
var KUTE = require('kute.js')

export default Vue.extend({
    mounted: function() {
        KUTE.default.fromTo(
            '#blob1',
            { path: '#blob1' },
            { path: '#blob2' },
            {repeat: 999, duration: 3000, yoyo: true }
        ).start()
    }
})

</script>

<style>
    #nav {
        display: none;
    }

    html {
        background: #E7E7E7;
    }

    html, body, #app, #body {
        height: 100%;
        width: 100%;
        display: flex;
        align-items: center;
        justify-content: center;
    }

    #foreground {
        width: 90%;
        height: 90%;
        background: rgba(255, 255, 255, 0.3);
        border-radius: 28px;
        backdrop-filter: blur(5px);
        -webkit-backdrop-filter: blur(5px);
        border: 2px solid #D2E2E6;
    }

    #background {
        position: absolute;
        height: 100%;
        width: 100%;
        overflow: hidden;
    }

    #blob {
        position: absolute;
        top: -100px;
        right: -300px;
    }
</style>