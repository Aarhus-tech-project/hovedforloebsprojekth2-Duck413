<!-- Profile page-->
<script>
    import { goto } from '$app/navigation';
    import { getToken } from '$lib/auth.js';
    import { onMount } from 'svelte';
    import { BASE } from '$lib/config.js'; 

    // @ts-ignore
    let wishlistPreview = $state([]);
    let loading = $state(true);
    let userDescription = $state('');

    async function loadProfile() {
        const token = getToken();
        const res = await fetch(`${BASE}/User/me`, {
            headers: { 'Authorization': `Bearer ${token}` }
        });
        if (res.ok) {
            const data = await res.json();
            userDescription = data.userDescription;
        }
    }

    async function loadWishlistPreview() {
        try {
            const token = getToken();
            const res = await fetch(`${BASE}/Wishlist`, {
                headers: { 'Authorization': `Bearer ${token}` }
            });
            if (res.ok) {
                const data = await res.json();
                wishlistPreview = data.items.slice(0, 5);
            }
        } finally {
            loading = false;
        }
    }

    async function deleteUser() {
        if (!confirm('Are you sure you want to delete your account? This cannot be undone.')) return;

        const token = getToken();
        const payload = JSON.parse(atob(token.split('.')[1]));
        const userId = payload.userId;

        const res = await fetch(`${BASE}/User/${userId}`, {
            method: 'DELETE',
            headers: { 'Authorization': `Bearer ${token}` }
        });

        if (res.ok) {
            localStorage.removeItem('token');
            goto('/');
        } else {
            alert('Failed to delete account.');
        }
    }

    onMount(() => {
        loadProfile();
        loadWishlistPreview();
    });
</script>

<h1 class="text-center text-4xl mt-10">
    PROFILE
</h1>

<p class="text-center text-lg mt-4 mb-20 italic">
    {userDescription}
</p>

<div class="flex justify-between items-start ml-10 mr-10">
    <div class="flex flex-col gap-4">
        <button 
            class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
            onclick={() => goto('/profile/edit')}>
            Edit profile
        </button>

        <button 
            class="bg-red-600 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-red-800"
            onclick={deleteUser}>
            Delete account
        </button>
    </div>

    {#if loading}
        <p>Loading...</p>
    {:else if wishlistPreview.length === 0}
        <p>Your wishlist is empty</p>
    {:else}
        <div class="w-full max-w-xl border rounded-lg p-6">
            <ul class="flex flex-col gap-4">
                <h2 class="text-center text-2xl mb-6">
                    Wishlist preview
                </h2>
                {#each wishlistPreview as item}
                    <li class="flex justify-between items-center border-b pb-3 last:border-b-0 last:pb-0">
                        <span class="font-bold text-[18px]">{item.itemName}</span>
                        <button
                            class="bg-purple-700 text-white px-4 py-1 rounded-lg cursor-pointer hover:bg-purple-900 text-sm"
                            onclick={() => goto(`/items/${item.itemID}`)}>
                            View
                        </button>
                    </li>
                {/each}
            </ul>

            <div class="flex justify-center mt-6">
                <button 
                    class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
                    onclick={() => goto('/wishlist')}>
                    See full wishlist
                </button>
            </div>
        </div>
    {/if}
</div>