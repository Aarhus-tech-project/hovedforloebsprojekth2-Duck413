<!-- Create collection page-->
<script>
  import { goto } from '$app/navigation';
  import { getToken } from '$lib/auth.js';
  import { BASE } from '$lib/config.js'; 

  let collectionName = $state('');
  let collectionDescription = $state('');
  let submitted = $state(false);

  async function createCollection() {
    submitted = true;
    if (!collectionName.trim()) return;

    await fetch(`${BASE}/Collection`, {
      method: 'POST',
      headers: { 
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${getToken()}`
      },
      body: JSON.stringify({
        collectionName,
        collectionDescription
      })
    });
    goto('/collections');
  }
</script>

<h1 class="text-center text-4xl mt-10">
    CREATE A COLLECTION
</h1>

<h2 class="text-xl text-center mt-0ml-10">
  All <span class="text-red-700">*</span> must be filled out
</h2>

<div class="flex flex-col gap-4 items-center mt-10">
  <div class="flex flex-col mb-5 gap-4">
    <label class="w-32 text-left">Name <span class="text-red-700">*</span></label>
    <div class="flex flex-col">
      <input 
        class="border p-2 rounded w-120 text-black {submitted && !collectionName.trim() ? 'border-red-500 border-2' : ''}" 
        type="text" 
        bind:value={collectionName} />
      {#if submitted && !collectionName.trim()}
        <p class="text-red-700 text-sm mt-1">Pick a name for your collection</p>
      {/if}
    </div>
  </div>

  <div class="flex flex-col mb-5 gap-4">
    <label class="w-32 text-left">Description</label>
    <textarea
      class="border p-2 rounded w-120 h-60 text-black resize-none" 
      bind:value={collectionDescription}>
    </textarea>
  </div>

  <button 
    class="bg-purple-700 text-white px-6 py-2 rounded-lg mt-4 ml-45 mr-45 cursor-pointer hover:bg-purple-900"
    onclick={createCollection}>
    Create collection
  </button>
</div>

<nav class="flex justify-left ml-10 mb-10">
  <button 
    class="bg-gray-400 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto('/collections')}>
    Cancel
  </button>
</nav>