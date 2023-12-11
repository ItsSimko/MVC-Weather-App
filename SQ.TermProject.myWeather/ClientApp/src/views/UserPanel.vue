<template>
  <v-card>
    <v-tabs v-model="tab"
            bg-color="primary">
      <v-tab value="one">User Settings</v-tab>
      <v-tab value="two">Admin Settings</v-tab>
      <v-tab value="three">Superadmin Settings</v-tab>
    </v-tabs>

    <v-card-text>
      <v-window v-model="tab">
        <v-window-item value="one">
          <ClientSettings></ClientSettings>
        </v-window-item>

        <v-window-item value="two">
          
        </v-window-item>

        <v-window-item value="three">
          <SuperAdminSettings></SuperAdminSettings>
        </v-window-item>
      </v-window>
    </v-card-text>
  </v-card>
</template>


<script setup lang="ts">

  import SearchBar from '../components/SearchBar.vue';
  import ClientSettings from '../components/UserSettings.vue';
  import SuperAdminSettings from '../components/SuperAdminSetttings.vue'
</script>

<script lang="ts">

  export default {
    data() {
      return {
        newUsername: '',
        favoriteLocation: '',
        tab: null
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
