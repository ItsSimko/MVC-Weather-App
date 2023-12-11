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
          <v-dialog width="500">
                <template v-slot:activator="{ props }">
                  <v-btn class="mx-1" color="primary" v-bind="props" text="Open Dialog"> </v-btn>
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
                      <Login />
                    </v-card-text>
                  </v-card>
                </template>
          </v-dialog>

          <v-dialog width="500">
            <template v-slot:activator="{ props }">
              <v-btn class="mx-1" color="secondary" v-bind="props" text="Open Dialog"> </v-btn>
            </template>

            <template v-slot:default="{ isActive }">
              <v-card title="Dialog">
                <v-card-text>
                  <LoginBox />
                </v-card-text>

                <v-card-actions>
                  <v-spacer></v-spacer>

                  <v-btn text="Close Dialog"
                         @click="isActive.value = false"></v-btn>
                </v-card-actions>
              </v-card>
            </template>
          </v-dialog>
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
