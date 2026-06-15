<!-- Create item page-->
<script>
  import { goto } from '$app/navigation';

  const BASE = 'http://localhost:5215/api';

  const { data } = $props();

  let itemName = $state('');
  let itemDescription = $state('');
  let itemType = $state('');
  let itemValue = $state('');
  let itemCount = $state('');
  let selectedCollection = $state(data.collectionId);  
  let submitted = $state(false);

  // @ts-ignore
  let collections = $state([]);

  async function loadCollections() {
    const res = await fetch(`${BASE}/Collection`);
    collections = await res.json();
    
    console.log(collections[0]); // add this line
  }

async function createItem() {
    submitted = true;
    if (!itemName.trim() || !selectedCollection) {
      return;
    }  
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

    if (selectedCollection === 'wishlist') {
        goto('/wishlist');
    } else {
        goto(`/collections/${selectedCollection}`);
    }
  }

  loadCollections();

  /*async function login() {
    await goto('/collections');
  }*/
</script>

<h1 class="text-center text-4xl mt-10">
    CREATE A NEW ITEM 
</h1>

<h2 class="text-xl flex justify-left ml-10 mt-5">
  PLEASE NOTE:
</h2>
<h2 class="text-xl justify-left ml-10">
  All <span class="text-red-700">*</span> must be filled out
</h2>

<div class="w-full max-w-4xl mx-auto px-4">
  <div class="grid grid-cols-2 gap-x-4 gap-y-4 mt-10">

    <div class="flex items-center gap-4">
      <label class="w-20 shrink-0 text-right">Name<span class="text-red-700">*</span></label>
      <div class="flex flex-col flex-1">
        <input class="border p-2 rounded w-full text-black {submitted && !itemName.trim() ? 'border-red-500 border-2' : ''}" type="text" bind:value={itemName} />
        {#if submitted && !itemName.trim()}
          <p class="text-red-700 text-sm mt-1">Pick a name for your item</p>
        {/if}
      </div>
    </div>

    <div class="flex items-center gap-4">
      <label class="w-20 shrink-0 text-right">Type</label>
      <input class="border p-2 rounded w-full text-black flex-1" type="text" bind:value={itemType} />
    </div>

    <div class="flex items-start gap-4 row-span-2">
      <label class="w-20 shrink-0 text-right mt-2">Description</label>
      <textarea class="border p-2 rounded w-full h-32 text-black resize-none flex-1" bind:value={itemDescription}></textarea>
    </div>

    <div class="flex items-center gap-4 self-start">
      <label class="w-20 shrink-0 text-right">Value</label>
      <input class="border p-2 rounded w-full text-black flex-1" type="number" bind:value={itemValue} />
    </div>

    <div class="flex items-center gap-4 self-start">
      <label class="w-20 shrink-0 text-right">Count</label>
      <input class="border p-2 rounded w-full text-black flex-1" type="number" bind:value={itemCount} />
    </div>

    <div class="col-span-2 flex items-center justify-center mt-5 mb-5 gap-4">
      <label class="w-32 shrink-0 text-right">Add to <span class="text-red-700">*</span></label>
      <div class="flex flex-col flex-1 max-w-sm">
        <select
          class="border p-2 rounded w-full text-black"
          style={submitted && !selectedCollection ? 'border: 2px solid red' : ''}
          bind:value={selectedCollection}>
          <option value="">-- Select --</option>
          <option value="wishlist">Wishlist</option>
          {#each collections as collection}
            <option value={collection.collectionID}>{collection.collectionName}</option>
          {/each}
        </select>
        {#if submitted && !selectedCollection}
          <p class="text-red-700 text-sm mt-1">Select a collection or a wishlist</p>
        {/if}
      </div>
    </div>

    <div class="col-span-2 flex justify-center">
      <button
        class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={createItem}>
        Add item
      </button>
    </div>
  </div>
</div>

<nav class="flex justify-left ml-10">
  <button 
    class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto(data.from)}>
    Cancel
  </button>
</nav>