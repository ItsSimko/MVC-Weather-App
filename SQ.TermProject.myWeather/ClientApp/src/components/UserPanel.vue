<template>
  <v-container>
    <v-card class="bg-window">
      <v-card-title>Update Username</v-card-title>
      <v-card-text>
        <v-text-field v-model="newUsername" label="New Username"></v-text-field>
        <v-btn @click="updateUsername">Update</v-btn>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script>
  import SearchBar from '../components/SearchBar.vue'
  export default {
    data() {
      return {
        newUsername: '',
        favoriteLocation: ''
      };
    },
    methods: {
      updateUsername() {

        this.newUsername = '';
      },

    }
  };
</script>


<style>
  .bg-window {
    background-color: #E0E0E0 !important;
  }
</style>
