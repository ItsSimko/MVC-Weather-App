<script setup lang="ts">
  import SearchBar from './components/SearchBar.vue' ;

</script>

<template>
  <v-app>
    <v-main>

          <RouterView />

    </v-main>
  </v-app>
</template>


<style>

  * {
    margin: 0;
  }

  .v-application--wrap {
    min-height: 0vh !important;
  }
</style>
