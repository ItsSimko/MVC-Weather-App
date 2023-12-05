<template>
  <v-container>
    <!-- Update Username Section -->
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
        <v-text-field v-model="favoriteLocation" label="Favorite Location"></v-text-field>
        <v-btn @click="setFavoriteLocation">Set</v-btn>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      newUsername: '',
      favoriteLocation: ''
    };
  },
  methods: {
    updateUsername() {
      // Implement logic to update the username (e.g., API call)
      console.log('New Username:', this.newUsername);
      // Reset the input field after updating
      this.newUsername = '';
    },
    setFavoriteLocation() {
      // Implement logic to set the favorite location (e.g., API call)
      console.log('Favorite Location:', this.favoriteLocation);
      // Reset the input field after setting the location
      this.favoriteLocation = '';
    }
  }
};
</script>
