<script setup lang="ts">
  import { ref, watch, reactive, toRefs } from "vue";
  import { myLoc, weatherData } from "./SearchBar.vue";


  let location = myLoc;
  let weather = weatherData;
  
  let isMobile = window.innerWidth <= 767;

  //console.log(isMobile + "I am mobile")

  let currentMetric = 'C';

  function changeMetric() {
    if (currentMetric === 'C') {
      weatherData.data.current!.temp = cToF(weatherData.data.current!.temp)
      weatherData.data.current!.feels_like = cToF(weatherData.data.current!.feels_like)
      currentMetric = "F"
    }
    else if (currentMetric === 'F') {
      currentMetric = "C"
      weatherData.data.current!.temp = fToC(weatherData.data.current!.temp)
      weatherData.data.current!.feels_like = fToC(weatherData.data.current!.feels_like)

    }
  }

  function cToF(val: number) {
    return (val * (9 / 5)) + 32
  }

  function fToC(val: number) {
    return (val - 32) * (5 / 9)
  }
</script>





<template>
  <v-alert v-if="weather.data.found == false" density="compact"
           type="warning"
           title="Alert title"
           text="The server could not find weather data for the location. Our apologies" class="my-2"></v-alert>
  <v-container class="bg-blue-grey-darken-4 rounded-lg w-70 p-6" v-if="weather.data.current  && weather.data.found == true">
    <v-row class="bg-transparent ma-3">
      <p class="text-h3 mx-auto">{{ location.myLocationT.name }}, {{location.myLocationT.country}}</p>
    </v-row>
    <v-row no-gutters class="ma-2 py-2">
      <v-col cols="4" class="mx-auto mx-1">
        <v-sheet class="bg-transparent">
          <v-row no-gutters class="">
            <v-col cols="9">
              <v-sheet class="bg-transparent">
                <p class="mx-auto text-center text-h4 my-2">Current Weather</p>
              </v-sheet>
            </v-col>
            <v-col cols="3">
              <v-sheet class="bg-transparent">
                <v-switch @change="changeMetric" label="C⇔F" class="mx-auto"></v-switch>
              </v-sheet>
            </v-col>
          </v-row>
          <v-row>
            <p class="text-h1 mx-auto my-2">{{weather.data.current.temp!.toFixed(2)}}° {{currentMetric}}</p>
          </v-row>
        </v-sheet>
      </v-col>
      <v-col class="bg-transparent mx-1" v-if="isMobile == false">
        <v-sheet class="bg-transparent">
          <v-row>
            <v-col>
              <v-sheet class="bg-transparent">
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p> Feels Like:</p>
                    </v-sheet>
                  </v-col>
                </v-row>
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p class="text-h4"> {{ weather.data.current.feels_like!.toFixed(2) }}°{{currentMetric}}</p>
                    </v-sheet>
                  </v-col>
                </v-row>
              </v-sheet>
            </v-col>
            <v-col>
              <v-sheet class="bg-transparent">
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p> Humidity:</p>
                    </v-sheet>
                  </v-col>
                </v-row>
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p class="text-h4"> {{ weather.data.current!.humidity }}%</p>
                    </v-sheet>
                  </v-col>
                </v-row>
              </v-sheet>
            </v-col>
            <v-col>
              <v-sheet class="bg-transparent">
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p> Cloud Coverage:</p>
                    </v-sheet>
                  </v-col>
                </v-row>
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p class="text-h4"> {{ weather.data.current!.clouds}}%</p>
                    </v-sheet>
                  </v-col>
                </v-row>
              </v-sheet>
            </v-col>
          </v-row>

          <v-row>
            <v-col>
              <v-sheet class="bg-transparent">
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p> Wind Speed:</p>
                    </v-sheet>
                  </v-col>
                </v-row>
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p class="text-h4"> {{ weather.data.current!.wind_speed }} km/h</p>
                    </v-sheet>
                  </v-col>
                </v-row>
              </v-sheet>
            </v-col>
            <v-col>
              <v-sheet class="bg-transparent">
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p> Visibility:</p>
                    </v-sheet>
                  </v-col>
                </v-row>
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p class="text-h4"> {{ weather.data.current!.visibility }} m</p>
                    </v-sheet>
                  </v-col>
                </v-row>
              </v-sheet>
            </v-col>
            <v-col>
              <v-sheet class="bg-transparent">
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p> Pressure:</p>
                    </v-sheet>
                  </v-col>
                </v-row>
                <v-row class="mx-auto text-center">
                  <v-col>
                    <v-sheet class="bg-transparent">
                      <p class="text-h4"> {{ weather.data.current!.pressure }} hPa</p>
                    </v-sheet>
                  </v-col>
                </v-row>
              </v-sheet>
            </v-col>
          </v-row>

        </v-sheet>
      </v-col>
    </v-row>
  </v-container>
</template>

<style scoped>
v-sheet {
    background-color: transparent!important;
}
</style>
