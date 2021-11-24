<template>
    <div :class= "name + '-div-field'">
        <input type= "email" :class="name + '-cfield'" :name= "name + '-field'" required=isRequired minlength= "2" maxlength="255" :placeholder="placeHolder">
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
    props: {
        name: String,
        isRequired: Boolean,
        placeHolder: String
    }
})
</script>