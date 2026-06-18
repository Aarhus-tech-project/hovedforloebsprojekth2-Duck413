<!-- View 1 collection -->
<script>
  import { goto } from '$app/navigation';
  import { getToken } from '$lib/auth.js';
  import { BASE } from '$lib/config.js'; 

  const { data } = $props();

  async function deleteCollection() {
    const confirmed = confirm('Are you sure you want to delete this collection? This cannot be undone.');
    if (!confirmed) return;

    const token = getToken();
    await fetch(`${BASE}/Collection/${data.id}`, { 
        method: 'DELETE',
        headers: { 'Authorization': `Bearer ${token}` }
    });
    goto('/collections');
}
</script>

<h1 class="text-center text-4xl mt-10">
  {data.collection.collectionName}
</h1>

<p class="text-center text-xl mt-5 mb-10 md:px-20">
  {data.collection.collectionDescription}
</p>

<nav class="flex justify-left ml-10 mt-6 mb-10">
  <button 
    class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto(`/items/new?collectionId=${data.id}&from=/collections/${data.id}`)}>
    + Create a new item
  </button>
  <button 
    class="bg-purple-700 text-white px-6 py-2 ml-10 mr-10 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto(`/collections/${data.id}/edit`)}>
    Edit collection
  </button>
  <button class="bg-red-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={deleteCollection}>
    Delete collection
  </button>
</nav>

{#if data.items.length === 0}
  <div class="ml-10 mt-10">
    <p>This collection is empty</p>
    <a href="/items/new">Add your first item</a>
  </div>  

{:else}
  <ul class="grid gap-6 ml-10 mr-10 mb-10 items-start [grid-template-columns:repeat(auto-fill,minmax(320px,320px))]">
    {#each data.items as item}
      <li class="flex flex-col list-none border rounded-lg p-6 w-full h-80">
        <h2 class="font-bold text-[25px]">
          {item.itemName}
        </h2>
        <p class="text-[17px] line-clamp-4">
          {item.itemDescription}
        </p>
        <button
          class="inline-block bg-gray-400 text-white px-6 py-2 mt-auto rounded-lg cursor-pointer hover:bg-purple-900"
          onclick={() => goto(`/items/${item.itemID}`)}>
          View item
        </button>
      </li>
    {/each}
  </ul>
{/if}

<nav class="flex justify-left ml-10 mt-20 mb-10">
  <button 
    class="bg-gray-400 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto('/collections')}>
    Go back to my collections
  </button>
</nav>