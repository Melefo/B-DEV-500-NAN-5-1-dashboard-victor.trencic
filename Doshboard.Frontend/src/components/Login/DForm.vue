<template>
    <form action=action method=method class="form-example">
        <slot></slot>
        <input type="button" class="form-submit" name="form-submit" value="Submit">
    </form>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
    props: {
        action: String,
        method: String,
    }
})
</script>