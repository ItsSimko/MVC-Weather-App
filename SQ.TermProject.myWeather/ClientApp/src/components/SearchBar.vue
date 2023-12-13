<script setup lang="ts">
    import cities from "../assets/cities.json"
    import axios from "axios"
    import {ref, reactive, watch} from "vue";
    
  let options = ref(cities);

  function getItemText(item: {name: string, country: string}) {
        return item.name + ', ' + item.country;
  }


  declare interface WeatherData {
    ///
    "lat"?: number,
    "lon"?: number,
    "timezone"?: string,
    "timezone_offset"?: number,
    "found": boolean,
    "current"?: {
      "dt"?: number,
      "sunrise"?: number,
      "sunset"?: number,
      "temp"?: number,
      "feels_like"?: number,
      "pressure"?: number,
      "humidity"?: number,
      "dew_point"?: number,
      "uvi"?: number,
      "clouds"?: number,
      "visibility"?: number,
      "wind_speed"?: number,
      "wind_deg"?: number,
      "wind_gust"?: number,
      "weather"?: [
        {
          "id"?: number,
          "main"?: string,
          "description"?: string,
          "icon"?: string
        }
      ],
    },

    ///
  }

</script>

<script lang="ts">

function updateWeatherData() {
  axios.post("/api/WeatherForecast/GetWeather?cityName=" + myLoc.myLocationT.name + "&country=" + myLoc.myLocationT.country + "&lon=" + myLoc.myLocationT.lng + "&lat=" + myLoc.myLocationT.lat).then(resp => {
    if (resp.status == 200) {
      weatherData.data = resp.data;
      weatherData.data.found = true;
    }
    else {
      weatherData.data.found = false;
    }

  });
}
  export const myLoc = reactive({
    myLocationT: { name: "", country: "", lat: "", lng: "", },
  })

  export const weatherData = reactive({
    data: {} as WeatherData
  });

  watch(() => myLoc.myLocationT, (newValue, oldValue) => {
    updateWeatherData()
  })

</script>

<template>


  <v-container>
    <v-autocomplete label="Enter your city"
                    :items="options"
                    :item-title="getItemText"
                    v-model="myLoc.myLocationT"
                    return-object
                    hide-details="auto">
    </v-autocomplete>


  </v-container>

</template>
