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
  <p class="flex justify-left ml-10 mt-10">Fetching collections...</p>

{:else if error}
  <p class="flex justify-left ml-10 mt-10">{error}</p>

{:else if collections.length === 0}
  <p class="flex justify-left ml-10 mt-10">There are no collections.</p>
  <a href="/collections/new">Create your first collection</a>

{:else}
  <ul>
    {#each collections as collection}
      <li class="ml-10 mb-10">
        <h2>{collection.collectionName}</h2>
        <p>{collection.collectionDescription}</p>
        <button onclick={() => goto(`/collections/${collection.collectionID}`)}>
          See collection
        </button>      
      </li>
    {/each}
  </ul>
{/if}

<!-- Dette er eksempler på hvordan en collwction ville se ud hvis den loadede - bruges til design -->
<li class="ml-10 mb-10">
  <p class="mt-5">
    Collection Name
  </p>
  <p class="">
    Collection Description
  </p>
  <p class="">
    See collection
  </p>
</li>
