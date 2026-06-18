<!-- Other pages-->
<script>
  import { getDisplayName } from '$lib/auth.js';

	let { children } = $props();

  const displayName = getDisplayName();
</script>

<header>
  <div class="flex justify-end mr-10 pt-4 text-white text-sm">
    Logged in as: <span class="font-bold ml-1">{displayName}</span>
  </div>
  <nav class="flex flex-wrap justify-center gap-2 md:gap-14 text-sm md:text-xl p-4">
    <a class="cursor-pointer hover:text-purple-400" href="/collections">My collections</a>
    <a class="cursor-pointer hover:text-purple-400" href="/items/new">Add item</a>
    <a class="cursor-pointer hover:text-purple-400" href="/marketplace">Marketplace</a>
    <a class="cursor-pointer hover:text-purple-400" href="/profile">Profile</a>
    <a class="cursor-pointer hover:text-purple-400" href="/">Logout</a>
  </nav>
</header>

{@render children()}