<!-- View 1 item -->
<script>
    import { goto } from '$app/navigation';
    import { getToken } from '$lib/auth.js';
    import { BASE } from '$lib/config.js'; 

    const { data } = $props();

    async function deleteItem() {
        const confirmed = confirm('Are you sure you want to delete this item? This cannot be undone.');
        if (!confirmed) return;

        const token = getToken();
        await fetch(`${BASE}/Item/${data.itemId}`, { 
            method: 'DELETE',
            headers: { 'Authorization': `Bearer ${token}` }
        });
        goto(`/collections/${data.collectionId}`);
    }
</script>

<h1 class="text-center text-4xl mt-10">
  {data.item.itemName}
</h1>

<nav class="flex justify-left ml-10 mt-10">
    <button
        class="bg-purple-700 text-white px-6 py-2 mr-10 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={() => goto(`/items/${data.itemId}/edit`)}>    
        Edit item
    </button>
    <button class="bg-red-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={deleteItem}>
        Delete item
    </button>
</nav>

<div class="flex gap-70 ml-135">
    <p class="text-left text-lg border border-gray-400 rounded-lg p-4 min-w-md max-w-md min-h-32 bg-white text-black whitespace-pre-wrap break-words {data.item.itemDescription ? '' : 'italic'}">
        {data.item.itemDescription || 'No description'}
    </p>
    <div class="flex flex-col gap-4 text-xl">
        <p>Type: {data.item.itemType}</p>
        <p>Value: {data.item.itemValue}</p>
        <p>Count: {data.item.itemCount}</p>
    </div>
</div>

<nav class="flex justify-left ml-10 mt-10 mb-10">
    <button
        class="bg-gray-400 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={() => {
        if (data.collectionId) {
            goto(`/collections/${data.collectionId}`);
        } else {
            goto('/wishlist');
        }
        }}>
        {data.collectionId ? 'Go back to collection' : 'Go back to wishlist'}
    </button>
</nav>