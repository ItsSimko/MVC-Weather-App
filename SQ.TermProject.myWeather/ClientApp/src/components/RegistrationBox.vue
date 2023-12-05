<template>
  <v-container>
    <v-form @submit.prevent="registerUser">
      <v-text-field v-model="username"
                    label="Username"
                    required></v-text-field>

      <v-text-field v-model="email"
                    label="Email"
                    required
                    :rules="emailRules"></v-text-field>

      <v-text-field v-model="password"
                    label="Password"
                    type="password"
                    required
                    :rules="passwordRules"></v-text-field>

      <v-text-field v-model="confirmPassword"
                    label="Confirm Password"
                    type="password"
                    required
                    :rules="confirmPasswordRules"></v-text-field>

      <v-text-field v-model="validationCode"
                    label="Please enter your the code provided by the superadmin."
                    type="password"
                    required></v-text-field>

      <v-btn type="submit" color="primary">Register</v-btn>
    </v-form>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      username: '',
      email: '',
      password: '',
      confirmPassword: '',
      validationCode: '',
      emailRules: [
        v => !!v || 'Email is required',
        v => /.+@.+\..+/.test(v) || 'Email must be valid',
      ],
      passwordRules: [
        v => !!v || 'Password is required',
        v => (v && v.length >= 8) || 'Password must be at least 8 characters',
      ],
      confirmPasswordRules: [
        v => !!v || 'Please confirm your password',
        v => v === this.password || 'Passwords must match',
      ],
    };
  },
  methods: {
    registerUser() {
      // send to server logic
    },
  },
};
</script>
