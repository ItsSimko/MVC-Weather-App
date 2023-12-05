<script setup lang="ts">
    import {ref} from "vue";
    import  {myLoc}  from "./SearchBar.vue";

    let temp = ref(23);
</script>

<script lang="ts">
    export default {
        data(){
            return{
                location: myLoc,
                unitOfMeasure: "F"
            }
        },
    }
</script>

<template>
    <v-container class="bg-blue-grey-darken-4 rounded-lg w-70 p-6">
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
                                <v-switch label="C⇔F" class="mx-auto"></v-switch>
                            </v-sheet>
                        </v-col>
                    </v-row>
                    <v-row >
                        <p class="text-h1 mx-auto my-2">{{temp}}° {{ unitOfMeasure }}</p>
                    </v-row>
                </v-sheet>
            </v-col>
            <v-col class="bg-transparent mx-1 border border-primary">
                <v-sheet class="bg-transparent">
                    <p class="text-h5"> Additional Weather data goes here... </p>
                </v-sheet>
            </v-col>
        </v-row>
    </v-container>
</template>

<style>
v-sheet {
    background-color: transparent;
}
</style>