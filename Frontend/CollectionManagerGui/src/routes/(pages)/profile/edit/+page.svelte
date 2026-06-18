<!-- Edit profile -->
<script>
    import { goto } from '$app/navigation';
    import { getToken } from '$lib/auth.js';
    import { onMount } from 'svelte';
    import { BASE } from '$lib/config.js'; 

    let displayName = $state('');
    let userDescription = $state('');
    let submitted = $state(false);
    let loading = $state(true);

    async function loadProfile() {
        const token = getToken();
        const res = await fetch(`${BASE}/User/me`, {
            headers: { 'Authorization': `Bearer ${token}` }
        });
        if (res.ok) {
            const data = await res.json();
            displayName = data.displayName;
            userDescription = data.userDescription ?? '';
        }
        loading = false;
    }

    async function updateProfile() {
        submitted = true;
        if (!displayName.trim()) return;

        const token = getToken();
        await fetch(`${BASE}/User/me`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            },
            body: JSON.stringify({ displayName, userDescription })
        });
        goto('/profile');
    }

    onMount(() => {
        loadProfile();
    });
</script>

<h1 class="text-center text-4xl mt-10">
    EDIT PROFILE
</h1>

{#if loading}
    <p class="text-center mt-10">Loading...</p>
{:else}
    <div class="flex flex-col gap-4 items-center mt-10">
        <div class="flex items-center gap-4">
            <label class="w-32 text-right">Display name <span class="text-red-700">*</span></label>
            <div class="flex flex-col">
                <input
                    class="border p-2 rounded w-80 text-black {submitted && !displayName.trim() ? 'border-red-500 border-2' : ''}"
                    type="text"
                    bind:value={displayName} />
                {#if submitted && !displayName.trim()}
                    <p class="text-red-700 text-sm mt-1">Display name cannot be empty</p>
                {/if}
            </div>
        </div>

        <div class="flex items-center gap-4">
            <label class="w-32 text-right">Description</label>
            <textarea
                class="border p-2 rounded w-80 h-32 text-black resize-none"
                bind:value={userDescription}>
            </textarea>
        </div>

        <button
            class="bg-purple-700 text-white px-6 py-2 rounded-lg mt-4 cursor-pointer hover:bg-purple-900"
            onclick={updateProfile}>
            Save changes
        </button>
    </div>
{/if}

<nav class="flex justify-left ml-10 mt-10">
    <button 
        class="bg-gray-400 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={() => goto('/profile')}>
        Cancel
    </button>
</nav>