<!-- Edit collection -->
<script>
    import { goto } from '$app/navigation';
    import { getToken } from '$lib/auth.js';
    import { BASE } from '$lib/config.js';  
      
    const { data } = $props();

    let collectionName = $state(data.collection.collectionName);
    let collectionDescription = $state(data.collection.collectionDescription ?? '');
    let submitted = $state(false);

    async function updateCollection() {
        submitted = true;
        if (!collectionName.trim()) return;

        const token = getToken();
        await fetch(`${BASE}/Collection/${data.id}`, {
            method: 'PUT',
            headers: { 
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify({
                collectionName,
                collectionDescription
            })
        });
        goto(`/collections/${data.id}`);
    }
</script>

<h1 class="text-center text-4xl mt-10">
    EDIT COLLECTION
</h1>

<h2 class="text-xl ml-10 mt-5">PLEASE NOTE:</h2>
<h2 class="text-xl ml-10">
    All <span class="text-red-700">*</span> must be filled out
</h2>

<div class="flex flex-col gap-4 items-center mt-10">

    <div class="flex items-center gap-4 mr-35">
        <label class="w-32 text-right">Name <span class="text-red-700">*</span></label>
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

    <div class="flex items-center gap-4 mr-35">
        <label class="w-32 text-right">Description</label>
        <textarea
            class="border p-2 rounded w-120 h-60 text-black resize-none"
            bind:value={collectionDescription}>
        </textarea>
    </div>

    <button
        class="bg-purple-700 text-white px-6 py-2 rounded-lg mt-4 cursor-pointer hover:bg-purple-900"
        onclick={updateCollection}>
        Save changes
    </button>

</div>

<nav class="flex justify-left ml-10 mb-10">
  <button 
    class="bg-gray-400 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto(`/collections/${data.id}`)}>
    Cancel
  </button>
</nav>
