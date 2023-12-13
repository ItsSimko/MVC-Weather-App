<template>
  <v-card class="bg-window">
    <v-card-title>Update Username</v-card-title>
    <v-card-text>
      <v-text-field v-model="newUsername" label="New Username"></v-text-field>
      <v-btn @click="updateUsername">Update</v-btn>
    </v-card-text>
  </v-card> 
</template>

<script lang="ts">
  export default {
    data() {
      return {
        newUsername: '',
        favoriteLocation: '',
      };
    },
    methods: {
      updateUsername() {

      },
    }
  };
</script>

<style>
  .bg-window {
    background-color: #E0E0E0 !important;
  }
</style>
