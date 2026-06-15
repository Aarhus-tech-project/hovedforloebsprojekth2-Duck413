<!-- View 1 collection -->
<script>
  import { goto } from '$app/navigation';

  const { data } = $props();

  const BASE = 'http://localhost:5215/api';

async function deleteCollection() {
    const confirmed = confirm('Are you sure you want to delete this collection? This cannot be undone.');
    if (!confirmed) return;

    await fetch(`${BASE}/Collection/${data.id}`, { method: 'DELETE' });
    goto('/collections');
}
</script>

<h1 class="text-center text-4xl mt-10">
  {data.collection.collectionName}
</h1>

<p class="text-center text-xl mt-2 mb-6">
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
    onclick={() => goto('/collections/id/edit')}>
    Edit collection
  </button>
  <button class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={deleteCollection}>
    Delete collection
  </button>
</nav>

{#if data.items.length === 0}
    <p class="ml-10 mt-10">This collection is empty</p>
    <a href="/items/new">Add your first item</a>

{:else}
  <ul class="grid grid-cols-5 gap-6 ml-10 mr-10 mb-10 items-start">
    {#each data.items as item}
      <li class="list-none border rounded-lg p-6">
        <h2 class="mt-5 font-bold text-[25px]">{item.itemName}</h2>
        <p class="text-[17px]">{item.itemDescription}</p>
        <button
          class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900"
          onclick={() => goto(`/collections/${data.id}/items/${item.itemID}`)}>
          View item
        </button>
      </li>
    {/each}
  </ul>
{/if}

<nav class="flex justify-left ml-10 mt-20 mb-10">
  <button 
    class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto('/collections')}>
    Go back to my collections
  </button>
</nav>