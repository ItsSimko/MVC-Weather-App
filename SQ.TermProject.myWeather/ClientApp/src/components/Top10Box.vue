<template>
  <v-table class="bg-window text-center" v-if="loading == false">
    <thead>
      <tr class="text-h4">
        <th class="text-center">
          City
        </th>
        <th class="text-center">
          Count
        </th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in listData" :key="item.Location" class="text-h5">
        <td>{{ item.Location }}</td>
        <td>{{ item.SearchCount }}</td>
      </tr>
    </tbody>
  </v-table>

  <LoadingBar v-if="loading == true"></LoadingBar>
</template>

<script setup lang="ts">
  import LoadingBar from "./Loading.vue"
</script>

<script lang="ts">
  import axios from 'axios';

  declare interface listData {
    Location: string,
    SearchCount: string
  }


  export default {
    data() {
      return {
        listData: [] as listData[],
        loading: false
      };
    },
    created() {
      this.fetchData();
    },
    methods: {
      fetchData() {
        this.loading = true;
        axios.post('./api/stats/Stastics/GetTop10Searches')
          .then(response => {
            this.listData = response.data;
            this.loading = false;
          }).catch((e) => {
            this.loading = false;
          });
      },
    },
  };
</script>

<style>
  .bg-window {
    background-color: #E0E0E0 !important;
  }
</style>
