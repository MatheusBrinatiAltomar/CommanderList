<template>
    <div v-if="loadingStore.isLoading" class="fixed inset-0 bg-black bg-opacity-75 flex items-center justify-center z-50">
        <div class="text-white text-lg font-bold flex flex-col items-center">
            <svg class="animate-spin h-10 w-10 text-yellow-500 mb-4" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <circle cx="12" cy="12" r="10" stroke-width="4"></circle>
                <path d="M4 12a8 8 0 018-8"></path>
            </svg>
            Loading, please wait...
        </div>
    </div>
</template>
  
<script setup lang="ts">
    import { useLoadingStore } from "@/stores/LoadingStore";

    const loadingStore = useLoadingStore();
</script>
  