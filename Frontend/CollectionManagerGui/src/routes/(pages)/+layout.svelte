<!-- Other pages-->
<script>

	let { children } = $props();
</script>

<header>
  <nav class="flex justify-center gap-14 text-xl p-4">
    <a class="cursor-pointer hover:text-purple-400" href="/collections">My collections</a>
    <a class="cursor-pointer hover:text-purple-400" href="/items/new">Add item</a>
    <a class="cursor-pointer hover:text-purple-400" href="/marketplace">Marketplace</a>
    <a class="cursor-pointer hover:text-purple-400" href="/profile">Profile</a>
    <a class="cursor-pointer hover:text-purple-400" href="/">Logout</a>
  </nav>
</header>

{@render children()}