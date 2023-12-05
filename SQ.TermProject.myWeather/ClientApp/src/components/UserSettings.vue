<template>
  <v-card>
    <v-card-title>Update Username</v-card-title>
    <v-card-text>
      <v-text-field v-model="newUsername" label="New Username"></v-text-field>
      <v-btn @click="updateUsername">Update</v-btn>
    </v-card-text>
  </v-card>

  <!-- Set Favorite Location Section -->
  <v-card>
    <v-card-title>Set Favorite Location</v-card-title>
    <v-card-text>
      <SearchBar></SearchBar>
      <v-btn @click="setFavoriteLocation">Set</v-btn>
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
      setFavoriteLocation() {

      }
    }
  };
</script>
