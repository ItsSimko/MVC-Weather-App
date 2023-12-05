<template>
  <v-container>
    <!-- Search Users Section -->
    <v-card>
      <v-card-title>Search Users</v-card-title>
      <v-card-text>
        <v-text-field v-model="searchQuery" label="Search Query"></v-text-field>
        <v-btn @click="searchUsers">Search</v-btn>
      </v-card-text>
    </v-card>

    <!-- Display Search Results and Set Roles -->
    <v-card v-if="searchResults.length > 0">
      <v-card-title>Search Results</v-card-title>
      <v-card-text>
        <v-list>
          <v-list-item v-for="(user, index) in searchResults" :key="index">
            <v-list-item-content>
              <v-list-item-title>{{ user.username }}</v-list-item-title>
              <v-list-item-subtitle>{{ user.email }}</v-list-item-subtitle>
            </v-list-item-content>
            <v-list-item-action>
              <v-select v-model="user.role" :items="roleOptions" label="Select Role"></v-select>
              <v-btn @click="setUserRole(user)">Set Role</v-btn>
            </v-list-item-action>
          </v-list-item>
        </v-list>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      searchQuery: '',
      searchResults: [],
      roleOptions: ['User', 'Admin', 'Superadmin']
    };
  },
  methods: {
    searchUsers() {
      // make api call to data base
      
      this.searchResults = [
        { id: 1, username: 'test', email: 'test@test.com', role: 'test' },
        { id: 2, username: 'User2', email: 'user2@test.com', role: 'test' },
      ];
    },
    setUserRole(user) {
       // api call to set user role
    }
  }
};
</script>
