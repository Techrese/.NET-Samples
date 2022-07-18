<template>
    <div id="app">
        <HeaderBar />
        <div class="main-section">
            <Heroes/>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import HeaderBar from '@/components/header-bar.vue';
    import Hero from '@/components/hero.vue';
    import Heroes from '@/components/heroes.vue';

    @Component({
        name: 'App',
        components: {
            HeaderBar,
            Hero,
            Heroes,
        }
    })
    export default class App extends Vue{ }
</script>

<style lang="scss">
    @import 'design/index.scss';
</style>
