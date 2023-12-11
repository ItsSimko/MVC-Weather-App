<template>
  <v-container>
    <v-form @submit.prevent="login">
      <v-text-field v-model="username" label="Username" outlined></v-text-field>
      <v-text-field v-model="password" label="Password" type="password" outlined></v-text-field>
      <v-btn color="primary" type="submit">Login</v-btn>
      <v-btn color="primary" @click="goToReg" class="mx-1">Register</v-btn>
      <v-alert v-if="this.badCredential===true" type="error"
               color="error"
               title="Login Failed"
               text="Invalid username or password." class="my-2"></v-alert>
    </v-form>
  </v-container>
</template>

<script setup lang="ts">
  import axios from 'axios';
</script>

<script lang="ts">
  export default {
    data() {
      return {
        email: '',
        username: '',
        password: '',
        badCredential: false
      };
    },
    methods: {
      login() {
        axios.post('api/auth/Login?username=' + this.username + '&password=' + this.password)
          .then(response => {



            (response)
          if (response.data.success == true) {
            this.badCredential = false;

            //this.$router.push("/panel")
          }
          else
          {
            this.badCredential = true;
            
          }

        })
          .catch(error => {
            console.error('Login failed:', error);

          });
      },

      goToReg() {
        //this.$router.push('/register');
      }
    }
  };
</script>

<style>
  .login-card {
    margin-top: 50px;
  }
</style>
