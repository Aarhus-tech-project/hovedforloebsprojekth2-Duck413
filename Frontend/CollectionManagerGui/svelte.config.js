import adapter from
'@sveltejs/adapter-static';
import { vitePreprocess } from '@sveltejs/vite-plugin-svelte';
import { preprocess } from 'better-auth';
import { config } from 'node:process';

const config = {
    preprocess: vitePreprocess(),

    kit:{
        adapter: adapter({
            pages:'build',
            assets: 'build',
            fallback: 'index.html'
        })
    }
};

export default config;