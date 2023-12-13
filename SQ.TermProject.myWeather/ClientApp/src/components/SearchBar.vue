<script setup lang="ts">
    import cities from "../assets/cities.json"
    import axios from "axios"
    import {ref, reactive, watch} from "vue";
    
    let options = ref(cities);

  function getItemText(item: {name: string, country: string}) {
        return item.name + ', ' + item.country;
  }



</script>

<script lang="ts">
function updateWeatherData() {
  console.log("test")
  axios.post("/api/WeatherForecast/GetWeather?cityName=" + myLoc.myLocationT.name).then(resp => {
    console.log(resp)
    weatherData.data = resp.data;
  });
}
  export const myLoc = reactive({
    myLocationT: { name: "", country: "", lat: "", lng: "", },
  })

  export const weatherData = reactive({
    data: {
      "coord": {
        "lon": -80.5112,
        "lat": 43.4254
      },
      "weather": [
        {
          "id": 804,
          "main": "Clouds",
          "description": "overcast clouds",
          "icon": "04n"
        }
      ],
      "base": "stations",
      "main": {
        "temp": -0.2,
        "feels_like": -5.53,
        "temp_min": -0.77,
        "temp_max": 0.3,
        "pressure": 1025,
        "humidity": 75
      },
      "visibility": 10000,
      "wind": {
        "speed": 5.66,
        "deg": 280
      },
      "snow": null,
      "clouds": {
        "all": 100
      },
      "dt": 1702430925,
      "sys": {
        "type": 2,
        "id": 60894,
        "country": "CA",
        "sunrise": 1702385128,
        "sunset": 1702417566
      },
      "timezone": -18000,
      "id": 5992996,
      "name": "Kitchener",
      "cod": 200
    }
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
