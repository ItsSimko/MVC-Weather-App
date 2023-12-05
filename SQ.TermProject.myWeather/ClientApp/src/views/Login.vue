<template>
  <v-container fluid class="h-100 bg-blue-grey-darken-4 " no-gutters>
    <v-row class="d-flex align-center justify-center w-50 mx-auto h-100" no-gutters>
      <v-col class="text-black bg-grey rounded-xl" no-gutters>
        <h1 class="text-center">Login Page</h1>
        <LoginBox />
      </v-col>
    </v-row>
  </v-container>

</template>

<script lang="ts" setup>import LoginBox from '@/components/LoginBox.vue'</script>
