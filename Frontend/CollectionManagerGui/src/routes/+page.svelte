<!-- Login page-->
<script>
  import { goto } from '$app/navigation';

  let view = $state('login');
</script>

<header>
  <h1 class="text-center text-5xl font-bold p-12">
    COLLECTION MANAGER 
  </h1>
</header>

<h2 class="text-center text-2xl px-30 mt-15 mb-15">
  Welcome to Collection Manager. This program will help you keep track of your collections.
</h2>

<div class="flex justify-center gap-7 mb-10">
  <button
    class={view !== 'register' ? 'px-6 py-2 rounded-lg bg-purple-700 text-white cursor-pointer hover:bg-purple-900' : 'px-6 py-2 rounded-lg bg-gray-200 text-black '}
    onclick={() => view = 'register'}>
    Create user
  </button>
  <button
    class={view !== 'login' ? 'px-6 py-2 rounded-lg bg-purple-700 text-white cursor-pointer hover:bg-purple-900' : 'px-6 py-2 rounded-lg bg-gray-200 text-black'}
    onclick={() => view = 'login'}>
    Login
  </button>
</div>

{#if view === 'login'}
  <div class="flex flex-col gap-4 items-center">
    <h2 class="text-2xl font-bold ">Login</h2>
    
    <input class="border p-2 rounded w-64 text-black" type="text" placeholder="Email" />
    <input class="border p-2 rounded w-64 text-black" type="password" placeholder="Password" />
    <button class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900" 
      onclick={() => goto('/collections')}>
      Login
    </button>
  </div>

{:else}
<div class="flex flex-col gap-4 items-center">
  <h2 class="text-2xl font-bold">Create user</h2>
  
  <div class="flex items-center gap-4 mr-35">
    <label class="w-32 text-right">Your email</label>
    <input class="border p-2 rounded w-64 text-black" type="text" />
  </div>

  <div class="flex items-center gap-4 mr-35">
    <label class="w-32 text-right">Your password</label>
    <input class="border p-2 rounded w-64 text-black" type="password" />
  </div>

  <button class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900" 
    onclick={() => goto('/collections')}>
    Create
  </button>
</div>
{/if}

<button class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900" 
  onclick={() => goto('/collections')}>
  TEST
</button>