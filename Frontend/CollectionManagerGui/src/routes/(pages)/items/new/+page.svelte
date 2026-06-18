<!-- Create item page-->
<script>
  import { goto } from '$app/navigation';
  import { getToken } from '$lib/auth.js';
  import { onMount } from 'svelte';
  import { BASE } from '$lib/config.js'; 

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
  let wishlistId = $state(null);

  async function loadCollections() {
    const token = getToken();
    const res = await fetch(`${BASE}/Collection`, {
      headers: {
        'Authorization': `Bearer ${token}`
      }
    });
    collections = await res.json();
  }

  async function loadWishlist() {
    const token = getToken();
    const res = await fetch(`${BASE}/Wishlist`, {
      headers: {
        'Authorization': `Bearer ${token}`
      }
    });
    if (res.ok) {
      const data = await res.json();
      wishlistId = data.wishlistId;
    }
  }

async function createItem() {
    submitted = true;
    if (!itemName.trim() || !selectedCollection) {
      return;
    }
    const token = getToken();
    const res = await fetch(`${BASE}/Item`, {
        method: 'POST',
        headers: { 
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify({
            collectionID: selectedCollection === 'wishlist' ? null : Number(selectedCollection),
            wishlistID: selectedCollection === 'wishlist' ? wishlistId : null,
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

    onMount(() => {
    loadCollections();
    loadWishlist();
  });
</script>

<h1 class="text-center text-4xl mt-10">
    CREATE A NEW ITEM 
</h1>

<h2 class="text-xl text-center ml-10 mt-15">
  All <span class="text-red-700">*</span> must be filled out
</h2>

<div class="w-full max-w-4xl mx-auto px-4">
  <div class="grid grid-cols-1 md:grid-cols-2 gap-x-4 gap-y-4 mt-10">
    <div class="flex flex-col gap-2">
      <label class="text-left">Name<span class="text-red-700">*</span></label>
      <input class="border p-2 rounded w-full text-black {submitted && !itemName.trim() ? 'border-red-500 border-2' : ''}" type="text" bind:value={itemName} />
      {#if submitted && !itemName.trim()}
        <p class="text-red-700 text-sm mt-1">Pick a name for your item</p>
      {/if}
    </div>

    <div class="flex flex-col gap-2">
      <label class="text-left">Type</label>
      <input class="border p-2 rounded w-full text-black" type="text" bind:value={itemType} />
    </div>

    <div class="flex flex-col gap-2 row-span-2">
      <label class="text-left">Description</label>
      <textarea class="border p-2 rounded w-full h-32 text-black resize-none" bind:value={itemDescription}></textarea>
    </div>

    <div class="flex flex-col gap-2">
      <label class="text-left">Value</label>
      <input class="border p-2 rounded w-full text-black" type="number" bind:value={itemValue} />
    </div>

    <div class="flex flex-col gap-2">
      <label class="text-left">Count</label>
      <input class="border p-2 rounded w-full text-black" type="number" bind:value={itemCount} />
    </div>

    <div class="md:col-span-2 flex flex-col items-center gap-2 mt-5 mb-5">
      <div class="flex flex-col w-full max-w-sm">
        <label class="text-left mb-2">Add to <span class="text-red-700">*</span></label>
        <select
          class="border p-2 rounded w-full text-black"
          style={submitted && !selectedCollection ? 'border: 2px solid red' : ''}
          bind:value={selectedCollection}>
          <option value="">-- Select --</option>
          <option value="wishlist">Wishlist</option>
          {#each collections as collection}
            <option value={collection.collectionId}>{collection.collectionName}</option>
          {/each}
        </select>
        {#if submitted && !selectedCollection}
          <p class="text-red-700 text-sm mt-1">Select a collection or a wishlist</p>
        {/if}
      </div>
    </div>

    <div class="md:col-span-2 flex justify-center">
      <button
        class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={createItem}>
        Add item
      </button>
    </div>
  </div>
</div>

<nav class="flex justify-left ml-10 mb-10">
  <button 
    class="bg-gray-400 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto(data.from)}>
    Cancel
  </button>
</nav>