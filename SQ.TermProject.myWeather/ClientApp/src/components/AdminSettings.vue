<template>
  <v-container class="bg-window">
    <v-row align="center">
      <v-col cols="12" sm="6">
        <v-text-field v-model="alertMessage" label="Enter alert message"></v-text-field>
      </v-col>
      <v-col cols="12" sm="6">
        <v-select v-model="selectedType" :items="types" label="Select alert type"></v-select>
      </v-col>
      <v-col>
        <v-btn @click="updateAlert" color="primary">Update</v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
  export default {
    data() {
      return {
        alertMessage: '',
        selectedType: 'success',
        types: ['success', 'warning', 'error'],
      };
    },
    methods: {
      updateAlert() {
        // make axios call to update alert
      }
    }
  };
</script>

<style>
  .bg-window {
    background-color: #E0E0E0 !important;
  }
</style>
