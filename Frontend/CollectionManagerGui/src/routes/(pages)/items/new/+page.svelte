<!-- Create item page-->
<script>
  import { goto } from '$app/navigation';

  const BASE = 'http://localhost:5215/api';

  let itemName = $state('');
  let itemDescription = $state('');
  let itemType = $state('');
  let itemValue = $state('');
  let itemCount = $state('');
  let selectedCollection = $state('');

  // @ts-ignore
  let collections = $state([]);

  async function loadCollections() {
    const res = await fetch(`${BASE}/Collection`);
    collections = await res.json();
    
    console.log(collections[0]); // add this line
  }

async function createItem() {
    const res = await fetch(`${BASE}/Item`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            collectionID: selectedCollection === 'wishlist' ? null : Number(selectedCollection),
            wishlistID: selectedCollection === 'wishlist' ? 1 : null, // adjust as needed
            itemName,
            itemDescription,
            itemType,
            itemValue: Number(itemValue),
            itemCount: Number(itemCount)
        })
    });

    if (!res.ok) {
        const err = await res.text();
        alert(`Failed to create item: ${err}`);
        return;
    }

    goto('/collections');
  }

  loadCollections();

  /*async function login() {
    await goto('/collections');
  }*/
</script>

<h1 class="text-center text-4xl mt-10">
    CREATE ITEMS 
</h1>

<h2 class="text-xl flex justify-left ml-10 mt-5">
  PLEASE NOTE:
</h2>
<h2 class="text-xl flex justify-left ml-10">
  An item must be placed in a collection or wishlist and can't "live" on its own
</h2>

<div class="grid gap-x-10 gap-y-4 mt-10 max-w-4xl mx-auto">
  <div class="flex items-center gap-4 grid-cols-1">
    <label class="w-32 text-right">Name</label>
    <input class="border p-2 rounded w-96 text-black" type="text" bind:value={itemName} />
  </div>

  <div class="flex items-start gap-4 grid-cols-1">
    <label class="w-32 text-right mt-2">Description (optional)</label>
    <textarea class="border p-2 rounded w-96 h-32 text-black resize-none" bind:value={itemDescription}></textarea>
  </div>

  <div class="flex items-center gap-4 grid-cols-2">
    <label class="w-32 text-right">Type (optional)</label>
    <input class="border p-2 rounded w-96 text-black" type="text" bind:value={itemType} />
  </div>

  <div class="flex items-center gap-4 grid-cols-2">
    <label class="w-32 text-right">Value (optional)</label>
    <input class="border p-2 rounded w-96 text-black" type="number" bind:value={itemValue} />
  </div>

  <div class="flex items-center gap-4 grid-cols-2">
    <label class="w-32 text-right">Count (optional)</label>
    <input class="border p-2 rounded w-96 text-black" type="number" bind:value={itemCount} />
  </div>

  <!-- Dropdown for collection or wishlist -->
  <div class="flex items-center gap-4">
    <label class="w-32 text-right">Add to</label>
    <select class="border p-2 rounded w-96 text-black" bind:value={selectedCollection}>
      <option value="">-- Select --</option>
      <option value="wishlist">Wishlist</option>
      {#each collections as collection}
        <option value={collection.collectionID}>{collection.collectionName}</option>
      {/each}
    </select>
  </div>

  <button
    class="bg-purple-700 text-white px-6 py-2 rounded-lg mt-4 cursor-pointer hover:bg-purple-900"
    onclick={createItem}>
    Add item
  </button>

</div>

<nav class="flex justify-left ml-10 mt-10">
  <button
    class="bg-purple-700 text-white px-6 py-2 mb-10 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto('/collections')}>
    Go back
  </button>
</nav>