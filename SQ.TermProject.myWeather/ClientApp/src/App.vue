<script setup lang="ts">
  import SearchBar from './components/SearchBar.vue' ;

</script>

<template>
  <v-app>
    <v-main class="bg-setup">
        <SearchBar class="w-25 mx-auto my-10 bg-blue-grey-darken-4
        pa-3 rounded-xl " style="position: absoulte;"></SearchBar>
        <RouterView class="h-50 bg-transparent"/>
    </v-main>
  </v-app>
</template>


<style>
.bg-setup {
  background: url('./assets/bg/cloudy.jpg') no-repeat center center fixed !important;
  background-size: cover;
}

.v-application--wrap {
  min-height: 0vh !important;
}
</style>