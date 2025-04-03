<script setup lang="ts">
  import CardGrid from "./components/CardGrid.vue";
  import LoadingOverlay from "./components/LoadingOverlay.vue";
</script>

<template>
  <LoadingOverlay />
  <div class="min-h-screen bg-gray-100 justify-center items-center">
    <CardGrid />
  </div>
</template>
