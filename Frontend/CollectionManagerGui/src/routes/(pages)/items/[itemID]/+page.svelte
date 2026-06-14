<!-- View 1 item -->
<script>
    import { goto } from '$app/navigation';
    const { data } = $props();
    const BASE = 'http://localhost:5215/api';

async function deleteItem() {
    const confirmed = confirm('Are you sure you want to delete this item? This cannot be undone.');
    if (!confirmed) return;

    await fetch(`${BASE}/Collection/${data.itemId}`, { method: 'DELETE' });
    goto('/collections/${data.collectionId}');
}
</script>

<h1 class="text-center text-4xl mt-10">
    VIEW ITEM
</h1>

<nav class="flex justify-left ml-10 mt-10">
    <button
        class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={() => goto(`/items/${data.itemId}/edit`)}>    
        Edit item
    </button>
    <button class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={deleteItem}>
        Delete item
    </button>
</nav>

<nav class="flex justify-left ml-10 mt-10">
    <button
        class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={() => goto(`/collections/${data.collectionId}`)}>
        Go back to collection
    </button>
</nav>