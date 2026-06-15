<!-- Edit item -->
<script>
    import { goto } from '$app/navigation';

    const BASE = 'http://localhost:5215/api';
    const { data } = $props();

    let itemName = $state(data.item.itemName);
    let itemDescription = $state(data.item.itemDescription ?? '');
    let itemType = $state(data.item.itemType ?? '');
    let itemValue = $state(data.item.itemValue ?? '');
    let itemCount = $state(data.item.itemCount ?? '');
    let submitted = $state(false);

    async function updateItem() {
        submitted = true;
        if (!itemName.trim()) return;

        await fetch(`${BASE}/Item/${data.itemId}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                itemName,
                itemDescription,
                itemType,
                itemValue: Number(itemValue),
                itemCount: Number(itemCount)
            })
        });
        goto(`/collections/${data.collectionId}/items/${data.itemId}`);
        /*goto('/items/itemTest');*/    }
</script>

<h1 class="text-center text-4xl mt-10">
    EDIT ITEM
</h1>

<h2 class="text-xl ml-10 mt-5">PLEASE NOTE:</h2>
<h2 class="text-xl ml-10">
    All <span class="text-red-700">*</span> must be filled out
</h2>

<div class="w-full max-w-4xl mx-auto px-4">
  <div class="grid grid-cols-2 gap-x-4 gap-y-4 mt-10">

    <div class="flex items-center gap-4">
      <label class="w-24 shrink-0 text-right">Name <span class="text-red-700">*</span></label>
      <div class="flex flex-col flex-1">
        <input
          class="border p-2 rounded w-full text-black {submitted && !itemName.trim() ? 'border-red-500 border-2' : ''}"
          type="text"
          bind:value={itemName} />
        {#if submitted && !itemName.trim()}
          <p class="text-red-700 text-sm mt-1">Pick a name for your item</p>
        {/if}
      </div>
    </div>

    <div class="flex items-center gap-4">
      <label class="w-24 shrink-0 text-right">Type</label>
      <input class="border p-2 rounded w-full text-black flex-1" type="text" bind:value={itemType} />
    </div>

    <div class="flex items-start gap-4 row-span-2">
      <label class="w-24 shrink-0 text-right mt-2">Description</label>
      <textarea class="border p-2 rounded w-full h-32 text-black resize-none flex-1" bind:value={itemDescription}></textarea>
    </div>

    <div class="flex items-center gap-4 self-start">
      <label class="w-24 shrink-0 text-right">Value</label>
      <input class="border p-2 rounded w-full text-black flex-1" type="number" bind:value={itemValue} />
    </div>

    <div class="flex items-center gap-4 self-start">
      <label class="w-24 shrink-0 text-right">Count</label>
      <input class="border p-2 rounded w-full text-black flex-1" type="number" bind:value={itemCount} />
    </div>

    <div class="col-span-2 flex justify-center mt-4">
      <button
        class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={updateItem}>
        Save changes
      </button>
    </div>

  </div>
</div>

<!-- TEST NAVIGATION; DELETE LATER-->
<nav class="flex justify-left ml-10">
  <button 
    class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto('/items/itemTest')}>
    Cancel
  </button>
</nav>

<!-- ACTUAL NAVIGATION
<nav class="flex justify-left ml-10">
  <button 
    class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto(`/collections/${data.collectionId}/items/${data.itemId}`)}>
    Cancel
  </button>
</nav>
-->