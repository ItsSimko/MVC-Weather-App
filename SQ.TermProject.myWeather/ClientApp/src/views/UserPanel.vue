<template>
  <v-card class="h-100 bg">
    <v-tabs v-model="tab"
            bg-color="primary">
      <v-tab value="one">User Settings</v-tab>
      <v-tab value="four" > Top Search Location</v-tab>
      <v-tab value="two" v-if="role === 'Admin' || role === 'Superadmin'">Admin Settings</v-tab>
      <v-tab value="three" v-if="role === 'Superadmin'">Superadmin Settings</v-tab>
    </v-tabs>

    <v-card-text>
      <v-window v-model="tab" class="">
        <v-window-item value="one" class="">
          <ClientSettings></ClientSettings>
        </v-window-item>

        <v-window-item value="two" class="">
          <AdminSettings />
        </v-window-item>

        <v-window-item value="three" class="">
          <SuperAdminSettings></SuperAdminSettings>
        </v-window-item>

        <v-window-item value="four" class="">
          <StatBox></StatBox>
        </v-window-item>
      </v-window>
    </v-card-text>
  </v-card>
</template>


<script setup lang="ts">

  import SearchBar from '../components/SearchBar.vue';
  import ClientSettings from '../components/UserSettings.vue';
  import SuperAdminSettings from '../components/SuperAdminSetttings.vue'
  import AdminSettings from '../components/AdminSettings.vue'
  import StatBox from '../components/Top10Box.vue'
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

<style>
  .bg {
    background-color: #333!important;
  }
</style>
