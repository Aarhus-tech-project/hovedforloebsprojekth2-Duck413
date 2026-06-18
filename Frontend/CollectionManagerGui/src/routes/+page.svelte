<!-- Login page-->
<script>
  import { goto } from '$app/navigation';
  import { setToken } from '$lib/auth.js';
  import { BASE } from '$lib/config.js'; 

  let view = $state('login');
  let email = $state('');
  let password = $state('');
  let registerEmail = $state('');
  let registerPassword = $state('');
  let displayName = $state('');
  let userDescription = $state('');
  let loggingIn = $state(false);
  let loginError = $state('');
  let registerSubmitted = $state(false);

  async function register() {
    registerSubmitted = true;
    if (!registerEmail.trim() || !registerPassword.trim() || !displayName.trim()) {
      return;
    }
    const res = await fetch(`${BASE}/Auth/register`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ 
        userEmail: registerEmail, 
        password: registerPassword,
        displayName: displayName,
        userDescription: userDescription
      })
    });
    if (res.ok) {
      const loginRes = await fetch(`${BASE}/Auth/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ userEmail: registerEmail, password: registerPassword })
      });
      const data = await loginRes.json();
      setToken(data.token);
      goto('/collections');
    } else {
      alert('Registration failed');
    }
  } 

  async function login() {
    loginError = '';
    loggingIn = true;

    try {
      const res = await fetch(`${BASE}/Auth/login`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ userEmail: email, password: password })
      });

      if (!res.ok) {
        loginError = 'Incorrect email or password. Please try again.';
        return;
      }

      const data = await res.json();
      setToken(data.token);
      goto('/collections');
    } catch (e) {
      loginError = 'Something went wrong. Please try again.';
    } finally {
      loggingIn = false;
    }
  }
</script>

<header>
  <h1 class="text-center text-5xl font-bold p-12">
    COLLECTION MANAGER 
  </h1>
</header>

<h2 class="text-center text-2xl px-30 mt-15 mb-15">
  Welcome to Collection Manager. This program will help you keep track of your collections.
</h2>

<div class="flex justify-center gap-7 mb-15">
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
    <h2 class="text-3xl mb-7 font-bold">Login</h2>
  <label class="w-64 text-left">Email</label>
  <input class="border p-2 rounded w-64 mb-5 text-black" type="text" bind:value={email} />
  <label class="w-64 text-left">Passsword</label>
  <input class="border p-2 rounded w-64 mb-5 text-black" type="password" bind:value={password} onkeydown={(e) => { if (e.key === 'Enter') login(); }} />
    
  {#if loginError}
      <p class="text-red-700 text-sm">{loginError}</p>
    {/if}

    <button 
      class="bg-purple-700 text-white px-6 py-2 mb-10 rounded-lg cursor-pointer hover:bg-purple-900 disabled:opacity-50 disabled:cursor-wait"
      disabled={loggingIn}
      onclick={login}>
      {loggingIn ? 'Logging in...' : 'Login'}
    </button>
  </div>

{:else}
  <div class="flex flex-col gap-4 items-center">
    <h2 class="text-3xl font-bold">Create user</h2>

    <h2 class="text-xl justify-left mb-10">
      All <span class="text-red-700">*</span> must be filled out
    </h2>
    
    <div class="flex flex-col mb-5 gap-4">
      <label class="w-32 text-left">Your email <span class="text-red-700">*</span></label>
      <div class="flex flex-col">
        <input class="border p-2 rounded w-64 text-black {registerSubmitted && !registerEmail.trim() ? 'border-red-500 border-2' : ''}" type="text" bind:value={registerEmail} />
        {#if registerSubmitted && !registerEmail.trim()}
          <p class="text-red-700 text-sm mt-1">Email is required</p>
        {/if}
      </div>
    </div>

    <div class="flex flex-col mb-5 gap-4">
      <label class="w-32 text-left">Your password <span class="text-red-700">*</span></label>
      <div class="flex flex-col">
        <input class="border p-2 rounded w-64 text-black {registerSubmitted && !registerPassword.trim() ? 'border-red-500 border-2' : ''}" type="password" bind:value={registerPassword} />
        {#if registerSubmitted && !registerPassword.trim()}
          <p class="text-red-700 text-sm mt-1">Password is required</p>
        {/if}
      </div>
    </div>

    <div class="flex flex-col mb-5 gap-4">
      <label class="w-32 text-left">Display name <span class="text-red-700">*</span></label>
      <div class="flex flex-col">
        <input class="border p-2 rounded w-64 text-black {registerSubmitted && !displayName.trim() ? 'border-red-500 border-2' : ''}" type="text" bind:value={displayName} />
        {#if registerSubmitted && !displayName.trim()}
          <p class="text-red-700 text-sm mt-1">Display name is required</p>
        {/if}
      </div>
    </div>

    <div class="flex flex-col mb-5 gap-4">
      <label class="w-32 text-left">Description</label>
      <input class="border p-2 rounded w-64 text-black" type="text" bind:value={userDescription} />
    </div>

    <button class="bg-purple-700 text-white px-6 py-2 mb-10 rounded-lg cursor-pointer hover:bg-purple-900" 
      onclick={register}>
      Create
    </button>
  </div>
{/if}