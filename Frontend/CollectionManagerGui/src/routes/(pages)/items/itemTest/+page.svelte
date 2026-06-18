<!-- TEST af View 1 item. Bruges kun til opbygning og desgin af GUI - ikke det endelige resultat -->
<script>
    import { goto } from '$app/navigation';

async function deleteItem() {
    const confirmed = confirm('Are you sure you want to delete this item? This cannot be undone.');
    if (!confirmed) return;
    goto('/collections/test');
}
</script>

<h1 class="text-center text-4xl mt-10 mb-15">
    TEST ITEM
</h1>

<div class="flex justify-center">
    <p class="text-left text-2xl mb-10 mr-50 mb-60">
        Description of item
    </p>
    <div class="flex flex-col gap-4 text-xl">
        <p>Type of item</p>
        <p>Value of item</p>
        <p>Count of item</p>
    </div>
</div>

<nav class="flex justify-center ml-10">
    <button
        class="bg-purple-700 text-white px-6 py-2 mr-10 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={() => goto('/items/itemTest/edit/')}>
        Edit item
    </button>
</nav>

<nav class="flex justify-center mt-5">
    <button class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={deleteItem}>
        Delete item
    </button>
</nav>

<nav class="flex justify-left ml-10 mb-10 mt-10">
    <button
        class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={() => goto(`/collections/test/`)}>
        Go back to collection
    </button>
</nav>