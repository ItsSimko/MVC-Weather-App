<script setup lang="ts">
    import cities from "../assets/cities.json"
    import axios from "axios"
    import {ref, reactive, watch} from "vue";
    
    let options = ref(cities);

    function getItemText(item) {
        return item.name + ', ' + item.country;
  }



</script>

<script lang="ts">
function updateWeatherData() {
  console.log("test")
  axios.post("/api/WeatherForecast/GetWeather?cityName=" + myLoc.myLocationT.name).then(resp => {
    weatherData.data = resp.data;
    console.log(weatherData.data)
  });
}
  export const myLoc = reactive({
    myLocationT: [],
  })

  export const weatherData = reactive({
    data: null
  });

  watch(() => myLoc.myLocationT, (newValue, oldValue) => {
    updateWeatherData()
  })

</script>

<template>
    <v-autocomplete
    label="Enter your city"
    :items="options"
    :item-title="getItemText"
    v-model="myLoc.myLocationT"
    return-object
    hide-details="auto"
    >
    </v-autocomplete>
</template>
