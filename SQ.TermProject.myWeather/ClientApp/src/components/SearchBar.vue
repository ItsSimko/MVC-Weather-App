<script setup lang="ts">
    import cities from "../assets/cities.json"
    import axios from "axios"
    import {ref, reactive, watch} from "vue";
    
  //let options = ref();

        return item.name + ", " + item.country;
  }

    interface WeatherData {
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

  interface LocData {
  }

</script>

<script lang="ts">

  interface WeatherData {
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
      "temp": number,
      "feels_like": number,
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


  export default {
    data() {
      return {
        selectedItem: null,
        option: {
          "country": "ZW",
          "name": "Filabusi",
          "lat": "-20.53333",
          "lng": "29.28502"
        } as LocData,
        options: Object.values(myLoc.myLocationT as LocData)
      };
    },
    mounted() {
      // Make an Axios request to fetch the data
      axios.get("./cities.json").then(resp => {
        this.options = resp.data
      })
    }
  };

  interface LocData {
  }

  export const myLoc = reactive({
  })

  export const weatherData = reactive({
    data: {} as WeatherData
  });

  watch(() => myLoc.myLocationT, () => {
    updateWeatherData()
  })

  function updateWeatherData() {
      if (resp.status == 200) {
        weatherData.data = resp.data;
        weatherData.data.found = true;
      }
      else {
        weatherData.data.found = false;
      }

    }).catch((r) => {
    });
  }

</script>

<template>


  <v-container>
    <v-autocomplete label="Enter your city"
                    :items="options"
                    :item-title="getItemText"
                    v-model="myLoc.myLocationT"
                    return-object
    </v-autocomplete>


  </v-container>

</template>
