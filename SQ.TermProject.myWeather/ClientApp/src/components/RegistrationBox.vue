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

      <v-btn type="submit" color="primary">Register</v-btn>
      <v-btn @click="$router.push('/login')" color="primary" class="mx-1">Login</v-btn>
    </v-form>

    <v-alert v-if="this.err === true" type="error"
             color="error"
             title="Login Failed"
             :text="errMsg" class="my-2"></v-alert>
  </v-container>
</template>

<script>
  import axios from 'axios'

export default {
  data() {
    return {
      username: '',
      email: '',
      password: '',
      confirmPassword: '',
      validationCode: '',
      err: false,
      errMsg: '',
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
      axios.post('api/auth/Register?username=' + this.username + '&password=' + this.password + '&email=' + this.email, null, {
        "Authorization": localStorage.getItem("token")
      }).then(resp => {
        console.log(resp)
        if (resp.data.success === true) {
          console.log("yup")
          this.$router.push('/panel')
        }
        else
        {
          console.log("nope")
          this.err = true
          this.errMsg = resp.data.msg
        }
      })
      { }
    },
  },
};
</script>
