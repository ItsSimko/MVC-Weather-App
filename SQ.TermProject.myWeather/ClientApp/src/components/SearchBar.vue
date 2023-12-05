<script setup lang="ts">
    import cities from "../assets/cities.json"
    import {ref, reactive} from "vue";
    
    let myLocation = ref([]);
    let options = ref(cities);

    function getItemText(item) {
        return item.name + ', ' + item.country;
    }

</script>

<script lang="ts">
export default {
    data() {
        return {
            
        }
    },
}

export const myLoc = reactive({
    myLocationT: [],
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
