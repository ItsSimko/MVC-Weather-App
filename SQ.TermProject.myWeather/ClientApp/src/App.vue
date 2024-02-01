<script setup lang="ts">
  import Footer from './components/Footer.vue' ;
  import Header from './components/Header.vue' ;

</script>

<template>
  <v-app>

    <v-main>
      <Header />
      <RouterView />
      <Footer />
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
