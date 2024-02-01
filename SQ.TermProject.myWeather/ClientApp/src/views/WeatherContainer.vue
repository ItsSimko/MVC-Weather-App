<template>
  <v-container class="bg-setup h-100 v-container v-container--fluid">
    <SearchBar class="mx-auto my-10 bg-blue-grey-darken-4
          pa-3 rounded-xl " style="position: absoulte;"></SearchBar>
    <WeatherContainer />
  </v-container>
</template>

<script lang="ts" setup>
  import WeatherContainer from '@/components/WeatherInformation.vue'
  import SearchBar from '@/components/SearchBar.vue'
  import { weatherData } from '@/components/SearchBar.vue'

  let weather = weatherData;
  //: style = "{ 'background' : 'url(' + weather.data.current.weather.icon + ') no-repeat center center fixed !important'"
</script>



<style>
  .bg-setup {
    background-size: cover;

    background-image: url("../assets/bg/01d.jpg");
  }
</style>

