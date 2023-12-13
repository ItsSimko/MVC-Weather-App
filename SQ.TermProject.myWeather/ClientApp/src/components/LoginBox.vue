<template>
  <v-container>
    <v-form @submit.prevent="login" v-if="this.isLoading == false && this.success == false">
      <v-text-field v-model="username" label="Username" outlined></v-text-field>
      <v-text-field v-model="password" label="Password" type="password" outlined></v-text-field>
      <v-btn color="primary" type="submit">Login</v-btn>
      <v-btn color="primary" @click="goToReg" class="mx-1">Register</v-btn>
      <v-alert v-if="this.badCredential===true" type="error"
               color="error"
               title="Login Failed"
               text="Invalid username or password." class="my-2"></v-alert>
      <v-alert v-if="this.servErr===true" type="error"
               color="error"
               title="Server Error Occurred"
               text="Try again in a few moments" class="my-2"></v-alert>
    </v-form>
    <LoadingSpinner v-if="this.isLoading == true"></LoadingSpinner>

    <v-alert v-if="success == true"
             type="success"
             title="Alert title"
             text="Login Successful">
    </v-alert>
    <div class="text-center my-2" v-if="success==true">
      <v-btn color="primary" @click="goToMain">Go to Weather App</v-btn>
      <v-btn color="primary" @click="goToPanel" class="mx-1">Continue to Panel</v-btn>
    </div>
  </v-container>
</template>

<script setup lang="ts">
  import { defineComponent } from 'vue';
  import axios from 'axios';
  import jwt_decode from 'jwt-decode';
  import LoadingSpinner from './Loading.vue'
</script>

<script lang="ts">
  export default defineComponent({
    data() {
      return {
        email: '',
        username: '',
        password: '',
        badCredential: false,
        servErr: false,
        isLoading: false,
        success: false
      };
    },
    created()
    {
      if (localStorage.getItem("token") != null) {
        this.success = true
      }
    },
    methods: {
      login() {
        this.isLoading = true;
        this.servErr = false
        axios.post('api/auth/Login?username=' + this.username + '&password=' + this.password)
          .then(response => {
          if (response.data.success == true) {
            this.badCredential = false;


            localStorage.setItem('token', response.data.token);
            localStorage.setItem('userName', this.username);

            axios.defaults.headers.common['Authorization'] = `Bearer ${response.data.token}`;

            const jwt_decoded = jwt_decode(response.data.token);

            localStorage.setItem('role', jwt_decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);

            this.$emit('loginHappened');

            this.success = true;
          }
          else
          {
            this.badCredential = true;
          }
            setInterval(() => {

              this.isLoading = false;
            }, 1500);

        })
          .catch(error => {
            this.servErr = true;
            setInterval(() => {

              this.isLoading = false;
            }, 1500);

          });
      },
      goToPanel() {
        this.$router.push('/panel');
      },
      goToMain() {
        this.$router.push('/');
      },
      goToReg() {
        this.$router.push('/register');
      }
    }
  });
</script>

<style>
  .login-card {
    margin-top: 50px;
  }
</style>
