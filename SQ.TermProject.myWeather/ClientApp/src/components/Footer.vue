<template>
  <footer class="p-0">
    <v-footer class="bg-transparent m-0">
      <v-row class="bg-transparent">
        <v-col cols="4" class="bg-transparent">
          <a href="https://github.com/ItsSimko/MVC-Weather-App" target="_blank" class="white--text">GitHub</a>
        </v-col>
        <v-col cols="4" class="text-center bg-transparent">
          <span>&copy; 2023 myWeather</span>
        </v-col>
        <v-col cols="4" class="text-right bg-transparent">
          <v-dialog width="500" v-if="token == null && $route.path != '/login' && $route.path != '/register'">
            <template v-slot:activator="{ props }">
              <v-btn class="mx-1" color="primary" v-bind="props" text="Login"> </v-btn>
            </template>

            <template v-slot:default="{ isActive }">
              <v-card>
                <v-toolbar dark
                           color="primary">
                  <v-toolbar-title>Login</v-toolbar-title>
                  <v-spacer></v-spacer>
                  <v-toolbar-items>
                    <v-btn icon
                           dark
                           @click="dialog = false">
                      <v-icon>mdi-close</v-icon>
                    </v-btn>
                  </v-toolbar-items>
                </v-toolbar>
                <v-card-text>
                  <Login @loginHappened="loginHandler"/>
                </v-card-text>
              </v-card>
            </template>
          </v-dialog>

          <v-dialog width="500" v-if="token == null && $route.path != '/login' && $route.path != '/register'">
            <template v-slot:activator="{ props }">
              <v-btn class="mx-1" color="secondary" v-bind="props" text="Register"> </v-btn>
            </template>

            <template v-slot:default="{ isActive }">
              <v-card title="Dialog">
                <v-card-text>
                  
                </v-card-text>

                <v-card-actions>
                  <v-spacer></v-spacer>

                  <v-btn text="Close Dialog"
                         @click="isActive.value = false"></v-btn>
                </v-card-actions>
              </v-card>
            </template>
          </v-dialog>

          <p v-if="userName != null || token != null">
            Hello, {{ userName }}
            <v-btn text="Settings" color="secondary" @click="goToSettings" class="mx-1"></v-btn>
            <v-btn text="Sign Out" color="secondary" @click="signOut" class="mx-1"></v-btn>
          </p>
          
        </v-col>
      </v-row>
    </v-footer>
  </footer>
</template>

<style>
  footer {
    position: fixed;
    bottom: 0;
    width: 100%;
    background-color: #333;
    color: white;
    text-align: center;
  }
</style>

<script setup lang="ts">
  import Login from '../components/LoginBox.vue'

</script>

<script lang="ts">
  export default {
    data() {
      return {
        token: localStorage.getItem('token'),
        userName: localStorage.getItem('userName'),
        dialog: false
      }
    },
    components: {
      Login,
    },
    methods: {
      signOut() {
        localStorage.removeItem('token');
        localStorage.removeItem('userName');
        localStorage.removeItem('role');
        this.userName = null;
        this.token = null;
        console.log(this.$route.path);
        if (this.$route.path == "/panel") {
          this.$router.push('/login');
        }
      },
      loginHandler() {
        if (localStorage.getItem('token') != null) {
          this.userName = localStorage.getItem('userName');
          this.token = localStorage.getItem('token');
        }
        else {
          this.userName = null;
          this.token = null;
        }
      },
      goToSettings() {
        this.$router.push("/panel");
      }
    }
  }
</script>
