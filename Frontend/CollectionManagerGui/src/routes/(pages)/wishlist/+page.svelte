<!-- Wishlist -->
<script>
    import { goto } from '$app/navigation';
    import { getToken } from '$lib/auth.js';
    import { onMount } from 'svelte';
    import { BASE } from '$lib/config.js'; 

    let wishlistName = $state('');
    // @ts-ignore
    let items = $state([]);
    let loading = $state(true);
    let error = $state('');

    async function loadWishlist() {
        try {
            const token = getToken();
            const res = await fetch(`${BASE}/Wishlist`, {
                headers: { 'Authorization': `Bearer ${token}` }
            });
            if (!res.ok) throw new Error('Failed to fetch wishlist');
            const data = await res.json();
            wishlistName = data.wishlistName;
            items = data.items;
        } catch (e) {
            error = 'Could not fetch wishlist';
        } finally {
            loading = false;
        }
    }

    onMount(() => {
        loadWishlist();
    });
</script>

<h1 class="text-center text-4xl mt-10">
    {wishlistName || 'WISHLIST'}
</h1>

{#if loading}
    <p class="text-left ml-10 mt-10">Fetching wishlist...</p>

{:else if error}
    <p class="text-left text-white ml-10 mt-10">{error}</p>

{:else if items.length === 0}
    <p class="text-left ml-10 mt-10">Your wishlist is empty</p>
    <p class="text-center"><a href="/items/new" class="text-purple-700 underline">Add your first item</a></p>

{:else}
    <ul class="grid grid-cols-5 gap-6 ml-10 mr-10 mt-10 mb-10 items-start">
        {#each items as item}
            <li class="list-none border rounded-lg p-6">
                <h2 class="font-bold text-[20px]">{item.itemName}</h2>
                <p class="text-[15px]">{item.itemDescription}</p>
                <button
                    class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900"
                    onclick={() => goto(`/items/${item.itemID}`)}>
                    View item
                </button>
            </li>
        {/each}
    </ul>
{/if}

<nav class="flex justify-left ml-10 mt-20">
  <button 
    class="bg-gray-400 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto('/profile')}>
    Go back to profile
  </button>
</nav>