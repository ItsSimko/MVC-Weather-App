<template>
    <header :style="{ backgroundColor: headerColor }" class="header" v-if="showHeader == true">
      <h1>{{ message }}</h1>
    </header>
</template>

<style>
  .header {

    top: 0;
    width: 100%;
    background-color: #333;
    color: white;
    text-align: center;
    z-index: 23;
  }
</style>

<script>
  import axios from "axios";
export default {
  data() {
    return {
      message: 'test',
      headerColor: 'green',
      showHeader: false,
    };
  },
  methods: {
    setHeaderColor(msg) {
      if (msg === 'success') {
        this.headerColor = 'green';
      } else if (msg === 'warning') {
        this.headerColor = 'orange';
      } else if (msg === 'error') {
        this.headerColor = 'red';
      } else {
        this.headerColor = ''; 
      }
    }
  },
  created() {
    // call fetch every 30s to get site header
    setInterval(() =>
    {
      axios.post("./api/Settings/GetHeader").then((r) => {
        this.message = r.data.alertMsg;
        

        if (r.data.alertType == "none") {
          this.showHeader = false

        }
        else
        {
          this.showHeader = true
          this.setHeaderColor(r.data.alertType)
        }
      })
    }, 5000);

  }
};
</script>
