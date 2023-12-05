<template>
  <WeatherContainer />
</template>

<script lang="ts" setup>
  import WeatherContainer from '@/components/WeatherInformation.vue'
</script>

<style>
  .bg-setup {
    background: url('./assets/bg/cloudy.jpg') no-repeat center center fixed !important;
    background-size: cover;
  }

  .v-application--wrap {
    min-height: 0vh !important;
  }

</style>
