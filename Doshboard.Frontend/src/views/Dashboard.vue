<template>
    <div id="class">
        <a href="Home">Home</a>
        <ul>
            <li><button class="btn"><i class="fa fa-home"></i></button></li>
            <li><button class="btn"><i class="fa fa-cog"></i></button></li>
            <li><button class="btn"><i class="fa fa-columns"></i></button></li>
            <li><button class="btn"><i class="fa fa-sign-out"></i></button></li>
        </ul>

    </div>
</template>

<style>

    .btn {
        width: 100%;
    }

    ul {
        list-style-type: none;
        margin: 0;
        padding: 0;
        width: 25%;
        background-color: #f1f1f1;
        position: fixed;
        height: 100%;
        overflow: auto;
    }

    li button {
        display: block;
        color: #000;
        padding: 20% 0%;
        text-decoration: none;
    }

    li input:hover {
        background-color: #555;
        color: white;
    }
</style>

<script lang="ts">
    import Vue from 'vue'

    export default Vue.extend({
        name: 'Dashboard',
        components: {
        }
    })
</script>