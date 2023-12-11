<template>
  <v-card>
    <v-tabs v-model="tab"
            bg-color="primary">
      <v-tab value="one">User Settings</v-tab>
      <v-tab value="two" v-if="role === 'Admin' || role === 'Superadmin'">Admin Settings</v-tab>
      <v-tab value="three" v-if="role === 'Superadmin'">Superadmin Settings</v-tab>
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
        tab: null,
        role: localStorage.getItem('role')
      };
    },
  };
</script>
