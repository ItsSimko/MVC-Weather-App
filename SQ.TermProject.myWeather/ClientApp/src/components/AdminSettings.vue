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
        <v-btn @click="updateAlert">Update</v-btn>
      </v-col>
    </v-row>
  </v-container>

  <v-snackbar v-model="snackbar_bad"
              timeout="2000">
    Server Error occurred, header remains.

    <template v-slot:actions>
      <v-btn color="blue"
             variant="text"
             @click="snackbar_bad = false">
        Close
      </v-btn>
    </template>
  </v-snackbar>
  <v-snackbar v-model="snackbar_good"
              timeout="2000">
    Header updated

    <template v-slot:actions>
      <v-btn color="blue"
             variant="text"
             @click="snackbar_good = false">
        Close
      </v-btn>
    </template>
  </v-snackbar>
</template>


<script>
  import axios from 'axios';
  export default {
    data() {
      return {
        snackbar_bad: false,
        snackbar_good: false,
        alertMessage: '',
        selectedType: 'success',
        types: ['success', 'warning', 'error', 'none'],
      };
    },
    methods: {
      updateAlert() {
        const config = {
          headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
        };
        if (this.selectedType == 'none') {
          this.alertMessage = 'none'
        }
        axios.post('./api/Settings/SetHeader?msg=' + this.alertMessage + '&type=' + this.selectedType, {}, config).then((r) => {
          this.snackbar_good = true;
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
