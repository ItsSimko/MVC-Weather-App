<template>
  <v-container>
    <v-form @submit.prevent="login">
      <v-text-field v-model="email" label="Email" outlined></v-text-field>
      <v-text-field v-model="password" label="Password" type="password" outlined></v-text-field>
      <v-btn color="primary" type="submit">Login</v-btn>
      <v-btn color="primary" @click="goToReg" class="mx-1">Register</v-btn>
    </v-form>
  </v-container>
</template>

<script>
  export default {
    data() {
      return {
        email: '',
        password: ''
      };
    },
    methods: {
      login() {
        // make call to backend
      },

      goToReg() {
        this.$router.push('/admin/register');
      }
    }
  };
</script>

<style>
  .login-card {
    margin-top: 50px;
  }
</style>
