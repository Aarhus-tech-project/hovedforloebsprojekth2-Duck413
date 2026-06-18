<!-- Collection page-->
<script>
  import { goto } from '$app/navigation';
  import { getToken } from '$lib/auth.js';
  import { onMount } from 'svelte';
  import { BASE } from '$lib/config.js'; 

  async function getCollections() {
    const token = getToken();
    const res = await fetch(`${BASE}/Collection`, {
      headers: {
        'Authorization': `Bearer ${token}`
      }
    });
    return res.json();
  }

  // @ts-ignore
  let collections = $state([]);
  let loading = $state(true);
  let error = $state('');

  async function load() {
    try {
      collections = await getCollections();
    } catch (e) {
      error = 'Could not fetch collections';
    } finally {
      loading = false;
    }
  }

    onMount(() => {
    load();
  });
</script>

<h1 class="text-center text-4xl mt-10 mb-12">
    MY COLLECTIONS
</h1>

<nav class="flex justify-left ml-10 mt-6 mb-10">
  <button 
    class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto('/collections/new')}>
    + Create a new collection
  </button>
</nav>

{#if loading}
  <p class="flex justify-left ml-10 mt-10 mb-10">Fetching collections...</p>

{:else if error}
  <p class="flex justify-left cursive ml-10 mt-10 mb-10">{error}</p>

{:else if collections.length === 0}
  <p class="flex justify-left ml-10 mt-10 ">There are no collections.</p>
  <p class="flex-justify-left ml-10">Click the button to make your first collection</p>

{:else}
  <ul
    class="grid gap-6 px-4 md:px-10 mb-10 items-start [grid-template-columns:repeat(auto-fill,minmax(320px,480px))]">    
    {#each collections as collection}
      <li class="flex flex-col list-none border rounded-lg p-6 h-70 w-full">
        <h2 class="font-bold text-[25px]">
          {collection.collectionName}
        </h2>
        <p class="text-[17px] line-clamp-5">
          {collection.collectionDescription}
        </p>
        <button 
          class="inline-block bg-gray-400 text-white px-6 py-2 mt-auto rounded-lg cursor-pointer hover:bg-purple-900"
          onclick={() => goto(`/collections/${collection.collectionId}`)}>
          View collection
        </button>      
      </li>
    {/each}
  </ul>
{/if}