<template>
    <header :style="{ backgroundColor: headerColor }" class="header">
      <h1>{{ message }}</h1>
    </header>
</template>

<style>
  .header {
    position: fixed;
    top: 0;
    width: 100%;
    background-color: #333;
    color: white;
    text-align: center;
  }
</style>

<script>
export default {
  data() {
    return {
      message: 'test',
      headerColor: 'green',
      showHeader: false,
    };
  },
  watch: {
    message(newVal) {
      this.setHeaderColor(newVal);
    }
  },
  methods: {
    setHeaderColor(msg) {
      if (msg === 'good') {
        this.headerColor = 'green';
      } else if (msg === 'warning') {
        this.headerColor = 'yellow';
      } else if (msg === 'alert') {
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
      
    }, 30000);

  }
};
</script>
