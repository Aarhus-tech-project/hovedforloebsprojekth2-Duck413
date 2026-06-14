<!-- View 1 collection -->
<script>
import { goto } from '$app/navigation';

const { data } = $props();
</script>

<h1>
    Collection {data.id}
</h1>

<nav class="flex justify-left ml-10 mt-20">
  <button 
    class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto('/collections')}>
    Go back to collections
  </button>
</nav>