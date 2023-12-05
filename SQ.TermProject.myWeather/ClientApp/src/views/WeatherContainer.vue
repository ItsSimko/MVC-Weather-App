<template>
  <v-container class="bg-setup h-100">
    <SearchBar class="w-25 mx-auto my-10 bg-blue-grey-darken-4
          pa-3 rounded-xl " style="position: absoulte;"></SearchBar>
    <WeatherContainer />
  </v-container>
</template>

<script lang="ts" setup>
  import WeatherContainer from '@/components/WeatherInformation.vue'
  import SearchBar from '@/components/SearchBar.vue'
</script>

<style>
  .bg-setup {
    background: url('../assets/bg/cloudy.jpg') no-repeat center center fixed !important;
    background-size: cover;
  }
</style>
