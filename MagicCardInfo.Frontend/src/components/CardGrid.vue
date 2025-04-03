<script setup lang="ts">
  import { ref, onMounted, watch, onUnmounted } from "vue";
  import { getCards } from "../services/CardService";
  import type { Card } from "../types/Card";
  import { useLoadingStore } from "@/stores/LoadingStore";
  import { replaceManaSymbols } from "@/helpers/ReplaceManaSymbols";
  
  const loadingStore = useLoadingStore();
  const cards = ref<Card[]>([]);
  const keyword = ref("");
  const pageNumber = ref(1);
  const hasMoreCards = ref(true);
  const title = "Click to see the card on Scryfall!";
  let debounceTimeout: ReturnType<typeof setTimeout> | null = null;

  const fetchCards = async (isNewSearch = false) => {
    if (loadingStore.isLoading || !hasMoreCards.value) return;

    try {
      loadingStore.show();

      if (isNewSearch) {
        pageNumber.value = 1;
        hasMoreCards.value = true;
        cards.value = []; 
      }

      const newCards = await getCards(keyword.value, pageNumber.value);
      

      if (newCards.length === 0) {
        hasMoreCards.value = false; 
      } else {
        cards.value.push(...newCards); 
        pageNumber.value++; 
      }
    } catch (error) {
      console.error("Error fetching cards:", error);
    } finally {
      loadingStore.hide();
    }
  };

  onMounted(() => {
    fetchCards();
    window.addEventListener("scroll", handleScroll);
  });

  onUnmounted(() => {
    if (debounceTimeout) clearTimeout(debounceTimeout);
    window.removeEventListener("scroll", handleScroll);
  })


  const handleScroll = () => {
    const bottomOffset = 300;
    const nearBottom =
      window.innerHeight + window.scrollY >= document.body.offsetHeight - bottomOffset;

    if (nearBottom) {
      fetchCards();
    }
  };

  function onClickImage(card:Card) {
    window.open(card.scryfall_uri, '_blank').focus();
  }

  watch(keyword, () => {
    if (debounceTimeout) clearTimeout(debounceTimeout);
    debounceTimeout = setTimeout(() => {
      hasMoreCards.value = true;
      fetchCards(true);
    }, 500);
  });
</script>

<template>
  <div class="rounded-lg shadow-lg p-4">
    <div class="grid grid-cols-2 gap-6 bg-gray-800 text-white p-4 rounded-lg shadow-lg" style="margin-bottom: 10px;">
      <div>
        <h1 class="font-bold text-3xl">Commanders!</h1>
        <h3 class="font-italic">Single Faced Creature cards only!</h3>
      </div>
      <input 
        v-model="keyword" 
        type="text" 
        placeholder="Search Name and Oracle Text"
        class="border-2 border-yellow-500 bg-gray-700 text-white p-2 rounded-md w-full"
      />
    </div>
    <div class="grid grid-cols-4 gap-6">
      <template v-for="(card) in cards" :key="card.id">
        <div class="col-span-2 bg-gray-800 text-white p-4 rounded-lg shadow-lg flex flex-row items-center gap-4">
            <img 
              :src="card.image_uris?.normal" 
              :alt="card.name" 
              class="w-1/2 rounded-md cursor-pointer"
              @click="onClickImage(card)"
              :title="title"
            />
          <div class="flex flex-col justify-between w-full">
            <h2 class="text-lg font-bold">{{ card.name }}</h2>
            <p class="text-gray-400" v-html="replaceManaSymbols(card.mana_cost)"></p>
            <p class="text-gray-300 italic">{{ card.type_line }}</p>
            <p class="text-sm mt-2 whitespace-pre-line" v-html="replaceManaSymbols(card.oracle_text)"></p>
          </div>
        </div>
      </template>
    </div>
  </div>
</template>