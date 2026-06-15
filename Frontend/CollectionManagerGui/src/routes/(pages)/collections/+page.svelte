<!-- Collection page-->
<script>
  import { goto } from '$app/navigation';

  const BASE = 'http://localhost:5215/api';

  async function getCollections() {
    const res = await fetch(`${BASE}/Collection`);
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

  load();
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
  <p class="flex justify-left ml-10 mt-10 mb-10">There are no collections.</p>
  <a href="/collections/new">Create your first collection</a>

{:else}
  <ul class="grid grid-cols-3 gap-6 ml-10 mr-10 mb-10 items-start">
    {#each collections as collection}
      <li class="list-none border rounded-lg p-6">
        <h2 class="font-bold text-[25px]">{collection.collectionName}</h2>
        <p class="text-[17px]">{collection.collectionDescription}</p>
        <button 
          class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900"
          onclick={() => goto(`/collections/${collection.collectionID}`)}>
          View collection
        </button>      
      </li>
    {/each}
  </ul>
{/if}

<!-- Dette er et eksempel på hvordan en collection ville se ud hvis den loadede - bruges til design -->
<ul class="grid grid-cols-3 gap-6 ml-10 mr-10 mb-10 items-start">  
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Collection Name</h2>
    <p class="text-[17px]">Collection Description. Here i have written a little something about my collection</p>
    <button class="inline-block inline bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/collections/test')}>View TEST collection</button>
  </li>
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Collection Name 2</h2>
    <p class="text-[17px]">Collection Description. Here i have written a little something about my collection</p>
    <button class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/collections/test')}>View TEST collection</button>
  </li>
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Collection Name 3</h2>
    <p class="text-[17px]">Collection Description. Here i have written a little something about my collection</p>
    <button class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/collections/test')}>View TEST collection</button>
  </li>
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Collection Name 4</h2>
    <p class="text-[17px]">Collection Description. Here i have written a little something about my collection</p>
    <button class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/collections/test')}>View TEST collection</button>
  </li>
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Collection Name 5</h2>
    <p class="text-[17px]">Collection Description. Here i have written a little something about my collection</p>
    <button class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/collections/test')}>View TEST collection</button>
  </li>
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Collection Name 6</h2>
    <p class="text-[17px]">Collection Description. Here i have written a little something about my collection</p>
    <button class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/collections/test')}>View TEST collection</button>
  </li>
</ul>