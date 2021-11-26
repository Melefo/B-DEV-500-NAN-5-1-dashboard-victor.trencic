<template>
    <div id="foreground">
        <slot></slot>
    </div>
</template>

<style>
    #foreground {
        width: 85%;
        height: 85%;
        background: rgba(255, 255, 255, 0.3);
        border-radius: 50px;
        backdrop-filter: blur(30px);
        box-shadow: 10px 5px 10px #00000010;
    }
</style>