<!-- Create collection page-->
<script>
  import { goto } from '$app/navigation';

  const BASE = 'https://localhost:44366/api';

  let collectionName = $state('');
  let collectionDescription = $state('');

  async function createCollection() {
    await fetch(`${BASE}/Collection`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        collectionName: collectionName,
        collectionDescription: collectionDescription
      })
    });
    goto('/collections');
  }

  /*async function login() {
    await goto('/collections');
  }*/
</script>

<h1 class="text-center text-4xl mt-10">
    CREATE A COLLECTION
</h1>

<div class="flex flex-col gap-4 items-center mt-10">
  
  <div class="flex items-center gap-4 mr-35">
    <label class="w-32 text-right">Name</label>
    <input 
      class="border p-2 rounded w-120 text-black" 
      type="text" 
      bind:value={collectionName} />
  </div>

  <div class="flex items-center gap-4 mr-35">
    <label class="w-32 text-right">Description (optional)</label>
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

<nav class="flex justify-left ml-10 mt-18">
  <button 
    class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto('/collections')}>
    Go back to collections
  </button>
</nav>