<template>
  <v-container>
    <v-card class="bg-window"> 
      <v-card-title>Search Users</v-card-title>
      <v-card-text>
        <v-text-field v-model="searchQuery" label="Search Query"></v-text-field>
        <v-btn @click="searchUsers" v-if="isLoading == false">Search</v-btn>
        <LoadingSpinner v-if="isLoading == true"></LoadingSpinner>
      </v-card-text>
    </v-card>

    <v-card v-if="searchResults.length > 0" class="bg-window">
      <v-card-title>Search Results</v-card-title>
      <v-card-text>
        <v-list>
          <v-list-item v-for="(user, index) in searchResults" :key="index">
            <v-list-item-content>
              <v-list-item-title>{{ user.userName }}</v-list-item-title>
              <v-list-item-subtitle>{{ user.email }}</v-list-item-subtitle>
            </v-list-item-content>
            <v-list-item-action>
              <v-select v-model="user.name" :items="roleOptions" label="Select Role"></v-select>
              <v-btn @click="setUserRole(user)">Set Role</v-btn>
            </v-list-item-action>
          </v-list-item>
        </v-list>
      </v-card-text>
    </v-card>
    <v-snackbar v-model="snackbar_good"
                timeout="2000">
      User role updated

      <template v-slot:actions>
        <v-btn color="blue"
               variant="text"
               @click="snackbar_good = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
    <v-snackbar v-model="snackbar_bad"
                timeout="2000">
      Server error occured.

      <template v-slot:actions>
        <v-btn color="blue"
               variant="text"
               @click="snackbar_bad = false">
          Close
        </v-btn>
      </template>
    </v-snackbar>
  </v-container>
</template>

<script setup>
  import LoadingSpinner from './Loading.vue';
</script>

<script>
  import axios from 'axios';


  export default {
    data() {
      return {
        snackbar_good: false,
        snackbar_bad: false,
        isLoading: false,
        searchQuery: '',
        searchResults: [],
        roleOptions: ['User', 'Admin', 'Superadmin']
      };
    },
    methods: {
      searchUsers() {
        this.isLoading = true;
        const config = {
          headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
        };

        axios.post('./api/settings/GetUsers?username=' + this.searchQuery, {}, config).then(resp => {
          setTimeout(() => {
            this.isLoading = false;
            this.searchResults = resp.data;
          }, 750);
        }).catch((err) => {
          setTimeout(() => {
            this.snackbar_bad = true;
          }, 750)
        });
      },
      setUserRole(user) {
        const config = {
          headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
        };

        axios.post("./api/settings/SetUser?username=" + user.userName + "&role=" + user.name, {}, config).then(resp => {
          this.snackbar_good = true
        }).catch((r) => {
          this.snackbar_bad = true;
        });
      }
    }
  };
</script>

<style>
  .bg-window {
    background-color: #E0E0E0 !important;
  }
</style>
