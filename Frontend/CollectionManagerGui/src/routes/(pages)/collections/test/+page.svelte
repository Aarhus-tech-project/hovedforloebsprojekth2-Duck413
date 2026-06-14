<!-- TEST af View 1 collection -->
<script>
    import { goto } from '$app/navigation';

    async function deleteCollection() {
        const confirmed = confirm('Are you sure you want to delete this collection? This cannot be undone.');
        if (!confirmed) return;
        goto('/collections');
    }
</script>

<h1 class="text-center text-4xl mt-10 ">
    TEST COLLECTION
</h1>

<p class="text-center text-2xl mt-9 mb-12">
    Description of collection
</p>

<nav class="flex justify-left ml-10 mt-6 mb-10">
    <button 
        class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
        onclick={() => goto('/items/new?collectionId=test&from=/collections/test')}>
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

<!-- Dette er et eksempel på hvordan et item ville se ud - bruges til design -->
<ul class="grid grid-cols-4 gap-6 ml-10 mr-10 mb-10 items-start">
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Item Name 1</h2>
    <p class="text-[17px]">Item description here. Here is written a description of my item</p>
    <button class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/items/itemTest')}>View TEST item</button>
  </li>
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Item Name 2</h2>
    <p class="text-[17px]">Item description here. Here is written a description of my item</p>
    <button class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/items/itemTest')}>View TEST item</button>
  </li>
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Item Name 3</h2>
    <p class="text-[17px]">Item description here. Here is written a description of my item</p>
    <button class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/items/itemTest')}>View TEST item</button>
  </li>
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Item Name 4</h2>
    <p class="text-[17px]">Item description here. Here is written a description of my item</p>
    <button class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/items/itemTest')}>View TEST item</button>
  </li>
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Item Name 5</h2>
    <p class="text-[17px]">Item description here. Here is written a description of my item</p>
    <button class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/items/itemTest')}>View TEST item</button>
  </li>
  <li class="list-none border rounded-lg p-4">
    <h2 class="font-bold text-[25px]">Item Name 6</h2>
    <p class="text-[17px]">Item description here. Here is written a description of my item</p>
    <button class="inline-block bg-purple-700 text-white px-6 py-2 mt-3 rounded-lg cursor-pointer hover:bg-purple-900" onclick={() => goto('/items/itemTest')}>View TEST item</button>
  </li>
</ul> 

<nav class="flex justify-left ml-10 mt-20 mb-10">
  <button 
    class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto('/collections')}>
    Go back to My Collections
  </button>
</nav>