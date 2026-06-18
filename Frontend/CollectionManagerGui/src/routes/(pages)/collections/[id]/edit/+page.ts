//Edit collection
export const ssr = false;

import { getToken } from '$lib/auth.js';
import { BASE } from '$lib/config.js'; 

export async function load({ params }: { params: { id: string } }) {
    const token = getToken();
    const res = await fetch(`${BASE}/Collection/${params.id}`, {
        headers: { 'Authorization': `Bearer ${token}` }
    });
    const collection = await res.json();
    return { id: params.id, collection };
}