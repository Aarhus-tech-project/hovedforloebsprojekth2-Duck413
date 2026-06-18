//View 1 collection
export const ssr = false;

import { BASE } from '$lib/config.js'; 
import { getToken } from '$lib/auth.js';

export async function load({ params }: { params: { id: string } }) {
    const token = getToken();
    const headers = { 'Authorization': `Bearer ${token}` };

    const [collectionRes, itemsRes] = await Promise.all([
        fetch(`${BASE}/Collection/${params.id}`, { headers }),
        fetch(`${BASE}/Item/collection/${params.id}`, { headers })
    ]);

    const collection = await collectionRes.json();
    const items = itemsRes.ok ? await itemsRes.json() : [];

    return { id: params.id, collection, items };
}