<!-- Profile page-->
<script>
    import { goto } from '$app/navigation';
</script>

<h1 class="text-center text-4xl mt-10">
    PROFILE
</h1>

<h2 class="text-center text-3xl mt-30">
    This page is under development
</h2>

<nav class="flex justify-left ml-10 mt-6">
  <button 
    class="bg-purple-700 text-white px-6 py-2 rounded-lg cursor-pointer hover:bg-purple-900"
    onclick={() => goto('/wishlist')}>
    Wishlist
  </button>
</nav>

<!--    public int? PictureID { get; set; }
        public string DisplayName { get; set; }
        public string? UserDescription { get; set; }
        public Picture? Picture { get; set; }
  -->